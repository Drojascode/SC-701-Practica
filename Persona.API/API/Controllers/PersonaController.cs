using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller, IPersonaController
    {

        private IPersonaFlujo _personaFlujo;
        private ILogger<PersonaController> _logger;

        public PersonaController(IPersonaFlujo personaFlujo, ILogger<PersonaController> logger)
        {
            _personaFlujo = personaFlujo;
            _logger = logger;
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Persona persona)
        {
            var resultado = await _personaFlujo.Agregar(persona);
            return CreatedAtAction(nameof(ObtenerPorId), new { Id = resultado }, null);
        }
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute]  Guid Id, [FromBody] Persona persona)
        {
            var resultado = await _personaFlujo.Editar(Id, persona);
            if (resultado == Guid.Empty)
                return BadRequest("La persona a editar no exite");
            return Ok(resultado);
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            var resultado = await _personaFlujo.Eliminar(Id);
            if (resultado == Guid.Empty)
                return BadRequest("La persona a eliminar no exite");
            return NoContent();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            _logger.LogInformation("Obteniendo personas");
            var resultado = await _personaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] Guid Id)
        {
            var resultado = await _personaFlujo.Obtener(Id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
