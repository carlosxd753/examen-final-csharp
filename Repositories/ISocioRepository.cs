using examen_final_csharp.Models;

namespace examen_final_csharp.Repositories
{
    public interface ISocioRepository
    {
        Task<List<Socio>> GetAll();
        Task<Socio?> GetById(int id);
        Task<Socio?> GetByUserId(int userId);
        Task<List<Socio>> GetAssignedSociosByEntrenadorUserId(int entrenadorUserId);
        Task Add(Socio socio);
        Task Update(Socio socio);
        Task Delete(Socio socio);
    }
}
