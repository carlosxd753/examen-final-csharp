namespace examen_final_csharp.DTOs
{
    public class SocioDto
    {
        public int SocioId { get; set; }
        public int UserId { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public decimal? AlturaCm { get; set; }
        public decimal? PesoKg { get; set; }
        public string? EmergenciaNombre { get; set; }
        public string? EmergenciaTelefono { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateSocioDto
    {
        public int UserId { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public decimal? AlturaCm { get; set; }
        public decimal? PesoKg { get; set; }
        public string? EmergenciaNombre { get; set; }
        public string? EmergenciaTelefono { get; set; }
    }

    public class UpdateSocioDto
    {
        public DateOnly? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public decimal? AlturaCm { get; set; }
        public decimal? PesoKg { get; set; }
        public string? EmergenciaNombre { get; set; }
        public string? EmergenciaTelefono { get; set; }
        public bool IsActive { get; set; }
    }

    public class SocioAsignadoDto
    {
        public int SocioId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public int RutinaId { get; set; }
        public string NombreRutina { get; set; } = null!;
        public string? ObjetivoRutina { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public bool RutinaActiva { get; set; }
    }
}
