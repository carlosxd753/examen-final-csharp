using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace examen_final_csharp.Repositories
{
    public class EntrenadorRepository : IEntrenadorRepository
    {
        private readonly GimnasioDbContext _context;

        public EntrenadorRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entrenadore>> GetAll()
        {
            return await _context.Entrenadores.ToListAsync();
        }

        public async Task<Entrenadore?> GetById(int id)
        {
            return await _context.Entrenadores.FindAsync(id);
        }

        public async Task Add(Entrenadore entrenador)
        {
            await _context.Entrenadores.AddAsync(entrenador);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Entrenadore entrenador)
        {
            _context.Entrenadores.Update(entrenador);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Entrenadore entrenador)
        {
            _context.Entrenadores.Remove(entrenador);
            await _context.SaveChangesAsync();
        }
    }
}
