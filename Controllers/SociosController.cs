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
        [HttpGet("{id}")]
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
    }
}
