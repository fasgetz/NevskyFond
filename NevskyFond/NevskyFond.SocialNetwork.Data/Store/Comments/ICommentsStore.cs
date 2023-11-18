using NevskyFond.SocialNetwork.Data.StoreModels.Queries;
using NevskyFond.SocialNetwork.Data.StoreModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.Store.Comments
{
    public interface ICommentsStore
    {
        /// <summary>
        /// Получение списка комментариев по фильтру
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<GetCommentsStoreResult> GetComments(GetCommentsStoreQuery query);
    }
}
