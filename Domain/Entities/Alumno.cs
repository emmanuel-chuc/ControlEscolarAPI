using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Alumno
{
    public int AlumnoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string NumeroControl { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public bool Estatus { get; set; }

    public int TipoPersonalId { get; set; }
}
