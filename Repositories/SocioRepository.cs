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
