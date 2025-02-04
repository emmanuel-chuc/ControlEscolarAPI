using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using MediatR;

namespace Application.Features.Alumno_.Queries
{
    public class ObtenerAlumnoPorNumeroControlQuery : IRequest<ApiResponse<AlumnoDTO>>
    {
        public string NumeroControl { get; set; } = null!;
    }

    public class ObeterAlumnoPorNumeroControlQueryHandler : IRequestHandler<ObtenerAlumnoPorNumeroControlQuery, ApiResponse<AlumnoDTO>>
    {
        private readonly IRepositorioAlumno _repositorioAlumno;

        public ObeterAlumnoPorNumeroControlQueryHandler(IRepositorioAlumno repositorioAlumno)
        {
            _repositorioAlumno = repositorioAlumno;
        }

        public async Task<ApiResponse<AlumnoDTO>> Handle(ObtenerAlumnoPorNumeroControlQuery request, CancellationToken cancellationToken)
        {
            var alumnoDTO = await _repositorioAlumno.ObtenerAlumnoPorNumeroControl(request.NumeroControl);

            return new ApiResponse<AlumnoDTO>(alumnoDTO);
        }

    }
    
}
