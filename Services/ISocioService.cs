using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface ISocioService
    {
        Task<List<SocioDto>> GetAll();
        Task<SocioDto?> GetById(int id);
        Task<SocioDto> Create(CreateSocioDto dto);
        Task<bool> Update(int id, UpdateSocioDto dto);
        Task<bool> Delete(int id);
    }
}
