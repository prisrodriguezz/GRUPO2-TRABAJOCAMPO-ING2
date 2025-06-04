using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_usuario
    {
        public List<Usuario> Listar(){
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena)) {
                try
                {

                    string query = "SELECT u.id_usuario, u.id_rol, r.descripcion AS rol_descripcion, u.nombre, u.email, u.telefono, u.dni, u.fecha_nacimiento, u.estado, u.contraseña, u.apellido " +
                               "FROM Usuario u " +
                               "JOIN Rol r ON u.id_rol = r.id_rol";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                id_rol = new Rol { id_rol = Convert.ToInt32(dr["id_rol"]),
                                                   descripcion = dr["rol_descripcion"].ToString()},
                                nombre = dr["nombre"].ToString(),
                                email = dr["email"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                dni = dr["dni"].ToString(),
                                fecha_nacimiento = dr["fecha_nacimiento"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                contraseña = dr["contraseña"].ToString(),
                                apellido = dr["apellido"].ToString()


                            });
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                    //lista = new List<Usuario>();
                }
            }
            return lista;
        }

        public List<Usuario> ListarCoachs()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    string query = "SELECT u.id_usuario, u.id_rol, r.descripcion AS rol_descripcion, u.nombre, u.email, u.telefono, u.dni, u.fecha_nacimiento, u.estado, u.contraseña, u.apellido " +
                               "FROM Usuario u where u.id_rol = 2" +
                               "JOIN Rol r ON u.id_rol = r.id_rol";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                id_rol = new Rol
                                {
                                    id_rol = Convert.ToInt32(dr["id_rol"]),
                                    descripcion = dr["rol_descripcion"].ToString()
                                },
                                nombre = dr["nombre"].ToString(),
                                email = dr["email"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                dni = dr["dni"].ToString(),
                                fecha_nacimiento = dr["fecha_nacimiento"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                contraseña = dr["contraseña"].ToString(),
                                apellido = dr["apellido"].ToString()


                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    //lista = new List<Usuario>();
                }
            }
            return lista;
        }

    }
}
