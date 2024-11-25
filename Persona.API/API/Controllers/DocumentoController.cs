using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase, IDocumentoController
    {
        private IDocumentoFlujo _documentoFlujo;

        public DocumentoController(IDocumentoFlujo documentoFlujo)
        {
            _documentoFlujo = documentoFlujo;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] DocumentoContenido documento)
        {
            var resultado = await _documentoFlujo.Agregar(documento);
            if (resultado == Guid.Empty)
                return BadRequest("No se pudo agregar el documento");
            return CreatedAtAction("ObtenerPorId", new { id = resultado }, resultado);
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _documentoFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute]Guid Id)
        {
            var resultado = await _documentoFlujo.ObtenerPorId(Id);
            if (resultado==null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
