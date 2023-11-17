using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddChurch()
        {
            return Ok(DateTime.Now);
        }
    }
}