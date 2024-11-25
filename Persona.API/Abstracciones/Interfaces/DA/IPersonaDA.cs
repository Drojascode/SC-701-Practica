using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IPersonaDA
    {
        Task<IEnumerable<PersonaBD>> Obtener();
        Task<PersonaBD> Obtener(Guid Id);
        Task<Guid> Agregar(Persona persona);
        Task<Guid> Editar(Guid Id,Persona persona);
        Task<Guid> Eliminar(Guid Id);
    }
}
