using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch
{
    public class AddChurchCommand : IRequest<AddChurchCommandResult>
    {
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