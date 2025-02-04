using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Password { get; set; }

    public int? Activo { get; set; }

    public string? Rol { get; set; }
}
