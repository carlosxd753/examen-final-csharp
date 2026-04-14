using examen_final_csharp.DTOs;
using examen_final_csharp.Models;
using examen_final_csharp.Repositories;

namespace examen_final_csharp.Services
{
    public class EntrenadorService : IEntrenadorService
    {
        private readonly IEntrenadorRepository _repo;

        public EntrenadorService(IEntrenadorRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EntrenadorDto>> GetAll()
        {
            var entrenadores = await _repo.GetAll();

            return entrenadores
                .Select(
                    e =>
                        new EntrenadorDto
                        {
                            EntrenadorId = e.EntrenadorId,
                            UserId = e.UserId,
                            Especialidad = e.Especialidad,
                            Certificaciones = e.Certificaciones,
                            FechaIngreso = e.FechaIngreso,
                            IsActive = e.IsActive
                        }
                )
                .ToList();
        }

        public async Task<EntrenadorDto?> GetById(int id)
        {
            var entrenador = await _repo.GetById(id);

            if (entrenador == null)
            {
                return null;
            }

            return new EntrenadorDto
            {
                EntrenadorId = entrenador.EntrenadorId,
                UserId = entrenador.UserId,
                Especialidad = entrenador.Especialidad,
                Certificaciones = entrenador.Certificaciones,
                FechaIngreso = entrenador.FechaIngreso,
                IsActive = entrenador.IsActive
            };
        }

        public async Task<EntrenadorDto> Create(CreateEntrenadorDto dto)
        {
            var entrenador = new Entrenadore
            {
                UserId = dto.UserId,
                Especialidad = dto.Especialidad,
                Certificaciones = dto.Certificaciones,
                FechaIngreso = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = true
            };

            await _repo.Add(entrenador);

            return new EntrenadorDto
            {
                EntrenadorId = entrenador.EntrenadorId,
                UserId = entrenador.UserId,
                Especialidad = entrenador.Especialidad,
                Certificaciones = entrenador.Certificaciones,
                FechaIngreso = entrenador.FechaIngreso,
                IsActive = entrenador.IsActive
            };
        }

        public async Task<bool> Update(int id, UpdateEntrenadorDto dto)
        {
            var entrenador = await _repo.GetById(id);

            if (entrenador == null)
            {
                return false;
            }

            entrenador.Especialidad = dto.Especialidad;
            entrenador.Certificaciones = dto.Certificaciones;
            entrenador.IsActive = dto.IsActive;

            await _repo.Update(entrenador);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entrenador = await _repo.GetById(id);

            if (entrenador == null)
            {
                return false;
            }

            await _repo.Delete(entrenador);
            return true;
        }
    }
}
