using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        public int id_pago { get; set; }
        public Usuario id_usuario { get; set; }
        public Alumno id_alumno { get; set; }
        public MedioPago id_medioPago { get; set; }
        public string fecha { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public decimal recargo { get; set; }
    }
}
