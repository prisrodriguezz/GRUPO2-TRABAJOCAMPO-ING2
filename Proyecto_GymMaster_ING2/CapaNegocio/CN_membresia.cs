using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_membresia
    {
        private CD_membresia objCD_Membresia = new CD_membresia();

        public List<Membresia> Listar()
        {
            return objCD_Membresia.Listar(); // Llama al método que obtiene los datos de la base de datos
        }

        public int Agregar(Membresia membresia, out string mensaje)
        {
            return objCD_Membresia.Agregar(membresia, out mensaje);
        }

        public int Editar(Membresia membresia, out string mensaje)
        {
            return objCD_Membresia.Editar(membresia, out mensaje);
        }
    }
}
