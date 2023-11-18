using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using NevskyFond.Encyclopedia.Api.Models.Responses.Churchs;
using Swashbuckle.AspNetCore.Filters;

namespace NevskyFond.Encyclopedia.Api.Models.ResponseExamples
{
    public class GetExtendedChurchResponseExample : IExamplesProvider<GetExtendedChurchResponse>
    {
        public GetExtendedChurchResponse GetExamples()
        {
            return new GetExtendedChurchResponse()
            {
                Church = new GetExtendedChurchResponseDTO()
                {
                    CityId = 1,
                    DateCreation = DateTime.Now,
                    Id = 1,
                    Name = "Храм Христа Спасителя"
                },
                Comments = new List<CommentResponseDTO>()
                {
                    new CommentResponseDTO()
                    {
                        DateCreated = DateTime.Now,
                        Id = 1,
                        Text = "Хороший комментарий"
                    },
                    new CommentResponseDTO()
                    {
                        DateCreated = DateTime.Now,
                        Id = 2,
                        Text = "Средний комментарий"
                    }
                }
            };
        }
    }
}