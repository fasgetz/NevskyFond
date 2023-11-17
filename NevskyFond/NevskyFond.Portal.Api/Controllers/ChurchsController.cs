using Microsoft.AspNetCore.Mvc;
using NevskyFond.Portal.Api.Models.Requests.Churchs;

namespace NevskyFond.Portal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChurchsController : ControllerBase
    {
        public ChurchsController()
        {
                
        }

        [HttpPost]
        public async Task<IActionResult> AddChurch([FromBody] AddChurchRequest request)
        {



            return Ok(DateTime.Now);
        }
    }
}