using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string? Nombre { get; set; }

    public int? HorasTeoricas { get; set; }

    public int? HorasPrecticas { get; set; }

    public int? NumDocumento { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
