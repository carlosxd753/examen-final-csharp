using examen_final_csharp.Models;

namespace examen_final_csharp.Repositories
{
    public interface IEntrenadorRepository
    {
        Task<List<Entrenadore>> GetAll();
        Task<Entrenadore?> GetById(int id);
        Task Add(Entrenadore entrenador);
        Task Update(Entrenadore entrenador);
        Task Delete(Entrenadore entrenador);
    }
}
