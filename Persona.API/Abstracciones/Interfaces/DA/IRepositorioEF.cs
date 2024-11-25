
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IRepositorioEF
    {
        public DbSet<PersonaBD> Personas { get; set; }
        public DbContext ObtenerRepositorioEF();
    }
}
