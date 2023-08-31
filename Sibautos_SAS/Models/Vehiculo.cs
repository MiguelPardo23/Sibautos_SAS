using System;
using System.Collections.Generic;

namespace Sibautos_SAS.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? TipoVehiculo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string? Placa { get; set; }

    public virtual ICollection<InscripcionPractica> InscripcionPracticas { get; set; } = new List<InscripcionPractica>();
}
