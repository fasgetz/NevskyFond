using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using Swashbuckle.AspNetCore.Filters;

namespace NevskyFond.Encyclopedia.Api.Models.RequestExamples.Churchs
{
    public class GetExtendedChurchRequestExample : IExamplesProvider<GetExtendedChurchRequest>
    {
        public GetExtendedChurchRequest GetExamples()
        {
            return new GetExtendedChurchRequest()
            {
                CommentsFilter = new GetExtendedChurchRequestCommentsFilter()
                {
                    PageSize = 10,
                    PageNumber = 1
                }
            };
        }
    }
}