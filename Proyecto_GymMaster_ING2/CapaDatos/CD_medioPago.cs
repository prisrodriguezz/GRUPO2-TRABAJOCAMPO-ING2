using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_medioPago
    {
        public List<MedioPago> Listar()
        {
            List<MedioPago> lista = new List<MedioPago>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT id_medioPago, nombre, comision, fechaCreacion, estado FROM MedioDePago");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new MedioPago()
                            {
                                id_medioPago = Convert.ToInt32(dr["id_medioPago"]),
                                nombre = dr["nombre"].ToString(),
                                comision = Convert.ToDecimal(dr["comision"]),
                                fechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]),
                                estado = Convert.ToBoolean(dr["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<MedioPago>();
                }
            }
            return lista;
        }


        public int Agregar(MedioPago medioPago, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_AGREGAR_MEDIOPAGO", conexion);
                cmd.Parameters.AddWithValue("@nombre", medioPago.nombre);
                cmd.Parameters.AddWithValue("@comision", medioPago.comision);
                cmd.Parameters.AddWithValue("@fechaCreacion", medioPago.fechaCreacion);
                cmd.Parameters.AddWithValue("@estado", medioPago.estado);

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


        public int Editar(MedioPago medioPago, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_EDITAR_MEDIOPAGO", conexion);
                cmd.Parameters.AddWithValue("@id_medioPago", medioPago.id_medioPago);
                cmd.Parameters.AddWithValue("@nombre", medioPago.nombre);
                cmd.Parameters.AddWithValue("@comision", medioPago.comision);
                cmd.Parameters.AddWithValue("@fechaCreacion", medioPago.fechaCreacion);
                cmd.Parameters.AddWithValue("@estado", medioPago.estado);

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
