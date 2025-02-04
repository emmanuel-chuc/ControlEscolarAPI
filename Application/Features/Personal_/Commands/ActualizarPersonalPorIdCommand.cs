
using Application.Interfaces;
using MediatR;


namespace Application.Features.Personal.Commands
{
    /// <summary>
    /// Comando para actualizar los datos la tabla personal.
    /// </summary>
    public class ActualizarPersonalPorIdCommand : IRequest<Responses.ApiResponse<string>>
    {
        public int PerosnalId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string NumeroControl { get; set; } = null!;
        public bool Estatus { get; set; }
        public int TipoPersonalId { get; set; }
        public decimal Sueldo { get; set; }
    }

    public class ActualizarPersonalPorIdCommandHandler : IRequestHandler<ActualizarPersonalPorIdCommand, Responses.ApiResponse<string>>
    {
        private readonly IRepositorioPersonal _repositorioPersonal;

        public ActualizarPersonalPorIdCommandHandler(IRepositorioPersonal repositorioPersonal)
        {
            _repositorioPersonal = repositorioPersonal;
        }
        public async Task<Responses.ApiResponse<string>> Handle(ActualizarPersonalPorIdCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Personal? personal = await _repositorioPersonal.ObtenerPorId(request.PerosnalId);

            if (personal == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el número de control = {request.NumeroControl}");
            }
            else
            {

                personal.Sueldo = request.Sueldo;
                personal.Nombre = request.Nombre;
                personal.Apellidos = request.Apellidos;
                personal.CorreoElectronico = request.CorreoElectronico;
                personal.NumeroControl = request.NumeroControl;
                personal.FechaNacimiento = request.FechaNacimiento;
                personal.TipoPersonalId = request.TipoPersonalId;
                personal.Estatus = request.Estatus;

                await _repositorioPersonal.Actualizar(personal);

                return new Responses.ApiResponse<string>("El personal fue actualizado correctamente", "Actualizdo");
            }
        }
    }
}
