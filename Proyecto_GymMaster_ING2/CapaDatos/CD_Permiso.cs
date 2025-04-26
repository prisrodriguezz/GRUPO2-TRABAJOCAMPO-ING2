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
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.id_rol, p.nombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.id_rol = p.id_rol");
                    query.AppendLine("inner join USUARIO u on u.id_rol = r.id_rol");
                    query.AppendLine("where u.id_usuario = @id_usuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                id_rol = new Rol() { id_rol = Convert.ToInt32(dr["id_rol"]) },
                                nombreMenu = dr["nombreMenu"].ToString(),

                            }) ;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    //lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
