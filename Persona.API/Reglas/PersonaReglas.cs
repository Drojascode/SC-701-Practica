using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class PersonaReglas : IPersonaReglas
    {
        public PersonaBD DarFormatoNombre(PersonaBD persona)
        {
            persona.Nombre = persona.Nombre.ToUpper();
            return persona;
        }
    }
}
