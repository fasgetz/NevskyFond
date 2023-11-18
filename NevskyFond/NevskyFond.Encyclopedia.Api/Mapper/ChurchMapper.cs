using AutoMapper;
using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;

namespace NevskyFond.Encyclopedia.Api.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchRequest, AddChurchCommand>();
        }
    }
}