using AutoMapper;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Requests;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Responses;
using NevskyFond.Encyclopedia.Communication.Models.Commands;
using NevskyFond.Encyclopedia.Communication.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Communication.Mapper
{
    public class ChurchComminicationMapper : Profile
    {
        public ChurchComminicationMapper()
        {
            CreateMap<AddChurchInterserviceCommand, AddChurchConsumerRequest>();
            CreateMap<AddChurchConsumerResponse, AddChurchInterserviceResult>();
        }
    }
}
