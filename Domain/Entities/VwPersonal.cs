using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VwPersonal
{
    public string? NombreCompleto { get; set; }

    public string? NumeroControl { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Sueldo { get; set; }
}
