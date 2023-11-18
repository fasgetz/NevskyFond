using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.StoreModels.Church.Results
{
    public class GetChurchByIdStoreDTO
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

    public class GetChurchByIdStoreResult
    {
        public GetChurchByIdStoreDTO Church { get; set; }
    }
}
