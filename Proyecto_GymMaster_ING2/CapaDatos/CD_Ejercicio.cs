using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Ejercicio
    {
        public List<Ejercicio> Listar()
        {
            List<Ejercicio> lista = new List<Ejercicio>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                // a realizar
            }
            return lista;
        }
    }
}
