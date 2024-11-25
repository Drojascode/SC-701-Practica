using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class PerfilPersona
    {
        public Guid IdPersona { get; set; }
        public string? Video { get; set; }
    }
    public class PerfilBD:PerfilPersona
    {        
        public Guid? Curriculum { get; set; }
        public Guid? Foto { get; set; }

    }
    public class PerfilRequest:PerfilPersona
    {
        public DocumentoContenido? Curriculum { get; set; }
        public DocumentoContenido? Foto { get; set; }

    }
}
