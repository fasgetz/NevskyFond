using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch
{
    public class AddChurchCommandHandler : IRequestHandler<AddChurchCommand, AddChurchCommandResult>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public AddChurchCommandHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }


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
