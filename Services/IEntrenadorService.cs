using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface IEntrenadorService
    {
        Task<List<EntrenadorDto>> GetAll();
        Task<EntrenadorDto?> GetById(int id);
        Task<EntrenadorDto> Create(CreateEntrenadorDto dto);
        Task<bool> Update(int id, UpdateEntrenadorDto dto);
        Task<bool> Delete(int id);
    }
}
