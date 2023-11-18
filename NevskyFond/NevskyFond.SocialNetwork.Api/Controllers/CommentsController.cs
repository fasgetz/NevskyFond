using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NevskyFond.SocialNetwork.Api.Models.Requests;
using NevskyFond.SocialNetwork.Api.Models.Responses;
using NevskyFond.SocialNetwork.Data.Store.Comments;
using NevskyFond.SocialNetwork.Infrastructure.Queries.Comments.GetComments;

namespace NevskyFond.SocialNetwork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICommentsStore commentsStore;

        public CommentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetCommentsResponse>> GetComments([FromQuery] GetCommentsRequest request)
        {
            var query = _mapper.Map(request, new GetCommentsQuery());

            var getCommentsResult = await _mediator.Send(query);

            var commentsMapped = getCommentsResult.Comments.Select(e => _mapper.Map(e, new CommentResponseDTO()));

            var response = new GetCommentsResponse()
            {
                Comments = commentsMapped
            };

            return Ok(response);
        }
    }
}
