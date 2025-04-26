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
        // Método para listar los ejercicios
        public List<Ejercicio> Listar()
        {
            List<Ejercicio> lista = new List<Ejercicio>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_EJERCICIOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Ejercicio
                        {
                            id_ejercicio = Convert.ToInt32(reader["id_ejercicio"]),
                            nombre = reader["nombre"].ToString(),
                            repeticiones = Convert.ToInt32(reader["repeticiones"]),
                            tiempo = Convert.ToInt32(reader["tiempo"])
                        });
                    }
                }
        }
=======
            }
>>>>>>> 014eb1249acc6ca0d0bc8f3d2b01addfce1c1fe5
            return lista;
        }
    }
}
