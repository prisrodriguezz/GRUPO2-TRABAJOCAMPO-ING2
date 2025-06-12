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
    }
}
