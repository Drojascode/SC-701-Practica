using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IFormatoHelper
    {
        IEnumerable<PersonaBD> DarFormatoListaPersonas(IEnumerable<PersonaBD> personas);
        PersonaBD DarFormatoPersona(PersonaBD persona);
    }
}
