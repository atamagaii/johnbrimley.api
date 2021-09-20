using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace johnbrimley.api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery(Name ="token")] string token)
        {
            return Ok();
        }
    }
}
