using System;
using System.Collections.Generic;

namespace examen_final_csharp.Models;

public partial class VSocioUltimaMembresium
{
    public int SocioId { get; set; }

    public int MembresiaId { get; set; }

    public string Membresia { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }
}
