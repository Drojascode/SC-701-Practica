using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }        
    }
    public class PokemonDetalle : Pokemon
    {
        public IEnumerable<string> Tipos { get; set; }
    }
}
