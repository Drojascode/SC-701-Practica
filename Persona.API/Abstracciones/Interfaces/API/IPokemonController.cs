using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IPokemonController
    {
        Task<IActionResult> ObtenerPorId(int Numero);
        Task<IActionResult> Obtener();

    }
}
