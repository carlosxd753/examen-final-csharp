namespace examen_final_csharp.DTOs
{
    public class EntrenadorDto
    {
        public int EntrenadorId { get; set; }
        public int UserId { get; set; }
        public string? Especialidad { get; set; }
        public string? Certificaciones { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateEntrenadorDto
    {
        public int UserId { get; set; }
        public string? Especialidad { get; set; }
        public string? Certificaciones { get; set; }
    }

    public class UpdateEntrenadorDto
    {
        public string? Especialidad { get; set; }
        public string? Certificaciones { get; set; }
        public bool IsActive { get; set; }
    }
}
