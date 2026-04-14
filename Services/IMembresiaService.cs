using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface IMembresiaService
    {
        Task<List<MembresiaDto>> GetAll();
        Task<MembresiaDto?> GetById(int id);
        Task<MembresiaDto> Create(CreateMembresiaDto dto);
        Task<bool> Update(int id, UpdateMembresiaDto dto);
        Task<bool> Delete(int id);
    }
}
