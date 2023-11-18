using AutoMapper;
using NevskyFond.SocialNetwork.Data.StoreModels.Results;
using NevskyFond.SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.Mapper
{
    public class CommentStoreMapper : Profile
    {
        public CommentStoreMapper()
        {
            CreateMap<Comment, CommentStoreDTO>();
        }
    }
}
