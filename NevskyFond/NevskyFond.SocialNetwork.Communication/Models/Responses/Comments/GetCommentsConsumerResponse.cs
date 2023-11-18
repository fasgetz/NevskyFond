using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Models.Responses.Comments
{
    internal class GetCommentsConsumerResponse
    {
        internal IEnumerable<CommentResponseDTO> Comments { get; set; }
    }

    internal class CommentResponseDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int Id { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        internal string Text { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        internal DateTime DateCreated { get; set; }

        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        internal int ChurchId { get; set; }
    }
}
