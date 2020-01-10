using Datos.Contratos;
using Dominio.Contratos;
using Dominio.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ReglasNegocio
{
    public class CategoriaOperacion : ICategoriaDominio
    {
        private readonly ICategoria catRepo;

        public CategoriaOperacion(ICategoria catRepo)
        {
            this.catRepo = catRepo;
        }
        public List<CategoriaDto> ObtenerListaCategoria()
        {
            var categoria = new List<CategoriaDto>();
            try
            {
                categoria = (from c in catRepo.ListarTodos()
                          select new CategoriaDto
                          {
                              IdCategoria = c.IdCategoria,
                              Tipo = c.Tipo,
                              Descripcion = c.Descripcion
                          }).ToList();

                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al consultar las marcas");
            }
        }
    }
    
}
