using Datos.Contratos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoria
    {
        public CategoriaRepositorio() : base(new PruebaKsvEntities())
        {
        }
    }
}
