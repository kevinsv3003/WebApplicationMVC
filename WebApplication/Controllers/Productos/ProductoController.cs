
using Dominio.Contratos;
using Dominio.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.Productos
{
    public class ProductoController : Controller
    {
        private readonly IProductoDominio productoDominio;
        private readonly IMarcaDominio marcaDominio;
        private readonly ICategoriaDominio categoriaDominio;

        public ProductoController(IProductoDominio prod, IMarcaDominio marcaDominio, ICategoriaDominio categoriaDominio)
        {
            this.productoDominio = prod;
            this.marcaDominio = marcaDominio;
            this.categoriaDominio = categoriaDominio;
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaProductoTabla()
        {
            var listaProducto = productoDominio.ObtenerListaProductos();
            return PartialView(listaProducto);
        }

        public ActionResult _ListaProductoCuadros()
        {
            var listaProducto = productoDominio.ObtenerListaProductos();
            return PartialView(listaProducto);
        }

        public async Task<ActionResult> _DetallesProducto(int productoId)
        {
            var producto = productoDominio.ObtenerProductoPorId(productoId);
            return PartialView(producto);
        }

        public ActionResult _detalleProducto(ProductoDto pro)
        {
            return PartialView("_DetallesProducto", pro);
        }

        public ActionResult _FormularioNuevoProducto()
        {
            var marcas = marcaDominio.ObtenerListaMarca();
            var categorias = categoriaDominio.ObtenerListaCategoria();
            
            ViewBag.Marcas = marcas;
            ViewBag.Categorias = categorias;
            return PartialView();
        }

        public ActionResult GuardarProducto(ProductoDto pro)
        {
            var message = string.Empty;
            try
            {
                var retorno = productoDominio.AgregarProducto(pro);
                message = "Se registró el producto correctamente!!";
            }
            catch(Exception ex)
            {
                return Json(new { message = ex.Message });
            }
            return Json(new { message = message });
        }
    }
}