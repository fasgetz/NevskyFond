using Microsoft.AspNetCore.Mvc;

namespace NevskyFond.Encyclopedia.Api.Models.Requests.Churchs
{
    /// <summary>
    /// Фильтр для получения комментариев
    /// </summary>
    public class GetExtendedChurchRequestCommentsFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    /// <summary>
    /// Запрос на получение расширенной информации по религиозному учреждению
    /// </summary>
    public class GetExtendedChurchRequest
    {
        /// <summary>
        /// Фильтр комментариев
        /// </summary>
        /// <remarks>
        /// Если заполнен, то будут дополнительно получаться данные из микросервиса SocialNetworks
        /// </remarks>
        public GetExtendedChurchRequestCommentsFilter CommentsFilter { get; set; }
    }
}
