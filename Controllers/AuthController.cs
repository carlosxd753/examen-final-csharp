using Microsoft.AspNetCore.Mvc;
using examen_final_csharp.DTOs;
using examen_final_csharp.Services;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.Login(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized(new { mensaje = "credenciales incorrectas" });

            return Ok(new { token });
        }
    }
}
