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
    public class CD_rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select id_rol, descripcion from Rol p");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                id_rol = Convert.ToInt32(dr["id_rol"]),
                                descripcion = dr["descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    //lista = new List<Rol>();
                }
            }
            return lista;
        }


    }
}
