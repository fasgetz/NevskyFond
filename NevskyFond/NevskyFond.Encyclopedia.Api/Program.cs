using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NevskyFond.Encyclopedia.Api.Mapper;
using NevskyFond.Encyclopedia.Api.Models.RequestValidations.Churchs;
using NevskyFond.Encyclopedia.Api.Models.Settings;
using NevskyFond.Encyclopedia.Communication.Mapper;
using NevskyFond.Encyclopedia.Communication.Services.Churchs;
using NevskyFond.Encyclopedia.Data;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using RabbitMQ.Client;
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

            // Add services to the container.
            builder.Services.AddDbContext<EncyclopediaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(EncyclopediaContext)), e =>
                {

                });
            });

            builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.DisableDataAnnotationsValidation = true;

                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            builder.Services.AddAutoMapper(typeof(ChurchMapper), typeof(ChurchInfrastructureMapper), typeof(ChurchComminicationMapper));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddChurchCommand).Assembly));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PortalChurchsAPI", Version = "v1" });
                c.ExampleFilters();
            });

            #region MassTransit

            var rabbitMqOptions = builder.Configuration
                .GetSection(nameof(RabbitMqOptions))
                .Get<RabbitMqOptions?>();

            builder.Services.AddMassTransit(mt =>
            {
                mt.AddDelayedMessageScheduler();
                mt.SetKebabCaseEndpointNameFormatter();

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

                    mq.UseDelayedMessageScheduler();
                    mq.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("dev", false));
                    mq.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
                });
            });

            #endregion

            builder.Services.AddScoped<IChurchService, ChurchService>();

            var app = builder.Build();

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
