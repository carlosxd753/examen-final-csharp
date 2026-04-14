using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface IAsistenciaService
    {
        Task<AsistenciaDto?> RegistrarEntrada(CreateAsistenciaEntradaDto dto, int registradaPorUserId);
        Task<AsistenciaDto?> RegistrarSalida(
            int asistenciaId,
            RegistrarSalidaAsistenciaDto dto,
            int registradaPorUserId
        );
    }
}
