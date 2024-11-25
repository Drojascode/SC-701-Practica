using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Flujo.Helper;

namespace Flujo
{
    public class CorreoFlujo : ICorreoFlujo
    {
        private ICorreoServicio _correoServicio;

        public CorreoFlujo(ICorreoServicio correoServicio)
        {
            _correoServicio = correoServicio;

        }

        public Task Enviar(Correo correo)
        {
            return _correoServicio.Enviar(correo);
        }
    }
}
