using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using examen_final_csharp.DTOs;
using examen_final_csharp.Services;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SociosController : ControllerBase
    {
        private readonly ISocioService _service;

        public SociosController(ISocioService service)
        {
            _service = service;
        }

        // GET: api/socios
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetAll()
        {
            var socios = await _service.GetAll();
            return Ok(socios);
        }

        // GET: api/socios/5
        [HttpGet("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetById(int id)
        {
            var socio = await _service.GetById(id);

            if (socio == null)
                return NotFound(new { mensaje = "no encontrado" });

            return Ok(socio);
        }

        // PUT: api/socios/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Update(int id, UpdateSocioDto dto)
        {
            var ok = await _service.Update(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "no encontrado" });

            return Ok(new { mensaje = "actualizado" });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Create(CreateSocioDto dto)
        {
            var nuevoSocio = await _service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = nuevoSocio.SocioId }, nuevoSocio);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);

            if (!ok)
                return NotFound(new { mensaje = "no encontrado" });

            return Ok(new { mensaje = "eliminado" });
        }

        [HttpGet("mis-rutinas")]
        [Authorize]
        public async Task<IActionResult> GetMisRutinas()
        {
            var userId = User.FindFirst("id")?.Value;

            if (userId == null)
            {
                return Unauthorized(new { mensaje = "token no contiene id" });
            }

            Console.WriteLine("User ID from token: " + userId);

            var rutinas = await _service.GetRutinasByUserId(int.Parse(userId));

            if (rutinas == null || !rutinas.Any())
            {
                return NotFound(new { mensaje = "no hay rutinas para este usuario" });
            }

            return Ok(rutinas);
        }

        [HttpGet("mis-asistencias")]
        [Authorize]
        public async Task<IActionResult> GetMisAsistencias()
        {
            var userId = User.FindFirst("id")?.Value;

            if (userId == null)
            {
                return Unauthorized(new { mensaje = "token no contiene id" });
            }

            Console.WriteLine("User ID from token: " + userId);

            var asistencias = await _service.GetAsistenciasByUserId(int.Parse(userId));

            if (asistencias == null || !asistencias.Any())
            {
                return NotFound(new { mensaje = "no hay asistencias para este usuario" });
            }

            return Ok(asistencias);
        }

        [HttpGet("mis-socios-asignados")]
        [Authorize(Roles = "ENTRENADOR")]
        public async Task<IActionResult> GetMisSociosAsignados()
        {
            var userId = User.FindFirst("id")?.Value;

            if (userId == null)
            {
                return Unauthorized(new { mensaje = "token no contiene id" });
            }

            var socios = await _service.GetAssignedSociosByEntrenadorUserId(int.Parse(userId));

            if (socios == null || !socios.Any())
            {
                return NotFound(new { mensaje = "no hay socios asignados para este entrenador" });
            }

            return Ok(socios);
        }
    }
}
