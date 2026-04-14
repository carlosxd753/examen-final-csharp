using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace examen_final_csharp.Repositories
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly GimnasioDbContext _context;

        public AsistenciaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<Socio?> GetSocioById(int socioId)
        {
            return await _context.Socios.FirstOrDefaultAsync(s => s.SocioId == socioId);
        }

        public async Task<Asistencia?> GetById(int asistenciaId)
        {
            return await _context.Asistencias.FirstOrDefaultAsync(a => a.AsistenciaId == asistenciaId);
        }

        public async Task<Asistencia?> GetAsistenciaAbiertaBySocioId(int socioId)
        {
            return await _context.Asistencias
                .Where(a => a.SocioId == socioId && a.FechaHoraSalida == null)
                .OrderByDescending(a => a.FechaHoraEntrada)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EntrenadorTieneSocioAsignado(int entrenadorUserId, int socioId)
        {
            return await _context.Rutinas.AnyAsync(
                r =>
                    r.SocioId == socioId
                    && r.Activa
                    && r.Entrenador != null
                    && r.Entrenador.UserId == entrenadorUserId
            );
        }

        public async Task Add(Asistencia asistencia)
        {
            await _context.Asistencias.AddAsync(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Asistencia asistencia)
        {
            _context.Asistencias.Update(asistencia);
            await _context.SaveChangesAsync();
        }
    }
}
