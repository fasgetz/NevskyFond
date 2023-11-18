using Microsoft.Extensions.DependencyInjection;
using NevskyFond.SocialNetwork.Communication.Client;
using NevskyFond.SocialNetwork.Communication.Mapper;
using NevskyFond.SocialNetwork.Communication.Services.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Extensions
{
    public static class SocialNetworkCommunicationExtensions
    {
        public static void AddSocialNetworkCommunication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommentsMapper));

            services.AddScoped<ICommentsService, CommentsService>();

            services.AddScoped<ISocialNetworkClient, SocialNetworkClient>();
        }
    }
}
