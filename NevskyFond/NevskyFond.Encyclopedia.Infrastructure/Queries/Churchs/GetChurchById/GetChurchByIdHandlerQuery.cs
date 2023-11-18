using MediatR;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById
{
    public class GetChurchByIdHandlerQuery : IRequest<GetChurchByIdHandlerResult>
    {
        public int Id { get; set; }
    }
}
