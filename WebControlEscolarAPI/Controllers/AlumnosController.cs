using Application.Features.Alumno_.Command;
using Application.Features.Alumno_.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AlumnosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{NumeroControl}")]
        public async Task<IActionResult> ObtenerPersonalPorNumeroControl([FromRoute] string NumeroControl)
        {
            var respuesta = await _mediator.Send(new ObtenerAlumnoPorNumeroControlQuery { NumeroControl = NumeroControl });
            return Ok(respuesta);
        }


        [HttpGet("paginarVwAlumnos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme/*, Roles = "Administrador"*/)]
        public async Task<IActionResult> PaginarVwAlumnos([FromQuery] int TotalPagina = 10, [FromQuery] int NumeroPagina = 1, [FromQuery] string? NumeroControl = null)
        {
            var respuesta = await _mediator.Send(new ObtenerVwAlumnosQuery { NumeroControl = NumeroControl, NumeroPagina = NumeroPagina, TotalPagina = TotalPagina });

            return Ok(respuesta);
        }

        /// <summary>
        /// Crea un nuevo registro de personal.
        /// </summary>
        /// <param name="command">Datos que el usuario manda para agregar.</param>
        /// <returns>Devuelve mensaje que fue creado con exito.</returns>
        [HttpPost]
        public async Task<IActionResult> CrearPersonal([FromBody] CrearAlumnoCommand commad)
        {
            var respuesta = await _mediator.Send(commad);
            return Created("", respuesta);

        }

        /// <summary>
        /// Actualiza rl registro usando el identificador de PersonalId
        /// </summary>
        /// <param name="id">Identificador unico de la tabla.</param>
        /// <returns>Respuesta confirmando el registro fue actualizado.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPersonalPorId([FromRoute] int id, [FromBody] ActualizaAlumnoPorIdCommand command)
        {
            if (id != command.AlumnoId)
            {
                return BadRequest("Los identificadores no coinciden");
            }
            var respuesta = await _mediator.Send(command);

            return Ok(respuesta);
        }

        /// <summary>
        /// Elimina un registro de personal basado en su número de control.
        /// </summary>
        /// <param name="NumeroControl">Número de control del personal a eliminar.</param>
        /// <returns>Respuesta confirmando el registro eliminación.</returns>
        [HttpDelete("{NumeroControl}")]
        public async Task<IActionResult> EliminarPersonal([FromRoute] string NumeroControl)
        {
            var respuesta = await _mediator.Send(new EliminarAlumnoPorNumeroControlCommand { NumeroControl = NumeroControl });

            return Ok(respuesta);
        }
    }
}
