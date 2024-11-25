using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class PokemonServicio : IPokemonServicio
    {
        private IConfiguracion _configuracion;


        public PokemonServicio(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task<IEnumerable<Pokemon>> Obtener()
        {
            var endpoint= _configuracion.ObtenerMetodo("ObtenerPokemons");
            var cliente= new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var pokemonsAPI = JsonSerializer.Deserialize<PokeAPITodos>(resultado);
            return JsonSerializer.Deserialize<PokeAPITodos>(resultado).results.Select(p => new Pokemon { Nombre = p.name, Numero = Convert.ToInt32(p.url.Split("/")[^2]) });
        }

        public async Task<PokemonDetalle> ObtenerPorId(int Numero)
        {
            var endpoint = _configuracion.ObtenerMetodo("ObtenerPokemon");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint,Numero));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var pokemonAPIDetalle= JsonSerializer.Deserialize<PokeAPIDetalle>(resultado);
            return new PokemonDetalle { Nombre = pokemonAPIDetalle.name, Numero = pokemonAPIDetalle.id, Tipos = pokemonAPIDetalle.types.Select(t => t.type.name) };
        }
    }
}
