using AutoMapper;
using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using NevskyFond.Encyclopedia.Api.Models.Responses.Churchs;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch;

namespace NevskyFond.Encyclopedia.Api.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchRequest, AddChurchCommand>();

            CreateMap<GetChurchByIdRequest, GetChurchByIdHandlerQuery>();

            CreateMap<ChurchHandlerDTO, ChurchResponseDTO>();
            CreateMap<GetChurchByIdHandlerResult, GetChurchByIdResponse>();

            CreateMap<GetExtendedChurchRequest, GetExtendedChurchHandlerQuery>();
            CreateMap<GetExtendedChurchRequestCommentsFilter, GetExtendedChurchHandlerCommentsFilter>();

            CreateMap<CommentResultHandlerDTO, CommentResponseDTO>();
            CreateMap<GetExtendedChurchDTO, GetExtendedChurchResponseDTO>();
            CreateMap<GetExtendedChurchHandlerResult, GetExtendedChurchResponse>();
        }
    }
}