using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositorios
{
    public class RepositorioPersonal : Repositorio<Personal>, IRepositorioPersonal
    {
        public RepositorioPersonal(ControlEscolarDbContext controlEscolarDbContext) : base(controlEscolarDbContext)
        {
        }

        public async Task<PersonalDTO> ObtenerPersonalPorNumeroControl(string NumeroControl)
        {
            var respuesta = await _controlEscolarDBContext.Personals.Where(p => p.NumeroControl == NumeroControl)
                .Select(p => new PersonalDTO
                {
                    PersonalId = p.PersonalId,
                    NumeroControl = p.NumeroControl,
                    Apellidos = p.Apellidos,
                    CorreoElectronico = p.CorreoElectronico,
                    Estatus = (bool)p.Estatus,
                    FechaNacimiento = (DateTime)p.FechaNacimiento,
                    TipoPersonalId = (int)p.TipoPersonalId,
                    Nombre = p.Nombre,
                    Sueldo = p.Sueldo,


                }).FirstOrDefaultAsync();

            if (respuesta == null)
            {
                throw new ApiException("No se encontro el registro del personal");
            }

            return respuesta;
        }
    }
}
