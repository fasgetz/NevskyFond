﻿using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetExtendedChurchHandler> _logger;

        public GetExtendedChurchHandler(IMapper mapper, IChurchStore churchStore, ISocialNetworkClient socialNetworkClient,
            ILogger<GetExtendedChurchHandler> logger)
        {
            _mapper = mapper;
            _churchStore = churchStore;
            _socialNetworkClient = socialNetworkClient;
            _logger = logger;
        }

        private async Task<IEnumerable<CommentResultHandlerDTO>> GetCommentsAsync(GetExtendedChurchHandlerQuery request)
        {
            var getCommentsQuery = _mapper.Map<GetExtendedChurchHandlerQuery, GetCommentsQuery>(request);

            var commentsResult = await _socialNetworkClient.Comments.GetCommentsAsync(getCommentsQuery);

            var comments = _mapper.Map<IEnumerable<CommentResultHandlerDTO>>(commentsResult.Comments);

            return comments;
        }

        public async Task<GetExtendedChurchHandlerResult> Handle(GetExtendedChurchHandlerQuery request, CancellationToken cancellationToken)
        {
            var queryStore = _mapper.Map(request, new GetChurchByIdStoreQuery());

            var foundChurchResult = await _churchStore.GetChurchByIdAsync(queryStore);

            if (foundChurchResult.Church == null)
            {
                // TODO вернуть кастомную ошибку, что не найдено религиозное учреждение

                _logger.LogInformation("Не найдено религиозное учреждение по ID {0}", request.Id);

                return null;
            }

            var result = _mapper.Map(foundChurchResult, new GetExtendedChurchHandlerResult());

            // Получение комментариев религиозного учреждения
            if (request.CommentsFilter != null)
            {
                var comments = await GetCommentsAsync(request);

                _logger.LogInformation("По религиозному учреждению по ID {0} получено {1} комментариев", request.Id, comments.Count());

                result.Comments = comments;
            }

            return result;
        }
    }
}