
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.OpenApi.Models;
using NewskyFond.Portal.Gateway.Api.Mapper;
using NewskyFond.Portal.Gateway.Api.Models.RequestValidations.Churchs;
using NewskyFond.Portal.Gateway.Api.Models.Settings;
using NewskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace NewskyFond.Portal.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.DisableDataAnnotationsValidation = true;

                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            builder.Services.AddAutoMapper(typeof(ChurchMapper));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddChurchCommand).Assembly));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PortalGatewayAPI", Version = "v1" });
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
                    mq.UseTimeout(x => x.Timeout = TimeSpan.FromSeconds(10));
                });
            });

            builder.Services.AddMassTransitHostedService();

            #endregion

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
