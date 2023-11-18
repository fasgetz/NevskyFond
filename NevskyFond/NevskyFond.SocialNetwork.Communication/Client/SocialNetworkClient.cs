using AutoMapper;
using NevskyFond.SocialNetwork.Communication.Services.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Client
{
    internal class SocialNetworkClient : ISocialNetworkClient
    {
        public ICommentsService Comments { get; set; }

        public SocialNetworkClient(IServiceProvider serviceProvider)
        {
            Comments = new CommentsService(serviceProvider);
        }
    }
}