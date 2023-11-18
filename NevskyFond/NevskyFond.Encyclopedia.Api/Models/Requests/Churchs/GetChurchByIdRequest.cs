using Microsoft.AspNetCore.Mvc;

namespace NevskyFond.Encyclopedia.Api.Models.Requests.Churchs
{
    public class GetChurchByIdRequest
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
