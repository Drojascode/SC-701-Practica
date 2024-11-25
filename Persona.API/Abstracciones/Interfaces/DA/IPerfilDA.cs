using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IPerfilDA
    {
        Task<PerfilBD> Obtener(Guid Id);
        Task<Guid> Agregar(PerfilBD perfil);
    }
}
