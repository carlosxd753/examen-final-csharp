namespace examen_final_csharp.DTOs
{
    public class AsistenciaDto
    {
        public int AsistenciaId { get; set; }
        public int SocioId { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public string? Observaciones { get; set; }
        public int? RegistradaPorUserId { get; set; }
    }

    public class CreateAsistenciaEntradaDto
    {
        public int SocioId { get; set; }
        public string? Observaciones { get; set; }
    }

    public class RegistrarSalidaAsistenciaDto
    {
        public string? Observaciones { get; set; }
    }
}
