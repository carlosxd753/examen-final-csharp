using examen_final_csharp.Models;

namespace examen_final_csharp.Repositories
{
    public interface ISocioRepository
    {
        Task<List<Socio>> GetAll();
        Task<Socio?> GetById(int id);
        Task Add(Socio socio);
        Task Update(Socio socio);
        Task Delete(Socio socio);
    }
}
