using examen_final_csharp.DTOs;
using examen_final_csharp.Models;
using examen_final_csharp.Repositories;

namespace examen_final_csharp.Services
{
    public class MembresiaService : IMembresiaService
    {
        private readonly IMembresiaRepository _repo;

        public MembresiaService(IMembresiaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MembresiaDto>> GetAll()
        {
            var membresias = await _repo.GetAll();

            return membresias
                .Select(
                    m =>
                        new MembresiaDto
                        {
                            MembresiaId = m.MembresiaId,
                            Nombre = m.Nombre,
                            Descripcion = m.Descripcion,
                            DuracionDias = m.DuracionDias,
                            Precio = m.Precio,
                            EsRenovable = m.EsRenovable,
                            IsActive = m.IsActive,
                            CreatedAt = m.CreatedAt
                        }
                )
                .ToList();
        }

        public async Task<MembresiaDto?> GetById(int id)
        {
            var membresia = await _repo.GetById(id);

            if (membresia == null)
            {
                return null;
            }

            return new MembresiaDto
            {
                MembresiaId = membresia.MembresiaId,
                Nombre = membresia.Nombre,
                Descripcion = membresia.Descripcion,
                DuracionDias = membresia.DuracionDias,
                Precio = membresia.Precio,
                EsRenovable = membresia.EsRenovable,
                IsActive = membresia.IsActive,
                CreatedAt = membresia.CreatedAt
            };
        }

        public async Task<MembresiaDto> Create(CreateMembresiaDto dto)
        {
            var membresia = new Membresia
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                DuracionDias = dto.DuracionDias,
                Precio = dto.Precio,
                EsRenovable = dto.EsRenovable,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.Add(membresia);

            return new MembresiaDto
            {
                MembresiaId = membresia.MembresiaId,
                Nombre = membresia.Nombre,
                Descripcion = membresia.Descripcion,
                DuracionDias = membresia.DuracionDias,
                Precio = membresia.Precio,
                EsRenovable = membresia.EsRenovable,
                IsActive = membresia.IsActive,
                CreatedAt = membresia.CreatedAt
            };
        }

        public async Task<bool> Update(int id, UpdateMembresiaDto dto)
        {
            var membresia = await _repo.GetById(id);

            if (membresia == null)
            {
                return false;
            }

            membresia.Nombre = dto.Nombre;
            membresia.Descripcion = dto.Descripcion;
            membresia.DuracionDias = dto.DuracionDias;
            membresia.Precio = dto.Precio;
            membresia.EsRenovable = dto.EsRenovable;
            membresia.IsActive = dto.IsActive;

            await _repo.Update(membresia);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var membresia = await _repo.GetById(id);

            if (membresia == null)
            {
                return false;
            }

            await _repo.Delete(membresia);
            return true;
        }
    }
}
