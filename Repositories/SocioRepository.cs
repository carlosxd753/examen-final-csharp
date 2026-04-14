using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace examen_final_csharp.Repositories
{
    public class SocioRepository : ISocioRepository
    {
        private readonly GimnasioDbContext _context;

        public SocioRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Socio>> GetAll()
        {
            return await _context.Socios.ToListAsync();
        }

        public async Task<Socio?> GetById(int id)
        {
            return await _context.Socios.FindAsync(id);
        }

        public async Task<Socio?> GetByUserId(int userId)
        {
            return await _context.Socios
                .Include(s => s.Rutinas)
                .Include(s => s.Asistencia)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<List<Socio>> GetAssignedSociosByEntrenadorUserId(int entrenadorUserId)
        {
            return await _context.Socios
                .Include(s => s.User)
                .Include(
                    s =>
                        s.Rutinas.Where(
                            r =>
                                r.Activa
                                && r.Entrenador != null
                                && r.Entrenador.UserId == entrenadorUserId
                        )
                )
                .Where(
                    s =>
                        s.Rutinas.Any(
                            r =>
                                r.Activa
                                && r.Entrenador != null
                                && r.Entrenador.UserId == entrenadorUserId
                        )
                )
                .ToListAsync();
        }

        public async Task Add(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Socio socio)
        {
            _context.Socios.Update(socio);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Socio socio)
        {
            _context.Socios.Remove(socio);
            await _context.SaveChangesAsync();
        }
    }
}
