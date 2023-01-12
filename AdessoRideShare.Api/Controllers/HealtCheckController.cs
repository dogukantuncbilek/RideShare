using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealtCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealtCheck()
        {
            return Ok(new { ping = "pong", date = DateTime.Now });
        }
    }
}
