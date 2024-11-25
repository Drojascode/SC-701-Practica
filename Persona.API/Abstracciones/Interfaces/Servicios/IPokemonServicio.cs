using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IPokemonServicio
    {
        Task<PokemonDetalle> ObtenerPorId(int Numero) ;
        Task<IEnumerable<Pokemon>> Obtener();
    }
}
