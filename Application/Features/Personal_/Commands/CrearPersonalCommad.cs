using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;


namespace Application.Features.Personal.Commands
{
    public class CrearPersonalCommad : IRequest<ApiResponse<string>>
    {
        public decimal Sueldo { get; set; }
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public string CorreoElectronico { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public bool Estatus { get; set; }
        public int TipoPersonalId { get; set; }

    }
    public class CreatePersonalCommandHandler : IRequestHandler<CrearPersonalCommad, ApiResponse<string>>
    {
        private IRepositorioPersonal _repositorioPersonal;
        private readonly ConnectionStringsSettings _connectionStrings;
        private IRepositorio<TipoPersonal> _repositorioTipoPersonal;

        public CreatePersonalCommandHandler(IRepositorioPersonal repositorioPersonal, IOptions<ConnectionStringsSettings> connectionStrings, IRepositorio<TipoPersonal> repositorioTipoPersonal)
        {
            _repositorioPersonal = repositorioPersonal;
            _connectionStrings = connectionStrings.Value;
            _repositorioTipoPersonal = repositorioTipoPersonal;
        }
        

        public async Task<ApiResponse<string>> Handle(CrearPersonalCommad request, CancellationToken cancellationToken)
        {
            TipoPersonal? tipoPersonal = await _repositorioTipoPersonal.ObtenerPorId(request.TipoPersonalId);

            if (tipoPersonal == null)
            {
                throw new ApiException("No se encontró registro para actualizar");
            }
            //Se crea un nuevo numero de control con el procedimiento almacenado
            string? numControl = await GeneraNumeroControl.GeneraNumeroControlPersonal(tipoPersonal.TipoPersonalId.ToString(),_connectionStrings.DefaultConnection);

            //Se crea un nuevo Objeto de Personal
            Domain.Entities.Personal nuevoRegPersonal = new Domain.Entities.Personal();
            //Agregamos las variables a sus entidades correspondientes
            nuevoRegPersonal.Sueldo = request.Sueldo;
            nuevoRegPersonal.Nombre = request.Nombre;
            nuevoRegPersonal.Apellidos = request.Apellidos;
            nuevoRegPersonal.CorreoElectronico = request.CorreoElectronico;
            nuevoRegPersonal.NumeroControl = numControl;
            nuevoRegPersonal.FechaNacimiento = request.FechaNacimiento;
            nuevoRegPersonal.TipoPersonalId = request.TipoPersonalId;
            nuevoRegPersonal.Estatus = request.Estatus;

            try
            {
                // Intenta el registro personal usando el repositorioPresonal
                await _repositorioPersonal.Agregar(nuevoRegPersonal);
            }
            catch (Exception ex)
            {
                // Excepcion si falla al insertar el registro 
                Console.WriteLine(ex);
                throw;
            }

            // Se devuelve la respuesta exitosa
            return new ApiResponse<string>("¡Personal creado exitosamente!", "Creado");
        }
    }
}