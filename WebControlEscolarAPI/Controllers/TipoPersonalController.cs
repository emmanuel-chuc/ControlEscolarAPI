using Application.Features.Personal.Queries;
using Application.Features.TipoPersonal_.Commands;
using Application.Features.TipoPersonal_.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebControlEscolarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPersonalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoPersonalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene el listado de todos los tipos de personal.
        /// </summary>
        /// <returns>Una lista de todos los tipos de personal.</returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerCatalogoListadoPersonal()
        {
            var respuesta = await _mediator.Send(new ObtenerTipoPersonalQuery());
            return Ok(respuesta);
        }

        /// <summary>
        /// Obtiene un tipo de personal específico por su Id.
        /// </summary>
        /// <param name="Id">Identificador del tipo de personal a obtener.</param>
        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerCatalogoTipoPersonalPorId([FromRoute] int Id)
        {
            var respuesta = await _mediator.Send(new ObtenerTipoPersonalPorIdQuery { TipoPersonalId = Id });
            return Ok(respuesta);
        }

        /// <summary>
        /// Crea un nuevo tipo de personal.
        /// </summary>
        /// <param name="command">Comando con la información del tipo de personal a crear.</param>
        /// <returns>Mensaje de resultado creado.</returns>
        [HttpPost]
        public async Task<IActionResult> CrearTipoPersonal([FromBody] CrearTipoPersonalCommand command)
        {
            var respuesta = await _mediator.Send(command);
            return Created("", respuesta);
        }

        /// <summary>
        /// Actualiza un tipo de personal existente.
        /// </summary>
        /// <param name="Id">Identificador del tipo de personal a actualizar.</param>
        /// <param name="command">Comando con la información actualizada del tipo de personal.</param>
        /// <returns>Mensaje de resultado actualizado.</returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizaTipoPersonal([FromRoute] int Id, [FromBody] ActualizaTipoPersonalCommand command)
        {
            if (Id != command.TipoPersonalId)
            {
                return BadRequest("Las identificaciones no coinciden");
            }
            var respuesta = await _mediator.Send(command);
            return Ok(respuesta);
        }

        /// <summary>
        /// Elimina un tipo de personal específico por su Id.
        /// </summary>
        /// <param name="Id">Identificador del tipo de personal a eliminar.</param>
        /// <returns>Mensaje de resultado eliminado.</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarTipoPersonal([FromRoute] int Id)
        {
            var respuesta = await _mediator.Send(new EliminaTipoPersonalCommand { TipoPersonalId = Id });
            return Ok(respuesta);
        }
    }
}
