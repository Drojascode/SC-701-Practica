using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPerfilFlujo
    {
        Task<PerfilRequest> Obtener(Guid Id);
        Task<Guid> Agregar(PerfilRequest perfil);
    }
}
