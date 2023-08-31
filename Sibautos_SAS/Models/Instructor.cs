using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class Instructor
{
    public int IdInstructor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumDocumento { get; set; }

    public string? Celular { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<InscripcionPractica> InscripcionPracticas { get; set; } = new List<InscripcionPractica>();

    public virtual ICollection<InscripcionTeorica> InscripcionTeoricas { get; set; } = new List<InscripcionTeorica>();
}
