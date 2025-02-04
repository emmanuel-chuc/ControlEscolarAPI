using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TipoPersonal_.Queries
{
    public class ObtenerTipoPersonalPorIdQuery : IRequest<ApiResponse<TipoPesonalDTO>>
    {
        public int TipoPersonalId { get; set; }
    }

    public class ObtenerTipoPersonalPorIdHandler : IRequestHandler<ObtenerTipoPersonalPorIdQuery, ApiResponse<TipoPesonalDTO>>
    {
        private readonly IRepositorio<TipoPersonal> _repositorio;
        private readonly IMapper _mapper;

        public ObtenerTipoPersonalPorIdHandler(IRepositorio<TipoPersonal> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TipoPesonalDTO>> Handle(ObtenerTipoPersonalPorIdQuery request, CancellationToken cancellationToken)
        {
            TipoPersonal? tipoPersonal = await _repositorio.ObtenerPorId(request.TipoPersonalId);

            //var tipoPersonalDTO = _mapper.Map<TipoPesonalDTO>(tipoPersonal);

            var tipoPersonalDTO = new TipoPesonalDTO();
            tipoPersonalDTO.TipoPersonalId = tipoPersonal.TipoPersonalId;
            tipoPersonalDTO.ClaveControl = tipoPersonal.ClaveControl;
            tipoPersonalDTO.Descripcion = tipoPersonal.Descripcion;
            tipoPersonalDTO.SueldoMaximo = tipoPersonal.SueldoMaximo;
            tipoPersonalDTO.SueldoMinimo = tipoPersonal.SueldoMinimo;

            //Devuelve el listado del personal
            return new ApiResponse<TipoPesonalDTO>(tipoPersonalDTO);
            //}
        }
    }
}
