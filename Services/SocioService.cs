using examen_final_csharp.DTOs;
using examen_final_csharp.Models;
using examen_final_csharp.Repositories;

namespace examen_final_csharp.Services
{
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _repo;

        public SocioService(ISocioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SocioDto>> GetAll()
        {
            var socios = await _repo.GetAll();

            return socios
                .Select(
                    s =>
                        new SocioDto
                        {
                            SocioId = s.SocioId,
                            UserId = s.UserId,
                            FechaNacimiento = s.FechaNacimiento,
                            Genero = s.Genero,
                            AlturaCm = s.AlturaCm,
                            PesoKg = s.PesoKg,
                            EmergenciaNombre = s.EmergenciaNombre,
                            EmergenciaTelefono = s.EmergenciaTelefono,
                            FechaRegistro = s.FechaRegistro,
                            IsActive = s.IsActive
                        }
                )
                .ToList();
        }

        public async Task<SocioDto?> GetById(int id)
        {
            var s = await _repo.GetById(id);
            if (s == null)
                return null;

            return new SocioDto
            {
                SocioId = s.SocioId,
                UserId = s.UserId,
                FechaNacimiento = s.FechaNacimiento,
                Genero = s.Genero,
                AlturaCm = s.AlturaCm,
                PesoKg = s.PesoKg,
                EmergenciaNombre = s.EmergenciaNombre,
                EmergenciaTelefono = s.EmergenciaTelefono,
                FechaRegistro = s.FechaRegistro,
                IsActive = s.IsActive
            };
        }

        public async Task<SocioDto> Create(CreateSocioDto dto)
        {
            var socio = new Socio
            {
                UserId = dto.UserId,
                FechaNacimiento = dto.FechaNacimiento,
                Genero = dto.Genero,
                AlturaCm = dto.AlturaCm,
                PesoKg = dto.PesoKg,
                EmergenciaNombre = dto.EmergenciaNombre,
                EmergenciaTelefono = dto.EmergenciaTelefono,
                FechaRegistro = DateOnly.FromDateTime(DateTime.UtcNow),
                IsActive = true
            };

            await _repo.Add(socio);

            return new SocioDto
            {
                SocioId = socio.SocioId,
                UserId = socio.UserId,
                FechaNacimiento = socio.FechaNacimiento,
                Genero = socio.Genero,
                AlturaCm = socio.AlturaCm,
                PesoKg = socio.PesoKg,
                EmergenciaNombre = socio.EmergenciaNombre,
                EmergenciaTelefono = socio.EmergenciaTelefono,
                FechaRegistro = socio.FechaRegistro,
                IsActive = socio.IsActive
            };
        }

        public async Task<bool> Update(int id, UpdateSocioDto dto)
        {
            var socio = await _repo.GetById(id);
            if (socio == null)
                return false;

            socio.FechaNacimiento = dto.FechaNacimiento;
            socio.Genero = dto.Genero;
            socio.AlturaCm = dto.AlturaCm;
            socio.PesoKg = dto.PesoKg;
            socio.EmergenciaNombre = dto.EmergenciaNombre;
            socio.EmergenciaTelefono = dto.EmergenciaTelefono;
            socio.IsActive = dto.IsActive;

            await _repo.Update(socio);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var socio = await _repo.GetById(id);
            if (socio == null)
                return false;

            await _repo.Delete(socio);
            return true;
        }
    }
}
