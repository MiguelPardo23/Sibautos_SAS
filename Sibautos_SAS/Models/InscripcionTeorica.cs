using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class InscripcionTeorica
{
    public int IdInscripcionT { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdAula { get; set; }

    public int? IdClase { get; set; }

    public int? IdInstructor { get; set; }

    public int? IdClaseT { get; set; }

    public virtual Aula? IdAulaNavigation { get; set; }

    public virtual ClaseTeorica? IdClaseTNavigation { get; set; }

    public virtual Alumno IdInscripcionTNavigation { get; set; } = null!;

    public virtual Instructor? IdInstructorNavigation { get; set; }
}
