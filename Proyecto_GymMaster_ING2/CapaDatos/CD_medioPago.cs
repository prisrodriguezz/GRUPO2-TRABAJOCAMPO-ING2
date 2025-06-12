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
    }
}
