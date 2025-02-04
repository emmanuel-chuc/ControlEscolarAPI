using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using MediatR;


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

        public CreatePersonalCommandHandler(IRepositorioPersonal repositorioPersonal)
        {
            _repositorioPersonal = repositorioPersonal;
        }

        public async Task<ApiResponse<string>> Handle(CrearPersonalCommad request, CancellationToken cancellationToken)
        {
            //Se crea un nuevo numero de control con el procedimiento almacenado
            string numControl = "";

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