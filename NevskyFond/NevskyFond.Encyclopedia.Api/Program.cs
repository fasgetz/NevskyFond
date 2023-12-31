using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NevskyFond.Encyclopedia.Api.Mapper;
using NevskyFond.Encyclopedia.Api.Models.RequestValidations.Churchs;
using NevskyFond.Encyclopedia.Api.Settings;
using NevskyFond.Encyclopedia.Data;
using NevskyFond.Encyclopedia.Data.Extensions;
using NevskyFond.Encyclopedia.Data.Mapper;
using NevskyFond.Encyclopedia.Data.Store.Church;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using NevskyFond.SocialNetwork.Communication.Extensions;
using RabbitMQ.Client;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using ChurchInfrastructureMapper = NevskyFond.Encyclopedia.Infrastructure.Mapper.ChurchMapper;

namespace NevskyFond.Encyclopedia.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddDbContext<EncyclopediaContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(EncyclopediaContext))));

            builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.DisableDataAnnotationsValidation = true;

                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            builder.Services.AddAutoMapper(typeof(ChurchMapper), typeof(ChurchInfrastructureMapper), typeof(ChurchStoreMapper));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddChurchCommand).Assembly));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EncyclopediaAPI", Version = "v1" });
                c.ExampleFilters();
            });

            #region MassTransit

            var rabbitMqOptions = builder.Configuration
                .GetSection(nameof(RabbitMqOptions))
                .Get<RabbitMqOptions?>();

            builder.Services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, mq) =>
                {
                    int port = rabbitMqOptions?.Port ?? 5672;

                    mq.Host(rabbitMqOptions?.Host,
                        (ushort)port,
                        "/",
                        h =>
                        {
                            h.Username(rabbitMqOptions?.Username);
                            h.Password(rabbitMqOptions?.Password);
                        });


                    mq.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
                    mq.UseTimeout(x => x.Timeout = TimeSpan.FromSeconds(5));
                });
            });

            #endregion

            SocialNetworkCommunicationExtensions.AddSocialNetworkCommunication(builder.Services);

            builder.Services.AddScoped<IChurchStore, ChurchStore>();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EncyclopediaContext>();

            DatabaseExtensions.MigrateAndSeed(dbContext);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
