using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{   
    public interface IRepositorioPersonal : IRepositorio<Personal>
    {
        Task<PersonalDTO> ObtenerPersonalPorNumeroControl(string NumeroControl);
    }
}
