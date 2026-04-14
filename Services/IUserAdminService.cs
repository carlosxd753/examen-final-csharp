using examen_final_csharp.DTOs;

namespace examen_final_csharp.Services
{
    public interface IUserAdminService
    {
        Task<UserCreationResultDto> CreateUserWithSocio(CreateUserWithSocioDto dto);
        Task<UserCreationResultDto> CreateUserWithEntrenador(CreateUserWithEntrenadorDto dto);
    }
}
