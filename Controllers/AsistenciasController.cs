using examen_final_csharp.DTOs;
using examen_final_csharp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaService _service;

        public AsistenciasController(IAsistenciaService service)
        {
            _service = service;
        }

        [HttpPost("entrada")]
        [Authorize(Roles = "ENTRENADOR")]
        public async Task<ActionResult> RegistrarEntrada(CreateAsistenciaEntradaDto dto)
        {
            var userId = User.FindFirst("id")?.Value;

            if (userId == null)
            {
                return Unauthorized(new { mensaje = "token no contiene id" });
            }

            var asistencia = await _service.RegistrarEntrada(dto, int.Parse(userId));

            if (asistencia == null)
            {
                return BadRequest(
                    new
                    {
                        mensaje =
                            "el socio no existe, ya tiene una asistencia abierta o no está asignado a este entrenador"
                    }
                );
            }

            return Ok(asistencia);
        }

        [HttpPut("{id:int}/salida")]
        [Authorize(Roles = "ENTRENADOR")]
        public async Task<ActionResult> RegistrarSalida(int id, RegistrarSalidaAsistenciaDto dto)
        {
            var userId = User.FindFirst("id")?.Value;

            if (userId == null)
            {
                return Unauthorized(new { mensaje = "token no contiene id" });
            }

            var asistencia = await _service.RegistrarSalida(id, dto, int.Parse(userId));

            if (asistencia == null)
            {
                return BadRequest(
                    new
                    {
                        mensaje =
                            "la asistencia no existe, ya tiene salida registrada o el socio no está asignado a este entrenador"
                    }
                );
            }

            return Ok(asistencia);
        }
    }
}
