using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NevskyFond.SocialNetwork.Api.Mapper;
using NevskyFond.SocialNetwork.Api.Models.Settings;
using NevskyFond.SocialNetwork.Communication.Extensions;
using NevskyFond.SocialNetwork.Data;
using NevskyFond.SocialNetwork.Data.Extensions;
using NevskyFond.SocialNetwork.Data.Mapper;
using NevskyFond.SocialNetwork.Data.Store.Comments;
using NevskyFond.SocialNetwork.Infrastructure.Consumers.Comments;
using NevskyFond.SocialNetwork.Infrastructure.Mapper;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace NevskyFond.SocialNetwork.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddDbContext<SocialNetworkContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SocialNetworkContext))));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCommentsQuery).Assembly));

            builder.Services.AddAutoMapper(typeof(CommentStoreMapper), typeof(CommentsMapper), typeof(CommentsInfrastractureMapper));
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialNetworkAPI", Version = "v1" });
                c.ExampleFilters();
            });

            builder.Services.AddScoped<ICommentsStore, CommentsStore>();

            SocialNetworkCommunicationExtensions.AddSocialNetworkCommunication(builder.Services);

            #region MassTransit

            var rabbitMqOptions = builder.Configuration
                .GetSection(nameof(RabbitMqOptions))
                .Get<RabbitMqOptions?>();

            builder.Services.AddMassTransit(mt =>
            {
                mt.AddConsumers(typeof(GetCommentsConsumer).Assembly);

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

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SocialNetworkContext>();

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
