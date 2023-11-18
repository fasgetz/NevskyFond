using NevskyFond.SocialNetwork.Communication.Services.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Client
{
    public interface ISocialNetworkClient
    {
        public ICommentsService Comments { get; set; }
    }
}
