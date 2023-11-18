using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById
{
    public class ChurchHandlerDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreation { get; set; }

        public int CityId { get; set; }
    }

    public class GetChurchByIdHandlerResult
    {
        public ChurchHandlerDTO Church { get; set; }
    }
}
