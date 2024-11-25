using Abstracciones.DA;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA.Dapper
{
    public class PersonaDA : IPersonaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public PersonaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> Agregar(Persona persona)
        {
            string sql = @"AgregarPersona";
            var resultadoConsulta=await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new {  Identificacion = persona.Identificacion, Nombre = persona.Nombre, Apellido=persona.Apellido });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, Persona persona)
        {
            string sql = @"EditarPersona";
            PersonaBD? resultadoConsultaPersona = await ObtenerPersona(Id);
            if (resultadoConsultaPersona == null)
                return Guid.Empty;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id=Id,Identificacion = persona.Identificacion, Nombre=persona.Nombre, Apellido=persona.Apellido });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            string sql = @"EliminarPersona";
            PersonaBD? resultadoConsultaPersona = await ObtenerPersona(Id);
            if (resultadoConsultaPersona == null)
                return Guid.Empty;
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<PersonaBD>> Obtener()
        {
            try
            {
                string sql = @"ObtenerPersonas";
                var resultadoConsulta = await _sqlConnection.QueryAsync<PersonaBD>(sql);
                return resultadoConsulta;
            }
            catch (Exception)
            {

                throw new Exception("Error obteniendo las personas de la BD");
            }
        }

        public async Task<PersonaBD> Obtener(Guid Id)
        {
            PersonaBD? resultadoConsulta = await ObtenerPersona(Id);
            if (resultadoConsulta==null)
                return null;
            return resultadoConsulta;
        }

        private async Task<PersonaBD?> ObtenerPersona(Guid Id)
        {
            string sql = @"ObtenerPersona";
            var resultadoConsulta = await _sqlConnection.QueryAsync<PersonaBD>(sql, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }
    }
}
