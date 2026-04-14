using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface ISocioService
    {
        Task<List<SocioDto>> GetAll();
        Task<List<RutinaDto>> GetRutinasByUserId(int userId);
        Task<List<AsistenciaDto>> GetAsistenciasByUserId(int userId);
        Task<List<SocioAsignadoDto>> GetAssignedSociosByEntrenadorUserId(int entrenadorUserId);
        Task<SocioDto?> GetById(int id);
        Task<SocioDto> Create(CreateSocioDto dto);
        Task<bool> Update(int id, UpdateSocioDto dto);
        Task<bool> Delete(int id);
    }
}
