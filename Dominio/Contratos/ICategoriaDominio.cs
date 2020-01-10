using Dominio.EntidadesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface ICategoriaDominio
    {
        List<CategoriaDto> ObtenerListaCategoria();
    }
}
