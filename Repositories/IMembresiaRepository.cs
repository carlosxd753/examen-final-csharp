using examen_final_csharp.Models;

namespace examen_final_csharp.Repositories
{
    public interface IMembresiaRepository
    {
        Task<List<Membresia>> GetAll();
        Task<Membresia?> GetById(int id);
        Task Add(Membresia membresia);
        Task Update(Membresia membresia);
        Task Delete(Membresia membresia);
    }
}
