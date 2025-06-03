using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PagoDetalle
    {
        public int id_pagoDetalle { get; set; }
        //public Pago id_pago { get; set; }
        public Membresia id_membresia { get; set; }
        public int periodo { get; set; }
        public decimal monto { get; set; }
    }
}
