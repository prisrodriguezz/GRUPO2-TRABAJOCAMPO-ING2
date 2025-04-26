using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int id_usuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                
            }
            return lista;
        }
    }
}
