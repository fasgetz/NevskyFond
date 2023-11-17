using AutoMapper;
using MassTransit;
using MediatR;
using NevskyFond.Portal.Infrastructure.Commands.Churches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Portal.Infrastructure.Consumers.Churches
{
    public class AddChurchConsumer : IConsumer<AddChurchConsumerRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddChurchConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddChurchConsumerRequest> context)
        {
            var command = _mapper.Map(context.Message, new AddChurchCommand());

            var addedChurchResult = await _mediator.Send(command);

            var responseConsumer = _mapper.Map(addedChurchResult, new AddChurchConsumerResponse());

            await context.RespondAsync(responseConsumer);
        }
    }
}