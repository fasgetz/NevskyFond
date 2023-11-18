using AutoMapper;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Requests.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Responses.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Results.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Communication.Services.Comments
{
    internal class CommentsService : ICommentsService
    {
        private readonly IMapper _mapper;
        private readonly IRequestClient<GetCommentsConsumerRequest> _getCommentsClient;

        public CommentsService(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _getCommentsClient = serviceProvider.GetRequiredService<IRequestClient<GetCommentsConsumerRequest>>();
        }

        public async Task<GetCommentsResult> GetCommentsAsync(GetCommentsQuery query)
        {
            var request = _mapper.Map(query, new GetCommentsConsumerRequest());

            var getCommentsResponse = await _getCommentsClient
                .GetResponse<GetCommentsConsumerResponse>(request, default(CancellationToken))
                .ConfigureAwait(false);

            if (getCommentsResponse.Message == null)
            {
                return null;
            }

            var result = _mapper.Map(getCommentsResponse.Message, new GetCommentsResult());

            return result;
        }
    }
}
