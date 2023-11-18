using AutoMapper;
using NevskyFond.SocialNetwork.Data.StoreModels.Queries;
using NevskyFond.SocialNetwork.Data.StoreModels.Results;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Infrastructure.Mapper
{
    public class CommentsInfrastractureMapper : Profile
    {
        public CommentsInfrastractureMapper()
        {
            CreateMap<GetCommentsQuery, GetCommentsStoreQuery>();
            CreateMap<CommentStoreDTO, CommentDTO>();
        }
    }
}
