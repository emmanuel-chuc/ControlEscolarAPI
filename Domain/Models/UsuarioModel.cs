using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; } 
        public string Nombre { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string AccesoToken { get; set; } = null!;
    }
}
