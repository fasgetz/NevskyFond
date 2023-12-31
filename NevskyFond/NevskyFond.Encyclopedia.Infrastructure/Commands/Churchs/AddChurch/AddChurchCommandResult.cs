﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch
{
    public class AddChurchCommandResult
    {
        /// <summary>
        /// ID религиозного учреждения
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
    }
}
