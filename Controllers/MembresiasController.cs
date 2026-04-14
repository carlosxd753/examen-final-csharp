using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using examen_final_csharp.DTOs;
using examen_final_csharp.Services;

namespace examen_final_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembresiasController : ControllerBase
    {
        private readonly IMembresiaService _service;

        public MembresiasController(IMembresiaService service)
        {
            _service = service;
        }

        // GET: api/membresias
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetAll()
        {
            var membresias = await _service.GetAll();
            return Ok(membresias);
        }

        // GET: api/membresias/5
        [HttpGet("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> GetById(int id)
        {
            var membresia = await _service.GetById(id);

            if (membresia == null)
                return NotFound(new { mensaje = "membresía no encontrada" });

            return Ok(membresia);
        }

        // POST: api/membresias
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Create(CreateMembresiaDto dto)
        {
            var nuevaMembresia = await _service.Create(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = nuevaMembresia.MembresiaId },
                nuevaMembresia
            );
        }

        // PUT: api/membresias/5
        [HttpPut("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Update(int id, UpdateMembresiaDto dto)
        {
            var ok = await _service.Update(id, dto);

            if (!ok)
                return NotFound(new { mensaje = "membresía no encontrada" });

            return Ok(new { mensaje = "membresía actualizada correctamente" });
        }

        // DELETE: api/membresias/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.Delete(id);

            if (!ok)
                return NotFound(new { mensaje = "membresía no encontrada" });

            return Ok(new { mensaje = "membresía eliminada correctamente" });
        }
    }
}
