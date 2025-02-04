using Application.Interfaces;
using Application.Responses;
using Application.Utils;
using Domain.Entities;
using Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Features.Alumno_.Command
{
    public class CrearAlumnoCommand : IRequest<ApiResponse<string>>
    {
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public bool Estatus { get; set; }
        public int TipoPersonalId { get; set; }
    }

    public class CrearAlumnoCommandHandler : IRequestHandler<CrearAlumnoCommand, ApiResponse<string>>
    {
        private readonly IRepositorioAlumno _repositorio;
        private readonly ConnectionStringsSettings _connectionStrings;

        public CrearAlumnoCommandHandler(IRepositorioAlumno repositorio, IOptions<ConnectionStringsSettings> connectionStrings)
        {
            _repositorio = repositorio;
            _connectionStrings = connectionStrings.Value;
        }

        public async Task<ApiResponse<string>> Handle(CrearAlumnoCommand request, CancellationToken cancellationToken)
        {
            string? numControl = await GeneraNumeroControl.GeneraNumeroControlAlumno( _connectionStrings.DefaultConnection);

            Alumno alumno = new Alumno();
            alumno.Nombre = request.Nombre;
            alumno.Apellidos = request.Apellidos;
            alumno.CorreoElectronico = request.CorreoElectronico;
            alumno.NumeroControl = numControl;
            alumno.FechaNacimiento = request.FechaNacimiento;
            alumno.TipoPersonalId = request.TipoPersonalId;
            alumno.Estatus = request.Estatus;

            await _repositorio.Agregar(alumno);

            return new ApiResponse<string>("El Alumno fue creado exitosamente.", "Creado");
        }
    }
}
