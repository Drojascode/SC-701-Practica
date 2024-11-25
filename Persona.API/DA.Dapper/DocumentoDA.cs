using Abstracciones.DA;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DA.Dapper
{
    public class DocumentoDA : IDocumentoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;
        private IConfiguration _configuration;

        public DocumentoDA(IRepositorioDapper repositorioDapper, IConfiguration configuration)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
            _configuration = configuration;
        }

        public async Task<Guid> Agregar(DocumentoContenido documento, Guid id)
        {
            var ruta= _configuration.GetSection("RutaDocumentos").Value;
            string sql = @"AgregarDocumento";
            await _sqlConnection.QueryAsync<Guid>(sql, new {  Id = id, Nombre = documento.Nombre, Ruta= ruta, Tipo= ObtenerTipo(documento.Nombre) });
            return id;
        }


        public async Task<IEnumerable<DocumentoSinContenido>> Obtener()
        {
            try
            {
                string sql = @"ObtenerDocumentos";
                var resultadoConsulta = await _sqlConnection.QueryAsync<DocumentoSinContenido>(sql);
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo las documentos de la BD");
            }
        }

        public async Task<DocumentoConContenido> ObtenerPorId(Guid? Id)
        {
            string sql = @"ObtenerDocumento";
            var resultadoConsulta = await _sqlConnection.QueryAsync<DocumentoConContenido>(sql, new { Id = Id });
            if (resultadoConsulta == null)
                return null;
            return resultadoConsulta.FirstOrDefault();
        }

        private string ObtenerTipo(string nombre)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(nombre, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
