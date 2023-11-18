using AutoMapper;
using MassTransit;
using MediatR;
using NevskyFond.SocialNetwork.Communication.Models.Requests.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Responses.Comments;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NevskyFond.SocialNetwork.Infrastructure.Consumers.Comments
{
    public class GetCommentsConsumer : IConsumer<GetCommentsConsumerRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCommentsConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task Consume(ConsumeContext<GetCommentsConsumerRequest> context)
        {
            var query = _mapper.Map(context.Message, new GetCommentsQuery());

            var getCommentsResult = await _mediator.Send(query);

            var responseConsumer = _mapper.Map(getCommentsResult, new GetCommentsConsumerResponse());

            await context.RespondAsync(responseConsumer);
        }
    }
}