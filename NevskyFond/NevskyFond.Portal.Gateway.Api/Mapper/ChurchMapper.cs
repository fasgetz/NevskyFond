using AutoMapper;
using NevskyFond.Portal.Gateway.Api.Models.Requests.Churchs;
using NevskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch;

namespace NevskyFond.Portal.Gateway.Api.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchRequest, AddChurchCommand>();
        }
    }
}