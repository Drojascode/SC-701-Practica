using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IPerfilController
    {
        Task<IActionResult> Agregar(PerfilRequest perfil);
        Task<IActionResult> Obtener(Guid Id);

    }
}
