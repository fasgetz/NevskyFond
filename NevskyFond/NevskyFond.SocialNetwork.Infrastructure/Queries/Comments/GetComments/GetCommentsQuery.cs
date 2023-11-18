﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments
{
    public class GetCommentsQuery : IRequest<GetCommentsResult>
    {
        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public int? ChurchId { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}