using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IDocumentoDA
    {
        Task<Guid> Agregar(DocumentoContenido documento, Guid id);
        Task<IEnumerable<DocumentoSinContenido>> Obtener();
        Task<DocumentoConContenido> ObtenerPorId(Guid? Id);
    }
}
