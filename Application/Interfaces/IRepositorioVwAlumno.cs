using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositorioVwAlumno 
    {
        Task<List<VwAlumno>> ObtenerPaginacionVwAlumnos(int NumeroPagina, int TotalPagina, string? NumeroControl);
    }
}
