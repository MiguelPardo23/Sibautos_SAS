using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class ClasePractica
{
    public int IdClaseP { get; set; }

    public string? Tema { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public virtual ICollection<InscripcionPractica> InscripcionPracticas { get; set; } = new List<InscripcionPractica>();
}
