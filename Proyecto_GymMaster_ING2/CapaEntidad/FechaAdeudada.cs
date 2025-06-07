using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class FechaAdeudada
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DniAlumno { get; set; }
        public DateTime FechasAdeudada { get; set; }
        public string NombreMembresia { get; set; }
        public Decimal CostoMembresia { get; set; }
    }

}
