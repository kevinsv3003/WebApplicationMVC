using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDto;

namespace Dominio.Contratos
{
    public interface IProductoDominio
    {
        ProductoDto ObtenerProductoPorId(int id);
        List<ProductoDto> ObtenerListaProductos();
        bool AgregarProducto(ProductoDto pro);
        bool ActualizarProducto(ProductoDto pro);
    }
}
