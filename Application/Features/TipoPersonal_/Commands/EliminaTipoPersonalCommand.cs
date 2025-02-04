using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.TipoPersonal_.Commands
{
    public class EliminaTipoPersonalCommand : IRequest<ApiResponse<string>>
    {
        public int TipoPersonalId { get; set; }
    }
    public class EliminaTipoPersonalCommandHandler : IRequestHandler<EliminaTipoPersonalCommand, ApiResponse<string>>
    {
        private readonly IRepositorio<TipoPersonal> _repositorio;
        public EliminaTipoPersonalCommandHandler(IRepositorio<TipoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ApiResponse<string>> Handle(EliminaTipoPersonalCommand request, CancellationToken cancellationToken)
        {
            // Obtiene el registro Tipo de Personal por su Id
            TipoPersonal? tipoPersonal = await _repositorio.ObtenerPorId(request.TipoPersonalId);

            if (tipoPersonal == null)
            {
                throw new ApiException("No se encontró el tipo de personal a eliminar");
            }
            else
            {
                //Elimina el registro Tipo de Personal
                await _repositorio.Eliminar(tipoPersonal);

                //Devuelve una respuesta indicando que el registro fue eliminado exitosamente
                return new ApiResponse<string>("¡Registro eliminado exitosamente!", "Eliminado");
            }
        }
    }
}
