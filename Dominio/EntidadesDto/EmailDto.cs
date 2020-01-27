using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDto
{
   public class EmailDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string BodyEmail { get; set; }
        public string NuevaPass { get; set; }
    }
}
