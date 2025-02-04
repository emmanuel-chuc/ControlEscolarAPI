using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositorios
{
    public class RepositorioVwPersonal : IRepositorioVwPersonal
    {
        private readonly ControlEscolarDbContext _controlEscolarDBContext;

        public RepositorioVwPersonal(ControlEscolarDbContext controlEscolarDBContext)
        {
            _controlEscolarDBContext = controlEscolarDBContext;
        }
        /// <summary>
        /// Obtiene una lista paginada de registros de la vista <see cref="VwPersonal"/>.
        /// </summary>
        /// <param name="NumeroPagina">El número de la página a recuperar (base 1).</param>
        /// <param name="TotalPagina">La cantidad de registros a incluir en cada página.</param>
        /// <param name="NumeroControl">
        /// Un filtro opcional que especifica el número de control para buscar.
        /// Si se proporciona, se filtran los resultados para incluir únicamente los registros que coincidan.
        /// </param>
        /// <returns>
        /// Una lista de objetos <see cref="VwPersonal"/> que cumple con los criterios de paginación y filtro.
        /// </returns>
        public async Task<List<VwPersonal>> ObtenerPaginacionVwPersonal(int NumeroPagina, int TotalPagina, string? NumeroControl)
        {
            var query = _controlEscolarDBContext.VwPersonals.AsQueryable();

            if (!string.IsNullOrEmpty(NumeroControl))
            {
                query = query.Where(vwP => vwP.NumeroControl == NumeroControl);
            }

            var listado = await query
                .Skip((NumeroPagina - 1) * TotalPagina)
                .Take(TotalPagina)
                .ToListAsync();

            return listado;
        }
    }
}
