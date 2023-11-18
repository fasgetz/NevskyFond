using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Domain
{
    /// <summary>
    /// Комментарий пользователя
    /// </summary>
    /// <remarks>
    /// Ставится на религиозное учреждение
    /// </remarks>
    public class Comment
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public int ChurchId { get; set; }
    }
}
