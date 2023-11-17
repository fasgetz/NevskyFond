using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Infrastructure.Commands.Churches
{
    public class AddChurchCommandHandler : IRequestHandler<AddChurchCommand, AddChurchCommandResult>
    {
        public async Task<AddChurchCommandResult> Handle(AddChurchCommand request, CancellationToken cancellationToken)
        {

            var sadfasd = 23423;

            return new AddChurchCommandResult()
            {
                Id = 123,
                DateCreation = request.DateCreation,
                Name = request.Name
            };
        }
    }
}
