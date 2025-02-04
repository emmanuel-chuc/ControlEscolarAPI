using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Alumno_.Command
{
    public class ActualizaAlumnoPorIdCommand : IRequest<ApiResponse<string>>
    {
        public int AlumnoId { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string NumeroControl { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public bool Estatus { get; set; }
        public int TipoPersonalId { get; set; }
    }

    public class ActualizaAlumnoCommandHandler : IRequestHandler<ActualizaAlumnoPorIdCommand, ApiResponse<string>>
    {
        private readonly IRepositorioAlumno _repositorioAlumno;

        public ActualizaAlumnoCommandHandler(IRepositorioAlumno repositorioAlumno)
        {
            _repositorioAlumno = repositorioAlumno;
        }

        public async Task<ApiResponse<string>> Handle(ActualizaAlumnoPorIdCommand request, CancellationToken cancellationToken)
        {
            Alumno? alumno = await _repositorioAlumno.ObtenerPorId(request.AlumnoId);

            if (alumno == null)
            {
                throw new ApiException("El alumno no fue encontrado.");
            }
            else
            {
                alumno.Nombre = request.Nombre;
                alumno.Apellidos = request.Apellidos;
                alumno.CorreoElectronico = request.CorreoElectronico;
                alumno.NumeroControl = request.NumeroControl;
                alumno.FechaNacimiento = request.FechaNacimiento;
                alumno.TipoPersonalId = request.TipoPersonalId;
                alumno.Estatus = request.Estatus;
            }

            await _repositorioAlumno.Actualizar(alumno);

            return new ApiResponse<string>("¡El alumno fue actualizado correctamente!.", "Actualizado.");
        }
    }
}
