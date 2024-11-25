using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : Controller, IPerfilController
    {

        private IPerfilFlujo _perfilFlujo;
        private ILogger<PerfilController> _logger;

        public PerfilController(IPerfilFlujo perfilFlujo, ILogger<PerfilController> logger)
        {
            _perfilFlujo = perfilFlujo;
            _logger = logger;
        }
        //[Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] PerfilRequest perfil)
        {
            var resultado = await _perfilFlujo.Agregar(perfil);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        //[Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _perfilFlujo.Obtener(Id);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
