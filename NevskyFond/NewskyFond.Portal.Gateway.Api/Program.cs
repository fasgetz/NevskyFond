
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using NewskyFond.Portal.Gateway.Api.Mapper;
using NewskyFond.Portal.Gateway.Api.Models.RequestValidations.Churchs;
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
