using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumDocumento { get; set; }

    public string? Celular { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public int? IdContacto { get; set; }

    public int? IdCurso { get; set; }

    public virtual ContactoAlum? IdContactoNavigation { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual ICollection<InscripcionPractica> InscripcionPracticas { get; set; } = new List<InscripcionPractica>();

    public virtual InscripcionTeorica? InscripcionTeorica { get; set; }
}
