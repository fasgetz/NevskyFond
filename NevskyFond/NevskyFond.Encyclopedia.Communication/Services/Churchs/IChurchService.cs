using NevskyFond.Encyclopedia.Communication.Models.Commands;
using NevskyFond.Encyclopedia.Communication.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Communication.Services.Churchs
{
    public interface IChurchService
    {
        /// <summary>
        /// Добавление религиозного учреждения
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task<AddChurchInterserviceResult> AddChurchAsync(AddChurchInterserviceCommand command);
    }
}
