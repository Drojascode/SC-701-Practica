using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPokemonFlujo
    {
        Task<PokemonDetalle> ObtenerPorId(int Numero);
        Task<IEnumerable<Pokemon>> Obtener();
    }
}
