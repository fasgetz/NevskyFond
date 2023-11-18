using AutoMapper;
using MassTransit;
using MediatR;
using NevskyFond.Encyclopedia.Data.Store.Church;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using NevskyFond.SocialNetwork.Communication.Client;
using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Requests.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Responses.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch
{
    public class GetExtendedChurchHandler : IRequestHandler<GetExtendedChurchHandlerQuery, GetExtendedChurchHandlerResult>
    {
        private readonly IMapper _mapper;
        private readonly IChurchStore _churchStore;
        private readonly ISocialNetworkClient _socialNetworkClient;
        private readonly IRequestClient<GetCommentsConsumerRequest> _getCommentsClient;

        public GetExtendedChurchHandler(IMapper mapper, IChurchStore churchStore, ISocialNetworkClient socialNetworkClient)
        {
            _mapper = mapper;
            _churchStore = churchStore;
            _socialNetworkClient = socialNetworkClient;
        }

        private async Task<IEnumerable<CommentResultHandlerDTO>> GetCommentsAsync(GetExtendedChurchHandlerQuery request)
        {
            var getCommentsQuery = _mapper.Map<GetExtendedChurchHandlerQuery, GetCommentsQuery>(request);

            var commentsResult = await _socialNetworkClient.Comments.GetCommentsAsync(getCommentsQuery);

            return commentsResult.Comments.Select(e => _mapper.Map(e, new CommentResultHandlerDTO()));
        }

        public async Task<GetExtendedChurchHandlerResult> Handle(GetExtendedChurchHandlerQuery request, CancellationToken cancellationToken)
        {
            var queryStore = _mapper.Map(request, new GetChurchByIdStoreQuery());

            var foundChurchResult = await _churchStore.GetChurchByIdAsync(queryStore);

            if (foundChurchResult.Church == null)
            {
                // TODO вернуть кастомную ошибку, что не найдено религиозное учреждение

                return null;
            }

            var result = _mapper.Map(foundChurchResult, new GetExtendedChurchHandlerResult());

            // Получение комментариев религиозного учреждения
            if (request.CommentsFilter != null)
            {
                var comments = await GetCommentsAsync(request);

                result.Comments = comments;
            }

            return result;
        }
    }
}