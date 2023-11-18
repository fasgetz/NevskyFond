using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Store.Church
{
    public interface IChurchStore
    {
        /// <summary>
        /// Поиск религиозного учреждения по ID
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<GetChurchByIdStoreResult> GetChurchByIdAsync(GetChurchByIdStoreQuery query);
    }
}
