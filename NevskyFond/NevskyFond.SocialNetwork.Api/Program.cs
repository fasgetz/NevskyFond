
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NevskyFond.SocialNetwork.Api.Mapper;
using NevskyFond.SocialNetwork.Data;
using NevskyFond.SocialNetwork.Data.Mapper;
using NevskyFond.SocialNetwork.Data.Store.Comments;
using NevskyFond.SocialNetwork.Infrastructure.Mapper;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace NevskyFond.SocialNetwork.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SocialNetworkContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(SocialNetworkContext)), e =>
                {

                });
            });

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

            //#region MassTransit

            //var rabbitMqOptions = builder.Configuration
            //    .GetSection(nameof(RabbitMqOptions))
            //    .Get<RabbitMqOptions?>();

            //builder.Services.AddMassTransit(mt =>
            //{
            //    mt.AddConsumers(typeof(AddChurchConsumer).Assembly);
            //    mt.AddConsumer<AddChurchConsumer>();

            //    mt.SetKebabCaseEndpointNameFormatter();

            //    mt.UsingRabbitMq((ctx, cfg) =>
            //    {
            //        int port = rabbitMqOptions?.Port ?? 5672;

            //        cfg.Host(rabbitMqOptions?.Host,
            //            (ushort)port,
            //            "/",
            //            h =>
            //            {
            //                h.Username(rabbitMqOptions?.Username);
            //                h.Password(rabbitMqOptions?.Password);
            //            });

            //        cfg.UseDelayedMessageScheduler();
            //        cfg.ServiceInstance(instance =>
            //        {
            //            instance.ConfigureJobServiceEndpoints();
            //            instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
            //        });
            //    });

            //});

            //#endregion

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
