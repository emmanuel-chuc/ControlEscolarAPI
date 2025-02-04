using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Alumno_.Command
{
    public class EliminarAlumnoPorNumeroControlCommand : IRequest<ApiResponse<string>>
    {
        public string NumeroControl { get; set; } = null!;
    }
    public class DeleteClienteCommandHandler : IRequestHandler<EliminarAlumnoPorNumeroControlCommand, ApiResponse<string>>
    {
        private readonly IRepositorioAlumno _repositorioAlumno;

        public DeleteClienteCommandHandler(IRepositorioAlumno repositorio)
        {
            _repositorioAlumno = repositorio;
        }

        public async Task<ApiResponse<string>> Handle(EliminarAlumnoPorNumeroControlCommand request, CancellationToken cancellationToken)
        {
            //Busca si el registro existe
            var alumnoDto = await _repositorioAlumno.ObtenerAlumnoPorNumeroControl(request.NumeroControl);

            // Obtiene registro alumno por su ID
            Alumno? alumno = await _repositorioAlumno.ObtenerPorId(alumnoDto.AlumnoId);

            // Devuelve excepcion si no encuentra registros
            if (alumno == null)
            {
                throw new ApiException("El personal no fue encontrado.");
            }
            else
            {
                // Elimina registro alumno
                await _repositorioAlumno.Eliminar(alumno);

                // Devuelve la respuesta donde fue eliminado correctamente.
                return new ApiResponse<string>("Personal eliminado correctamente.", "Eliminado");
            }
        }
    }
}
