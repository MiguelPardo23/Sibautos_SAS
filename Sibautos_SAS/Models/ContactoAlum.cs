using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class ContactoAlum
{
    public int IdContacto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Celular { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
