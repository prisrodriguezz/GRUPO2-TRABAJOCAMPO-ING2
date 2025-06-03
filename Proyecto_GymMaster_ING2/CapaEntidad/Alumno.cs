using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Alumno
    {
        public int id_alumno { get; set; }
        public int id_usuario { get; set; }
        public int id_membresia { get; set; }
        public int id_plan { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
        public string dni { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string contacto_emergencia { get; set; }
        public string sexo { get; set; }
        public string observaciones { get; set; }
        public Boolean estado { get; set; }
    }
}
