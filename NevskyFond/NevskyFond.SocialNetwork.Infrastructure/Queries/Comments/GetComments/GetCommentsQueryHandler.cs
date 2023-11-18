using AutoMapper;
using MediatR;
using NevskyFond.SocialNetwork.Data.Store.Comments;
using NevskyFond.SocialNetwork.Data.StoreModels.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, GetCommentsResult>
    {
        private readonly IMapper _mapper;
        private readonly ICommentsStore _commentsStore;

        public GetCommentsQueryHandler(IMapper mapper, ICommentsStore commentsStore)
        {
            _mapper = mapper;
            _commentsStore = commentsStore;
        }

        public async Task<GetCommentsResult> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map(request, new GetCommentsStoreQuery());

            var commentsResult = await _commentsStore.GetComments(query);

            var commentsMapped = commentsResult.Comments.Select(e => _mapper.Map(e, new CommentDTO()));

            return new GetCommentsResult()
            {
                Comments = commentsMapped
            };
        }
    }
}
