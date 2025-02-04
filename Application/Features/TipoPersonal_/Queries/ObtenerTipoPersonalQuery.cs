using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TipoPersonal_.Queries
{
    public class ObtenerTipoPersonalQuery : IRequest<ApiResponse<List<TipoPesonalDTO>>>
    {
    }

    public class ObtenerTipoPersonalHandler : IRequestHandler<ObtenerTipoPersonalQuery, ApiResponse<List<TipoPesonalDTO>>>
    {
        private readonly IRepositorio<TipoPersonal> _repositorio;
        private readonly IMapper _mapper;

        public ObtenerTipoPersonalHandler(IRepositorio<TipoPersonal> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TipoPesonalDTO>>> Handle(ObtenerTipoPersonalQuery request, CancellationToken cancellationToken)
        {
            //Obtiene los registros de la tabla Tipo Personal
            List<TipoPersonal> listadoTipoPersonal = (List<TipoPersonal>)await _repositorio.ObtenerTodos();

            List<TipoPesonalDTO> listTipoPersonalDTO = new List<TipoPesonalDTO>();
            foreach (TipoPersonal tipoPer in listadoTipoPersonal)
            {
                TipoPesonalDTO tempTipoPerDto = new TipoPesonalDTO();
                tempTipoPerDto.TipoPersonalId = tipoPer.TipoPersonalId;
                tempTipoPerDto.ClaveControl = tipoPer.ClaveControl;
                tempTipoPerDto.Descripcion = tipoPer.Descripcion;
                tempTipoPerDto.SueldoMaximo = tipoPer.SueldoMaximo;
                tempTipoPerDto.SueldoMinimo = tipoPer.SueldoMinimo;

                listTipoPersonalDTO.Add(tempTipoPerDto);
            }

            //Devuelve el listado del Tipo Personal
            return new ApiResponse<List<TipoPesonalDTO>>(listTipoPersonalDTO);
        }
    }
}
