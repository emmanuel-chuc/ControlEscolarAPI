using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Personal.Queries
{
    public class ObtenerPersonalPorNumeroControlQuery : IRequest<ApiResponse<PersonalDTO>>
    {
        public string NumeroControl { get; set; } = null!;
    }


    public class ObeterPersonalPorNumeroControlQueryHandler : IRequestHandler<ObtenerPersonalPorNumeroControlQuery, ApiResponse<PersonalDTO>>
    {
        private readonly IRepositorioPersonal _repositorioPersonal;

        public ObeterPersonalPorNumeroControlQueryHandler(IRepositorioPersonal repositorioPersonal)
        {
            _repositorioPersonal = repositorioPersonal;
        }

        public async Task<ApiResponse<PersonalDTO>> Handle(ObtenerPersonalPorNumeroControlQuery request, CancellationToken cancellationToken)
        {
            var dto = await _repositorioPersonal.ObtenerPersonalPorNumeroControl(request.NumeroControl);
            return new ApiResponse<PersonalDTO>(dto);
        }

    }
}

