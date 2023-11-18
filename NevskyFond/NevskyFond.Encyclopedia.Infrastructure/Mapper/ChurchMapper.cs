using AutoMapper;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Requests;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Responses;
using NevskyFond.Encyclopedia.Communication.Models.Commands;
using NevskyFond.Encyclopedia.Communication.Models.Results;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Mapper
{
    public class ChurchMapper : Profile
    {
        public ChurchMapper()
        {
            CreateMap<AddChurchCommand, AddChurchInterserviceCommand>();
            CreateMap<AddChurchInterserviceResult, AddChurchCommandResult>();
        }
    }
}
