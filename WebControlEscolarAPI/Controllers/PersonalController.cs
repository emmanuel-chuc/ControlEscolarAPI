using Application.Features.Personal.Commands;
using Application.Features.Personal.Queries;
using Application.Features.Personal_.Commands;
using Application.Features.Personal_.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebControlEscolarAPI.Controllers
{
    [Route("api/[controller]")]

    /// <summary>
    /// Query que optiene el objeto del personal con sus detalles filtrado por el número de control
    /// </summary>
    /// <param name="NumeroControl">Número de control del personal.</param>
    /// <returns>el objeto del personal filtrado.</returns>
    [ApiController]
    public class PersonalController : ControllerBase
    { 
        private readonly IMediator _mediator;
        public PersonalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene la información de un personal específico basado en su número de control.
        /// </summary>
        /// <param name="NumeroControl">El número de control del personal.</param>
        /// <returns>La información del personal correspondiente al número de control proporcionado.</returns>
        [HttpGet("{NumeroControl}")]
        public async Task<IActionResult> ObtenerPersonalPorNumeroControl([FromRoute] string NumeroControl)
        {
            var respuesta = await _mediator.Send(new ObtenerPersonalPorNumeroControlQuery { NumeroControl = NumeroControl });
                return Ok(respuesta);
        }

        [HttpGet("paginarVwPersonas")]
        public async Task<IActionResult> PaginarPersonal([FromQuery] int TotalPagina = 10, [FromQuery] int NumeroPagina = 1, [FromQuery] string? NumeroControl = null)
        {
            var respuesta = await _mediator.Send(new ObtenerVwPersonalQuery { NumeroControl = NumeroControl, NumeroPagina = NumeroPagina, TotalPagina = TotalPagina });

            return Ok(respuesta);
        }

        /// <summary>
        /// Crea un nuevo registro de personal.
        /// </summary>
        /// <param name="command">Datos que el usuario manda para agregar.</param>
        /// <returns>Devuelve mensaje que fue creado con exito.</returns>
        [HttpPost]
        public async Task<IActionResult> CrearPersonal([FromBody] CrearPersonalCommad commad)
        {
            var respuesta = await _mediator.Send( commad);
            return Created("",respuesta);

        }

        /// <summary>
        /// Actualiza rl registro usando el identificador de PersonalId
        /// </summary>
        /// <param name="id">Identificador unico de la tabla.</param>
        /// <returns>Respuesta confirmando el registro fue actualizado.</returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizarPersonalPorId([FromRoute] int Id, [FromBody] ActualizarPersonalPorIdCommand command)
        {
            if (Id != command.PerosnalId)
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
            var respuesta = await _mediator.Send(new EliminarPersonalPorNumeroControlCommand { NumeroControl = NumeroControl });

            return Ok(respuesta);
        }
    }
}
