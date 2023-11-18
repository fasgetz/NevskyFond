using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NevskyFond.SocialNetwork.Data.StoreModels.Queries;
using NevskyFond.SocialNetwork.Data.StoreModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.SocialNetwork.Data.Store.Comments
{
    /// <summary>
    /// Не паттерн репозиторий
    /// </summary>
    /// <remarks>
    /// На текущий момент в целях демонстрации реализую обычный Store
    /// </remarks>
    public class CommentsStore : ICommentsStore
    {
        private readonly SocialNetworkContext _dbContext;
        private readonly IMapper _mapper;

        public CommentsStore(SocialNetworkContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetCommentsStoreResult> GetComments(GetCommentsStoreQuery query)
        {
            var queryComments = _dbContext.Comments.AsQueryable();

            if (query.ChurchId != null)
            {
                queryComments = queryComments.Where(e => e.ChurchId == query.ChurchId);
            }

            queryComments = queryComments.OrderByDescending(e => e.Id);

            var comments = await queryComments
                .Select(e => _mapper.Map(e, new CommentStoreDTO()))
                .ToListAsync();

            var commentsResult = new GetCommentsStoreResult()
            {
                Comments = comments
            };

            return commentsResult;
        }
    }
}
