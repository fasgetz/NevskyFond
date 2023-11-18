using AutoMapper;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;

namespace NevskyFond.Encyclopedia.Infrastructure.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<GetChurchByIdQuery, GetChurchByIdStoreQuery>();

            CreateMap<GetChurchByIdStoreDTO, ChurchHandlerDTO>();
            CreateMap<GetChurchByIdStoreResult, GetChurchByIdHandlerResult>();
        }
    }
}