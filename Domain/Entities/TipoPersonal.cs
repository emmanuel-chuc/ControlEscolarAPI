using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipoPersonal
{
    public int TipoPersonalId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal SueldoMinimo { get; set; }

    public decimal SueldoMaximo { get; set; }

    public string? ClaveControl { get; set; }
}
