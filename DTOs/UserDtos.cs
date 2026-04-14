namespace examen_final_csharp.DTOs
{
    public class CreateUserWithSocioDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public decimal? AlturaCm { get; set; }
        public decimal? PesoKg { get; set; }
        public string? EmergenciaNombre { get; set; }
        public string? EmergenciaTelefono { get; set; }
    }

    public class CreateUserWithEntrenadorDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Especialidad { get; set; }
        public string? Certificaciones { get; set; }
    }

    public class UserCreationResultDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int? SocioId { get; set; }
        public int? EntrenadorId { get; set; }
    }
}
