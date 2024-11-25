using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Flujo.Helper;

namespace Flujo
{
    public class PokemonFlujo : IPokemonFlujo
    {        
        private IPokemonServicio _pokemonServicio;        

        public PokemonFlujo(IPokemonServicio pokemonServicio)
        {
            _pokemonServicio = pokemonServicio;

        }

        public async Task<IEnumerable<Pokemon>> Obtener()
        {
            var pokemons= await _pokemonServicio.Obtener();
            return pokemons;


        }

        public async Task<PokemonDetalle> ObtenerPorId(int Numero)
        {
            var pokemon = await _pokemonServicio.ObtenerPorId(Numero);
            return pokemon;
        }
    }
}
