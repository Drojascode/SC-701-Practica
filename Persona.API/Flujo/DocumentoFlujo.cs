using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Flujo.Helper;

namespace Flujo
{
    public class DocumentoFlujo : IDocumentoFlujo
    {
        private IDocumentoServicio _documentoServicio;
        private IDocumentoDA _documentoDA;

        public DocumentoFlujo(IDocumentoServicio documentoServicio, IDocumentoDA documentoDA)
        {
            _documentoServicio = documentoServicio;
            _documentoDA = documentoDA;
        }

        public async Task<Guid> Agregar(DocumentoContenido documento)
        {
            var id= Guid.NewGuid();
            var resultadoAgregarContenido= await _documentoServicio.Agregar(documento, id);
            if (!resultadoAgregarContenido)
                return Guid.Empty;
            return await _documentoDA.Agregar(documento, id);

        }

        public async Task<IEnumerable<DocumentoSinContenido>> Obtener()
        {
            return await _documentoDA.Obtener();
        }

        public async Task<DocumentoConContenido> ObtenerPorId(Guid Id)
        {
            var resultadoContenido = await _documentoServicio.Obtener(Id);
            if (resultadoContenido==null)
                return null;
            var documento= await _documentoDA.ObtenerPorId(Id);
            documento.Contenido = resultadoContenido;
            return documento;
        }
    }
}
