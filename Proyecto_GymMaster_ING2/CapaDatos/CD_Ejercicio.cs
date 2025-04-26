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
                            repeticiones = reader["repeticiones"] != DBNull.Value ? Convert.ToInt32(reader["repeticiones"]) : 0,
                            tiempo = reader["tiempo"] != DBNull.Value ? Convert.ToInt32(reader["tiempo"]) : 0
                            //repeticiones = Convert.ToInt32(reader["repeticiones"]),
                            //tiempo = Convert.ToInt32(reader["tiempo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
