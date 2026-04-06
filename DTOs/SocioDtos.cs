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
}
