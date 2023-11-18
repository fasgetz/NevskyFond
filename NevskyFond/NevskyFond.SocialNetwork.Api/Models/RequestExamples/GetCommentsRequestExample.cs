using NevskyFond.SocialNetwork.Api.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace NevskyFond.SocialNetwork.Api.Models.RequestExamples
{
    public class GetCommentsRequestExample : IExamplesProvider<GetCommentsRequest>
    {
        public GetCommentsRequest GetExamples()
        {
            return new GetCommentsRequest()
            {
                CharityId = 1
            };
        }
    }
}
