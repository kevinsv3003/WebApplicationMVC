using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDto;
using Datos.Contratos;
using Datos.Repositorios;
using AutoMapper;
using Entidades;

namespace Dominio.ReglasNegocio
{
    public class ProductoOperacion : IProductoDominio
    {
        private readonly IProducto productoRepo;
        private readonly IMarca marcaRepo;
        private readonly ICategoria categoriaRepo;

        public ProductoOperacion(IProducto pro, IMarca marcaRepo, ICategoria categoriaRepo)
        {
            this.productoRepo = pro;
            this.marcaRepo = marcaRepo;
            this.categoriaRepo = categoriaRepo;

        }

        public bool ActualizarProducto(ProductoDto pro)
        {
            var retorno = false;
            try
            {
                var producto = Mapper.Map<ProductoDto, Producto>(pro);
                productoRepo.Actualizar(producto);
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al registrar Producto");
            }

            return retorno;
        }

        public bool AgregarProducto(ProductoDto pro)
        {
            var retorno = false;
            try
            {
                var productoId = productoRepo.ListarTodos().LastOrDefault().IdProducto;
                pro.IdProducto = productoId + 1;
                var producto = Mapper.Map<ProductoDto, Producto>(pro);

                productoRepo.Insertar(producto);
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al registrar Producto");
            }

            return retorno;
        }

        public List<ProductoDto> ObtenerListaProductos()
        {
            var resultado = new List<ProductoDto>();

            try
            {
                resultado = (from p in productoRepo.ObtenerProductosDatos()
                             join c in categoriaRepo.ListarTodos() on p.IdCategoria equals c.IdCategoria
                             join m in marcaRepo.ListarTodos() on p.IdMarca equals m.IdMarca
                             select new ProductoDto
                             {
                                 IdProducto = p.IdProducto,
                                 Nombre = p.Nombre,
                                 Descripcion = p.Descripcion,
                                 Marca_nombre = m.Nombre,
                                 Categoria_nombre = c.Descripcion
                             }).ToList();


                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al consultar los Productos");
            }
        }

        public ProductoDto ObtenerProductoPorId(int id)
        {
            var producto = new ProductoDto();

            try
            {
                //resultado = productoRepo.Buscar(p => p.IdProducto == id).FirstOrDefault();
                 producto = (from p in productoRepo.ObtenerProductosDatos()
                                join c in categoriaRepo.ListarTodos() on p.IdCategoria equals c.IdCategoria
                                join m in marcaRepo.ListarTodos() on p.IdMarca equals m.IdMarca
                                where p.IdProducto == id
                                select new ProductoDto
                                {
                                    IdProducto = p.IdProducto,
                                    Nombre = p.Nombre,
                                    Descripcion = p.Descripcion,
                                    Marca_nombre = m.Nombre,
                                    Categoria_nombre = c.Descripcion
                                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al consultar los Productos");
            }
            return producto;
        }
        
    }
}
