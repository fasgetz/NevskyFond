using AutoMapper;
using NevskyFond.SocialNetwork.Api.Models.Requests;
using NevskyFond.SocialNetwork.Api.Models.Responses;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;

namespace NevskyFond.SocialNetwork.Api.Mapper
{
    public class CommentsMapper : Profile
    {
        public CommentsMapper()
        {
            CreateMap<GetCommentsRequest, GetCommentsQuery>();
            CreateMap<CommentDTO, CommentResponseDTO>();
        }
    }
}
