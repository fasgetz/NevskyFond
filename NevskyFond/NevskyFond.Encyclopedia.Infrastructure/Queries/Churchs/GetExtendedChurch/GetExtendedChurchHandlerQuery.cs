using MediatR;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch
{
    /// <summary>
    /// Фильтр для получения комментариев
    /// </summary>
    public class GetExtendedChurchHandlerCommentsFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetExtendedChurchHandlerQuery : IRequest<GetExtendedChurchHandlerResult>
    {
        public int Id { get; set; }

        /// <summary>
        /// Фильтр комментариев
        /// </summary>
        /// <remarks>
        /// Если заполнен, то будут дополнительно получаться данные из микросервиса SocialNetworks
        /// </remarks>
        public GetExtendedChurchHandlerCommentsFilter CommentsFilter { get; set; }
    }
}