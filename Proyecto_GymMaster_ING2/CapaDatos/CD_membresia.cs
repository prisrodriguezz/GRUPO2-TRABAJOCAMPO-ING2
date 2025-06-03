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
    public class CD_membresia
    {
        public List<Membresia> Listar()
        {
            List<Membresia> lista = new List<Membresia>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTARMEMBRESIAS", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Membresia()
                            {
                                id_membresia = Convert.ToInt32(dr["id_membresia"]),
                                nombre = dr["nombre"].ToString(),
                                duracion = Convert.ToInt32(dr["duracion"]),
                                fecha_creacion = Convert.ToDateTime(dr["fecha_creacion"]), // No convertir a string
                                costo = Convert.ToDecimal(dr["costo"]),
                                estado = Convert.ToBoolean(dr["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Membresia>();
                    // Manejo de errores opcional
                }
            }
            return lista;
        }


        public int Agregar(Membresia membresia, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_AGREGAR_MEMBRESIA", conexion);
                cmd.Parameters.AddWithValue("@nombre", membresia.nombre);
                cmd.Parameters.AddWithValue("@duracion", membresia.duracion);
                cmd.Parameters.AddWithValue("@fecha_creacion", membresia.fecha_creacion);
                cmd.Parameters.AddWithValue("@costo", membresia.costo);
                cmd.Parameters.AddWithValue("@estado", membresia.estado);

                cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToInt32(cmd.Parameters["@respuesta"].Value);
                mensaje = cmd.Parameters["@mensaje"].Value.ToString();
            }
            return resultado;
        }


        public int Editar(Membresia membresia, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_EDITAR_MEMBRESIA", conexion);
                cmd.Parameters.AddWithValue("@id_membresia", membresia.id_membresia);
                cmd.Parameters.AddWithValue("@nombre", membresia.nombre);
                cmd.Parameters.AddWithValue("@duracion", membresia.duracion);
                cmd.Parameters.AddWithValue("@fecha_creacion", membresia.fecha_creacion);
                cmd.Parameters.AddWithValue("@costo", membresia.costo);
                cmd.Parameters.AddWithValue("@estado", membresia.estado);

                cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToInt32(cmd.Parameters["@respuesta"].Value);
                mensaje = cmd.Parameters["@mensaje"].Value.ToString();
            }
            return resultado;
        }
    }
}
