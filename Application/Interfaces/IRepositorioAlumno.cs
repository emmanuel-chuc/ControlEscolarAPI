using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepositorioAlumno : IRepositorio<Alumno>
    {    
        Task<AlumnoDTO> ObtenerAlumnoPorNumeroControl(string NumeroControl);      
        
    }
}
