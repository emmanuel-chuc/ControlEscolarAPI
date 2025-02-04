using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using MediatR;

namespace Application.Features.Personal_.Commands
{
    /// <summary>
    /// Comando para eliminar registro de Personal.
    /// </summary>
    public class EliminarPersonalPorNumeroControlCommand : IRequest<ApiResponse<string>>
    {
        public string NumeroControl { get; set; } = null!;
    }

    public class EliminarPersonalPorNumeorControlCommandHandler : IRequestHandler<EliminarPersonalPorNumeroControlCommand, ApiResponse<string>>
    {
        private readonly IRepositorioPersonal _repositorioPersonal;

        public EliminarPersonalPorNumeorControlCommandHandler( IRepositorioPersonal repositorioPersonal)
        {
            _repositorioPersonal = repositorioPersonal;
        }

        public async Task<ApiResponse<string>> Handle(EliminarPersonalPorNumeroControlCommand request, CancellationToken cancellationToken)
        {
            // Obtiene el DTO del personal por su número de control
            var personalDto = await _repositorioPersonal.ObtenerPersonalPorNumeroControl(request.NumeroControl);

            // Obtiene registro personal por su ID
            Domain.Entities.Personal? personal = await _repositorioPersonal.ObtenerPorId(personalDto.PersonalId);

            if (personal == null)
            {
                throw new ApiException("El personal no fue encontrado.");
            }
            else
            {
                // Elimina registro dde personal
                await _repositorioPersonal.Eliminar(personal);

                // Devuelve la respuesta donde fue eliminado correctamente.
                return new ApiResponse<string>("Personal eliminado correctamente.", "Eliminado");
            }
        }
    }

}
