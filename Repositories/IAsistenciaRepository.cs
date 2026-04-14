using examen_final_csharp.Models;

namespace examen_final_csharp.Repositories
{
    public interface IAsistenciaRepository
    {
        Task<Socio?> GetSocioById(int socioId);
        Task<Asistencia?> GetById(int asistenciaId);
        Task<Asistencia?> GetAsistenciaAbiertaBySocioId(int socioId);
        Task<bool> EntrenadorTieneSocioAsignado(int entrenadorUserId, int socioId);
        Task Add(Asistencia asistencia);
        Task Update(Asistencia asistencia);
    }
}
