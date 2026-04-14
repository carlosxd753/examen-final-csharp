using examen_final_csharp.DTOs;
using examen_final_csharp.Models;
using examen_final_csharp.Repositories;

namespace examen_final_csharp.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepository _repo;

        public AsistenciaService(IAsistenciaRepository repo)
        {
            _repo = repo;
        }

        public async Task<AsistenciaDto?> RegistrarEntrada(
            CreateAsistenciaEntradaDto dto,
            int registradaPorUserId
        )
        {
            var socio = await _repo.GetSocioById(dto.SocioId);

            if (socio == null)
            {
                return null;
            }

            var entrenadorTieneSocioAsignado = await _repo.EntrenadorTieneSocioAsignado(
                registradaPorUserId,
                dto.SocioId
            );

            if (!entrenadorTieneSocioAsignado)
            {
                return null;
            }

            var asistenciaAbierta = await _repo.GetAsistenciaAbiertaBySocioId(dto.SocioId);

            if (asistenciaAbierta != null)
            {
                return null;
            }

            var asistencia = new Asistencia
            {
                SocioId = dto.SocioId,
                FechaHoraEntrada = DateTime.UtcNow,
                FechaHoraSalida = null,
                Observaciones = dto.Observaciones,
                RegistradaPorUserId = registradaPorUserId
            };

            await _repo.Add(asistencia);

            return MapToDto(asistencia);
        }

        public async Task<AsistenciaDto?> RegistrarSalida(
            int asistenciaId,
            RegistrarSalidaAsistenciaDto dto,
            int registradaPorUserId
        )
        {
            var asistencia = await _repo.GetById(asistenciaId);

            if (asistencia == null || asistencia.FechaHoraSalida != null)
            {
                return null;
            }

            var entrenadorTieneSocioAsignado = await _repo.EntrenadorTieneSocioAsignado(
                registradaPorUserId,
                asistencia.SocioId
            );

            if (!entrenadorTieneSocioAsignado)
            {
                return null;
            }

            asistencia.FechaHoraSalida = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(dto.Observaciones))
            {
                asistencia.Observaciones = dto.Observaciones;
            }

            await _repo.Update(asistencia);

            return MapToDto(asistencia);
        }

        private static AsistenciaDto MapToDto(Asistencia asistencia)
        {
            return new AsistenciaDto
            {
                AsistenciaId = asistencia.AsistenciaId,
                SocioId = asistencia.SocioId,
                FechaHoraEntrada = asistencia.FechaHoraEntrada,
                FechaHoraSalida = asistencia.FechaHoraSalida,
                Observaciones = asistencia.Observaciones,
                RegistradaPorUserId = asistencia.RegistradaPorUserId
            };
        }
    }
}
