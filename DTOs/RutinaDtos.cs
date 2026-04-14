namespace examen_final_csharp.DTOs
{
    public class RutinaDto
    {
        public int RutinaId { get; set; }
        public int SocioId { get; set; }
        public int? EntrenadorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Objetivo { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public bool Activa { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
