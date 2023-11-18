using NevskyFond.SocialNetwork.Api.Models.Requests;
using NevskyFond.SocialNetwork.Api.Models.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace NevskyFond.SocialNetwork.Api.Models.ResponseExamples
{
    public class GetCommentsResponseExample : IExamplesProvider<GetCommentsResponse>
    {
        public GetCommentsResponse GetExamples()
        {
            return new GetCommentsResponse()
            {
                Comments = new List<CommentResponseDTO>()
                {
                    new CommentResponseDTO()
                    {
                        DateCreated = DateTime.Now,
                        ChurchId = 1,
                        Id = 1,
                        Text = "Хорошо, очень хорошо!"
                    }
                }
            };
        }
    }
}