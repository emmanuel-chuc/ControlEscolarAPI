using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositorios
{
    public class RepositorioVwAlumno : IRepositorioVwAlumno
    {
        private readonly ControlEscolarDbContext _controlEscolarDBContext;

        public RepositorioVwAlumno(ControlEscolarDbContext controlEscolarDBContext)
        {
            _controlEscolarDBContext = controlEscolarDBContext;
        }

        /// <summary>
        /// Obtiene una lista paginada de registros de la vista <see cref="VwAlumno"/>.
        /// </summary>
        /// <param name="NumeroPagina">El número de la página a recuperar (base 1).</param>
        /// <param name="TotalPagina">La cantidad de registros a incluir en cada página.</param>
        /// <param name="NumeroControl">
        /// Un filtro opcional que especifica el número de control para buscar. Si se proporciona, se filtran los resultados para incluir únicamente los registros que coincidan.
        /// </param>
        /// <returns>
        /// Una lista de objetos <see cref="VwAlumno"/> que cumple con los criterios de paginación y filtro.
        /// </returns>
        /// <remarks>
        /// Este método utiliza EF Core para realizar consultas paginadas sobre la base de datos. 
        /// Asegúrate de que <c>VwAlumno</c> esté configurado correctamente como una vista o entidad en el modelo.
        /// </remarks>
        public async Task<List<VwAlumno>> ObtenerPaginacionVwAlumnos(int NumeroPagina, int TotalPagina, string? NumeroControl)
        {
            var query = _controlEscolarDBContext.VwAlumnos.AsQueryable();

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
