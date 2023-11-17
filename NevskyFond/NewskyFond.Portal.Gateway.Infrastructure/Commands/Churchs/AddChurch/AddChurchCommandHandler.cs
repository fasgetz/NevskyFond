using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch
{
    public class AddChurchCommandHandler : IRequestHandler<AddChurchCommand, AddChurchResult>
    {
        public async Task<AddChurchResult> Handle(AddChurchCommand request, CancellationToken cancellationToken)
        {

            var sadfasd = 23423;

            return new AddChurchResult()
            {
                Id = 123,
                DateCreation = request.DateCreation,
                Name = request.Name
            };
        }
    }
}
