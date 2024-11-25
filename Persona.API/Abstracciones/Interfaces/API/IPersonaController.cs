using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IPersonaController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Agregar(Persona persona);
        Task<IActionResult> ObtenerPorId(Guid Id);
        Task<IActionResult> Editar(Guid Id,Persona persona);
        Task<IActionResult> Eliminar(Guid Id);

    }
}
