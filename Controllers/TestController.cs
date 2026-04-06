using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("publico")]
        public IActionResult Publico()
        {
            return Ok("ruta publica OK");
        }

        [Authorize]
        [HttpGet("debug")]
        public IActionResult Debug()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });

            return Ok(claims);
        }
    }
}
