using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Documento
    {
        public string Nombre { get; set; }
    }
    public class DocumentoContenido:Documento
    {        
        public byte[] Contenido { get; set; }        
    }
    public class DocumentoSinContenido : Documento
    {
        public Guid Id { get; set; }
        public string Ruta { get; set; }
        public string Tipo { get; set; }
    }
    public class DocumentoConContenido : DocumentoContenido
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
    }

}
