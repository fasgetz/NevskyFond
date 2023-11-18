using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Models.Requests.Comments
{
    internal class GetCommentsConsumerRequest
    {
        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public int? CharityId { get; set; }
    }
}