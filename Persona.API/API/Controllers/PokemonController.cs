using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase, IPokemonController
    {
        private IPokemonFlujo _pokemonFlujo;

        public PokemonController(IPokemonFlujo pokemonFlujo)
        {
            _pokemonFlujo = pokemonFlujo;
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
           return Ok(await  _pokemonFlujo.Obtener());
        }
        [HttpGet("{Numero}")]
        public async Task<IActionResult> ObtenerPorId(int Numero)
        {
            var resultado = await _pokemonFlujo.ObtenerPorId(Numero);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
