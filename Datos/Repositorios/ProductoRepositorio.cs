using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos.Contratos;
using System.Data;

namespace Datos.Repositorios
{
    public class ProductoRepositorio : BaseRepositorio<Producto>, IProducto
    {

        public ProductoRepositorio() : base(new PruebaKsvEntities())
        {

        }

        public List<Producto> ObtenerProductosDatos()
        {

            var resultado = BaseDatosColeccion.ToList();

                return resultado;
        }
    }
}
