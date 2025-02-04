using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personal
{
    public int PersonalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? CorreoElectronico { get; set; }

    public string? NumeroControl { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public bool? Estatus { get; set; }

    public int? TipoPersonalId { get; set; }

    public decimal Sueldo { get; set; }
}
