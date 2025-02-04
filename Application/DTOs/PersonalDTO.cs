using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PersonalDTO
    {
        public int PersonalId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string NumeroControl { get; set; } = null!;
        public bool Estatus { get; set; }
        public int TipoPersonalId { get; set; }
        public decimal Sueldo { get; set; }
    }
}
