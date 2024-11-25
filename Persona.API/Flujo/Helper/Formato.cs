using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo.Helper
{
    public class Formato:IFormatoHelper
    {
        private IPersonaReglas _personaReglas;
        public Formato(IPersonaReglas personaReglas)
        {
            _personaReglas = personaReglas;
        }
        public IEnumerable<PersonaBD> DarFormatoListaPersonas(IEnumerable<PersonaBD> personas) { 
        

            List<PersonaBD> personasConFormato= new List<PersonaBD>();
            if (!personas.Any())
                return null;
        foreach (PersonaBD persona in personas)
            {
                var personaformato = _personaReglas.DarFormatoNombre(persona);
                personasConFormato.Add(personaformato);
            }
        return personas;
        }
        public PersonaBD DarFormatoPersona(PersonaBD persona)
        {
            if (persona==null)
                return null;
            return _personaReglas.DarFormatoNombre(persona); 
        }

    }
}
