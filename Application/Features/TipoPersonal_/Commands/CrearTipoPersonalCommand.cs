using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.TipoPersonal_.Commands
{
    public class CrearTipoPersonalCommand : IRequest<ApiResponse<string>>
    {
        public string Descripcion { get; set; } = null!;
        public bool TieneSueldo { get; set; }
        public decimal? SueldoMinimo { get; set; }
        public decimal? SueldoMaximo { get; set; }
    }

    public class CreateTipoPersonalCommandHandler : IRequestHandler<CrearTipoPersonalCommand, ApiResponse<string>>
    {
        private readonly IRepositorio<TipoPersonal> _repositorio;
        public CreateTipoPersonalCommandHandler(IRepositorio<TipoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<ApiResponse<string>> Handle(CrearTipoPersonalCommand request, CancellationToken cancellationToken)
        {
            // Crea una nueva instancia de TipoPersonal con los datos del comando
            TipoPersonal tipoPersonal = new TipoPersonal()
            {
                Descripcion = request.Descripcion,
                SueldoMaximo = request.SueldoMaximo ?? 0,
                SueldoMinimo = request.SueldoMinimo ?? 0
            };

            // Agrega el nuevo registro de Tipo de Personal
            await _repositorio.Agregar(tipoPersonal);

            // Devuelve la respuesta exitosa del registro
            return new ApiResponse<string>("El Tipo de Personal se ha creado correctamente.", "Creado.");
        }
    }
}
