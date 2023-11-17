using AutoMapper;
using NewskyFond.Portal.Gateway.Api.Models.Requests.Churchs;
using NewskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch;

namespace NewskyFond.Portal.Gateway.Api.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchRequest, AddChurchCommand>();
        }
    }
}