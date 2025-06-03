using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Membresia
    {
        public int id_membresia { get; set; }
        public string nombre { get; set; }
        public int duracion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public decimal costo { get; set; }
        public Boolean estado { get; set; }
    }
}
