using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public Rol id_rol { get; set; }
        public string nombre { get; set; }
        public string email { get;set; }
        public string telefono { get; set; }
        public string dni { get; set; }
        public string fecha_nacimiento { get; set; }
        public Boolean estado { get; set; }
        public string contraseña { get; set; }
        public string apellido { get; set; }

    }
}
