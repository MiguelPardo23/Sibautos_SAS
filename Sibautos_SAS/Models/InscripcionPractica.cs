using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class InscripcionPractica
{
    public int IdInscripcionP { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdVehiculo { get; set; }

    public int? IdInstructor { get; set; }

    public int? IdClaseP { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual ClasePractica? IdClasePNavigation { get; set; }

    public virtual Instructor? IdInstructorNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
