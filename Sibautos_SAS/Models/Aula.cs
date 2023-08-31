using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public int? Capacidad { get; set; }

    public string? Equipamento { get; set; }

    public virtual ICollection<InscripcionTeorica> InscripcionTeoricas { get; set; } = new List<InscripcionTeorica>();
}
