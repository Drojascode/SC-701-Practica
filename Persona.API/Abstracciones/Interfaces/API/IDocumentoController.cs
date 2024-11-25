using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IDocumentoController
    {
            Task<IActionResult> Agregar(DocumentoContenido documento);
            Task<IActionResult> Obtener();
            Task<IActionResult> ObtenerPorId(Guid Id);
    }
}
