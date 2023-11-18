using AutoMapper;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using NevskyFond.Encyclopedia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Mapper
{
    public class ChurchStoreMapper : Profile
    {
        public ChurchStoreMapper()
        {
            CreateMap<Church, GetChurchByIdStoreDTO>();
        }
    }
}
