using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositorios
{
    public class RepositorioAlumno : Repositorio<Alumno>, IRepositorioAlumno
    {        
        public RepositorioAlumno(ControlEscolarDbContext controlEscolarDbContext) : base(controlEscolarDbContext)
        {
        }

        public async Task<AlumnoDTO> ObtenerAlumnoPorNumeroControl(string NumeroControl)
        {
            var respuesta = await _controlEscolarDBContext.Alumnos.Where(a => a.NumeroControl == NumeroControl)
                .Select(a => new AlumnoDTO
                {
                    AlumnoId = a.AlumnoId,
                    NumeroControl = a.NumeroControl,
                    Nombre = a.Nombre,
                    Apellidos = a.Apellidos,
                    CorreoElectronico = a.CorreoElectronico,
                    Estatus = (bool)a.Estatus,
                    FechaNacimiento = (DateTime)a.FechaNacimiento,
                    TipoPersonalId = (int)a.TipoPersonalId,
                    
                }).FirstOrDefaultAsync();

            if (respuesta == null)
            {
                throw new ApiException("No se encontro el registro del alumno");
            }

            return respuesta;
        }
    }
}
