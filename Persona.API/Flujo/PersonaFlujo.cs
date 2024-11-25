using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Flujo.Helper;

namespace Flujo
{
    public class PersonaFlujo : IPersonaFlujo
    {        
        private IPersonaDA _personaDA;
        private IFormatoHelper _formatoHelper;

        public PersonaFlujo(IPersonaDA personaDA, IFormatoHelper formatoHelper)
        {
            _personaDA = personaDA;
            _formatoHelper=  formatoHelper;
        }

        public async Task<Guid> Agregar(Persona persona)
        {
            var resultado= await _personaDA.Agregar(persona);
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id,Persona persona)
        {
            var resultado = await _personaDA.Editar(Id,persona);
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            var resultado = await _personaDA.Eliminar(Id);
            return resultado;
        }

        public async Task<IEnumerable<PersonaBD>> Obtener()
        {
            var personasSinformato= await _personaDA.Obtener();
            if (!personasSinformato.Any())
                return personasSinformato;
            return _formatoHelper.DarFormatoListaPersonas(personasSinformato);
            
        }

        public async Task<PersonaBD> Obtener(Guid Id)
        {
            var personaSinformato = await _personaDA.Obtener(Id);
            if (personaSinformato == null)
                return null;
            return _formatoHelper.DarFormatoPersona(personaSinformato);
        }
    }
}
