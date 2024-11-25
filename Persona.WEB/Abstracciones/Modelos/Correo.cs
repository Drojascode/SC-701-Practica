using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Correo
    {
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Destinatario { get; set; }
        public IEnumerable<DocumentoContenido>? Adjuntos { get; set; }
    }
    public class CorreoConfiguracion
    {
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Puerto { get; set; }
    }
}
