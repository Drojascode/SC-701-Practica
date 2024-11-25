using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IDocumentoFlujo
    {

        Task<Guid> Agregar(DocumentoContenido documento);
        Task<IEnumerable<DocumentoSinContenido>> Obtener();
        Task<DocumentoConContenido> ObtenerPorId(Guid Id);

    }
}
