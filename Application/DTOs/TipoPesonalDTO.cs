using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TipoPesonalDTO
    {
        public int TipoPersonalId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal SueldoMinimo { get; set; }
        public decimal SueldoMaximo { get; set; }
        public string ClaveControl { get; set; } = null!;

    }
}
