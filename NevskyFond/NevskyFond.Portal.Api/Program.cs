
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using NevskyFond.Portal.Api.Models.RequestExamples.Churchs;
using NevskyFond.Portal.Api.Models.Settings;
using NevskyFond.Portal.Data;
using NevskyFond.Portal.Infrastructure.Consumers.Churches;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace NevskyFond.Portal.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PortalContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(PortalContext)), e =>
                {

                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PortalGatewayAPI", Version = "v1" });
                c.ExampleFilters();
            });

            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            #region MassTransit

            var rabbitMqOptions = builder.Configuration
                .GetSection(nameof(RabbitMqOptions))
                .Get<RabbitMqOptions?>();

            builder.Services.AddMassTransit(mt =>
            {
                mt.AddConsumers(typeof(AddChurchConsumer).Assembly);
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