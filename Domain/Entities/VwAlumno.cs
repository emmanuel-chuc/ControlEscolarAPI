using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class VwAlumno
{
    public string? NombreCompleto { get; set; }

    public string NumeroControl { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
