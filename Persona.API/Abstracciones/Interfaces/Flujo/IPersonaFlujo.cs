using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPersonaFlujo
    {
        Task<IEnumerable<PersonaBD>> Obtener();
        Task<PersonaBD> Obtener(Guid Id);
        Task<Guid> Agregar(Persona persona);
        Task<Guid> Editar(Guid Id, Persona persona);
        Task<Guid> Eliminar(Guid Id);
    }
}
