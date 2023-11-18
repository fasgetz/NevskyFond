using AutoMapper;
using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Requests.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Responses.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Results.Comments;

namespace NevskyFond.SocialNetwork.Communication.Mapper
{
    public class CommentsMapper : Profile
    {
        public CommentsMapper()
        {
            CreateMap<GetCommentsQuery, GetCommentsConsumerRequest>();

            CreateMap<CommentResponseDTO, CommentResultDTO>();
            CreateMap<GetCommentsConsumerResponse, GetCommentsResult>();
        }
    }
}
