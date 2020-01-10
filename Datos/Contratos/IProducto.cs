using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contratos
{
    public interface IProducto : IBaseRepositorio<Producto>
    {
        List<Producto> ObtenerProductosDatos();
    }
}
