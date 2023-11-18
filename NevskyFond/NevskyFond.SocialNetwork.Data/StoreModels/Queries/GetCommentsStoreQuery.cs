using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.StoreModels.Queries
{
    public class GetCommentsStoreQuery
    {
        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public long ChurchId { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}