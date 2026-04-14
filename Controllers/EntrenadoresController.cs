using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using examen_final_csharp.DTOs;
using examen_final_csharp.Services;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrenadoresController : ControllerBase
    {
        private readonly IEntrenadorService _service;

        public EntrenadoresController(IEntrenadorService service)
        {
            _service = service;
        }

        // GET: api/entrenadores
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetAll()
        {
            var entrenadores = await _service.GetAll();
            return Ok(entrenadores);
        }

        // GET: api/entrenadores/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetById(int id)
        {
            var entrenador = await _service.GetById(id);

            if (entrenador == null)
                return NotFound(new { mensaje = "entrenador no encontrado" });

            return Ok(entrenador);
        }

        // POST: api/entrenadores
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Create(CreateEntrenadorDto dto)
        {
            var nuevoEntrenador = await _service.Create(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = nuevoEntrenador.EntrenadorId },
                nuevoEntrenador
            );
        }

        // PUT: api/entrenadores/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Update(int id, UpdateEntrenadorDto dto)
        {
            var ok = await _service.Update(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "entrenador no encontrado" });

            return Ok(new { mensaje = "entrenador actualizado correctamente" });
        }

        // DELETE: api/entrenadores/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);

            if (!ok)
                return NotFound(new { mensaje = "entrenador no encontrado" });

            return Ok(new { mensaje = "entrenador eliminado correctamente" });
        }
    }
}
