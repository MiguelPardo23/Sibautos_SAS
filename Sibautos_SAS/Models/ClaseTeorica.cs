using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class ClaseTeorica
{
    public int IdClaseT { get; set; }

    public string? Tema { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public virtual ICollection<InscripcionTeorica> InscripcionTeoricas { get; set; } = new List<InscripcionTeorica>();
}
