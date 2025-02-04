using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositorioVwPersonal
    {
        Task<List<VwPersonal>> ObtenerPaginacionVwPersonal(int NumeroPagina, int TotalPagina, string? NumeroControl);
    }
}
