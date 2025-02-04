using Application.Features.Alumno_.Queries;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Personal_.Queries
{
    /// <summary>
    /// Comando para obtener una paginación de la vista de personal.
    /// </summary>
    public class ObtenerVwPersonalQuery : IRequest<PaginacionResponse<List<VwPersonal>>>
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
        /// (Opcional) Número de control para filtrar personal.
        /// </summary>
        public string? NumeroControl { get; set; }
    }


    public class ObtenerVwPersonalQueryHandler : IRequestHandler<ObtenerVwPersonalQuery, PaginacionResponse<List<VwPersonal>>>
    {
        private readonly IRepositorioVwPersonal _repositorioVwPersonal;

        public ObtenerVwPersonalQueryHandler(IRepositorioVwPersonal repositorioVwPersonal)
        {
            _repositorioVwPersonal = repositorioVwPersonal;
        }

        /// <summary>
        /// Maneja el comando para obtener la paginación de la vista de persononal.
        /// </summary>
        /// <param name="request">El comando que contiene los parámetros de paginación.</param>
        /// <returns>Una respuesta de paginación que contiene la lista paginada de personal.</returns>
        public async Task<PaginacionResponse<List<VwPersonal>>> Handle(ObtenerVwPersonalQuery request, CancellationToken cancellationToken)
        {
            var listado = await _repositorioVwPersonal.ObtenerPaginacionVwPersonal(request.NumeroPagina, request.TotalPagina, request.NumeroControl);
            return new PaginacionResponse<List<VwPersonal>>(listado, request.NumeroPagina, request.TotalPagina);
        }
    }
}
