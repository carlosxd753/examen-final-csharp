using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
  {
    [HttpPost]
    public async Task<IActionResult> Post([FromBody])
    {
      
    }

  }
}
