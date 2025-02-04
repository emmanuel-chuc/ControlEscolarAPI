using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Alumno_.Queries
{
    /// <summary>
    /// Comando para obtener una paginación de la vista de alumnos.
    /// </summary>
    public class ObtenerVwAlumnosQuery : IRequest<PaginacionResponse<List<VwAlumno>>>
    {
        /// <summary>
        /// Total de páginas a obtener.
        /// </summary>
        public int TotalPagina { get; set; }

        /// <summary>
        /// Número de la página a obtener.
        /// </summary>
        public int NumeroPagina { get; set; }

        /// <summary>
        /// (Opcional) Número de control para filtrar los alumnos.
        /// </summary>
        public string? NumeroControl { get; set; }
    }


    public class PaginaVwAlumnoQueryHandler : IRequestHandler<ObtenerVwAlumnosQuery, PaginacionResponse<List<VwAlumno>>>
    {
        private readonly IRepositorioVwAlumno _repositorioVwAlumno;

        public PaginaVwAlumnoQueryHandler(IRepositorioVwAlumno repositorioVwAlumno)
        {
            _repositorioVwAlumno = repositorioVwAlumno;
        }

        /// <summary>
        /// Maneja el comando para obtener la paginación de la vista de alumnos.
        /// </summary>
        /// <param name="request">El comando que contiene los parámetros de paginación.</param>
        /// <returns>Una respuesta de paginación que contiene la lista paginada de alumnos.</returns>
        public async Task<PaginacionResponse<List<VwAlumno>>> Handle(ObtenerVwAlumnosQuery request, CancellationToken cancellationToken)
        {
            var listado = await _repositorioVwAlumno.ObtenerPaginacionVwAlumnos(request.NumeroPagina, request.TotalPagina, request.NumeroControl);
            return new PaginacionResponse<List<VwAlumno>>(listado, request.NumeroPagina, request.TotalPagina);
        }
    }


}
