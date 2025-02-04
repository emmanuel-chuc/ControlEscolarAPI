using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;


namespace Application.Features.TipoPersonal_.Commands
{
    public class ActualizaTipoPersonalCommand : IRequest<ApiResponse<string>>
    {
        public int TipoPersonalId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal? SueldoMinimo { get; set; }
        public decimal? SueldoMaximo { get; set; }

    }

    public class ActualizaTipoPersonalCommandHandler : IRequestHandler<ActualizaTipoPersonalCommand, ApiResponse<string>>
    {
        private IRepositorio<TipoPersonal> _repositorio;

        public ActualizaTipoPersonalCommandHandler(IRepositorio<TipoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ApiResponse<string>> Handle(ActualizaTipoPersonalCommand request, CancellationToken cancellationToken)
        {
            // Obtiene el registro por su id
            TipoPersonal? tipoPersonal = await _repositorio.ObtenerPorId(request.TipoPersonalId);

            if (tipoPersonal == null)
            {
                throw new ApiException("No se encontró registro para actualizar");
            }

            // Agrega los datos que se actualizaran a sus entidades
            tipoPersonal.Descripcion = request.Descripcion;
            tipoPersonal.SueldoMinimo = request.SueldoMinimo ?? 0;
            tipoPersonal.SueldoMaximo = request.SueldoMaximo ?? 0;


            // Guarda y se actualizo el registro
            await _repositorio.Actualizar(tipoPersonal);

            // Devuelve el resultado de la actualizacion que fue exitosa
            return new ApiResponse<string>("¡Actualización Completada!", "Actualizado");
        }
    }
}