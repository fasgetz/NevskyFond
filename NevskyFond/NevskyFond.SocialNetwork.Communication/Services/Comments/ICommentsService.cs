using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Results.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Services.Comments
{
    public interface ICommentsService
    {
        /// <summary>
        /// Получение комментариев
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<GetCommentsResult> GetCommentsAsync(GetCommentsQuery query);
    }
}
