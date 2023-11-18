
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
