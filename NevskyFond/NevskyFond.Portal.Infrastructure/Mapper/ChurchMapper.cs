using AutoMapper;
using NevskyFond.Portal.Infrastructure.Commands.Churches;
using NevskyFond.Portal.Infrastructure.Consumers.Churches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Infrastructure.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchConsumerRequest, AddChurchCommand>();
            CreateMap<AddChurchCommandResult, AddChurchConsumerResponse>();
        }
    }
}