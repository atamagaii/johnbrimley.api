using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace johnbrimley.api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get() => Ok("I'm here");
    }
}

