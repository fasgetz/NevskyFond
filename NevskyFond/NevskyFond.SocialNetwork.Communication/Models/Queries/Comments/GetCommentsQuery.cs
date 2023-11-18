using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Models.Queries.Comments
{
    public class GetCommentsQuery
    {
        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public int? CharityId { get; set; }
    }
}
