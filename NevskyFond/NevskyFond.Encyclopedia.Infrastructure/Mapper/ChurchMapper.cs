using AutoMapper;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch;
using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Results.Comments;

namespace NevskyFond.Encyclopedia.Infrastructure.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<GetExtendedChurchHandlerQuery, GetCommentsQuery>()
                .ForMember(dest => dest.ChurchId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.CommentsFilter.PageNumber))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.CommentsFilter.PageSize));

            CreateMap<GetChurchByIdStoreDTO, GetExtendedChurchDTO>();
            CreateMap<GetChurchByIdStoreResult, GetExtendedChurchHandlerResult>();
            CreateMap<CommentResultDTO, CommentResultHandlerDTO>();

            CreateMap<GetChurchByIdHandlerQuery, GetChurchByIdStoreQuery>();

            CreateMap<GetChurchByIdStoreDTO, ChurchHandlerDTO>();
            CreateMap<GetChurchByIdStoreResult, GetChurchByIdHandlerResult>();

            CreateMap<GetExtendedChurchHandlerQuery, GetChurchByIdStoreQuery>();
        }
    }
}