using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IDocumentoServicio
    {

        Task<bool> Agregar(DocumentoContenido documento, Guid id);
        Task<byte[]> Obtener(Guid? id);

    }
}
