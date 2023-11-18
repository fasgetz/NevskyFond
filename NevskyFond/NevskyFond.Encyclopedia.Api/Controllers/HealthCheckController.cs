using Microsoft.AspNetCore.Mvc;

namespace NevskyFond.Encyclopedia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }
    }
}