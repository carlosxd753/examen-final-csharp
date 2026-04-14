using examen_final_csharp.DTOs;
using examen_final_csharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserAdminService _service;

        public UserController(IUserAdminService service)
        {
            _service = service;
        }

        [HttpPost("socio")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> CreateUserWithSocio(CreateUserWithSocioDto dto)
        {
            try
            {
                var result = await _service.CreateUserWithSocio(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("entrenador")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> CreateUserWithEntrenador(CreateUserWithEntrenadorDto dto)
        {
            try
            {
                var result = await _service.CreateUserWithEntrenador(dto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
