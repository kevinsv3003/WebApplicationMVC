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
    public class MarcaOperacion : IMarcaDominio
    {
        private readonly IMarca marcaRepo;

        public MarcaOperacion(IMarca marcaRepo)
        {
            this.marcaRepo = marcaRepo;
        }
        public List<MarcaDto> ObtenerListaMarca()
        {
            var marcas = new List<MarcaDto>();
            try
            {
                marcas = (from m in marcaRepo.ListarTodos()
                        select new MarcaDto
                        {
                            IdMarca = m.IdMarca,
                            Nombre = m.Nombre,
                            Descripcion = m.Descripcion
                        }).ToList();

                return marcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un problema al consultar las marcas");
            }
        }
    }
}
