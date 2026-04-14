using examen_final_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace examen_final_csharp.Repositories
{
    public class MembresiaRepository : IMembresiaRepository
    {
        private readonly GimnasioDbContext _context;

        public MembresiaRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task<List<Membresia>> GetAll()
        {
            return await _context.Membresias.ToListAsync();
        }

        public async Task<Membresia?> GetById(int id)
        {
            return await _context.Membresias.FindAsync(id);
        }

        public async Task Add(Membresia membresia)
        {
            await _context.Membresias.AddAsync(membresia);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Membresia membresia)
        {
            _context.Membresias.Update(membresia);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Membresia membresia)
        {
            _context.Membresias.Remove(membresia);
            await _context.SaveChangesAsync();
        }
    }
}
