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
    public class CD_Alumno
    {
        public List<Alumno> Listar()
        {
            List<Alumno> lista = new List<Alumno>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM Alumno";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Alumno()
                            {
                                id_alumno = Convert.ToInt32(dr["id_alumno"]),
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                id_membresia = Convert.ToInt32(dr["id_membresia"]),
                                id_plan = Convert.ToInt32(dr["id_plan"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                email = dr["email"].ToString(),
                                telefono = dr["telefono"].ToString(),
                                foto = dr["foto"].ToString(),
                                dni = dr["dni"].ToString(),
                                fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),
                                contacto_emergencia = dr["contacto_emergencia"].ToString(),
                                sexo = dr["sexo"].ToString(),
                                observaciones = dr["observaciones"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Alumno>();
                    throw ex;
                }
            }
            return lista;
        }

        // Registro de un nuevo alumno
        public int Registrar(Alumno obj, out string mensaje)
        {
            int idAlumnoGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARALUMNO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros de entrada
                    cmd.Parameters.AddWithValue("id_usuario", obj.id_usuario);
                    cmd.Parameters.AddWithValue("id_membresia", obj.id_membresia);
                    cmd.Parameters.AddWithValue("id_plan", obj.id_plan);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("foto", obj.foto);
                    cmd.Parameters.AddWithValue("dni", obj.dni);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("contacto_emergencia", obj.contacto_emergencia);
                    cmd.Parameters.AddWithValue("sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("estado", obj.estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("idUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    idAlumnoGenerado = Convert.ToInt32(cmd.Parameters["idUsuarioResultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idAlumnoGenerado = 0;
                mensaje = "Error al registrar el alumno: " + ex.Message;
            }

            return idAlumnoGenerado;
        }

        // Baja de alumno
        public bool EliminarAlumno(int idAlumno, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARALUMNO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    cmd.Parameters.AddWithValue("id_alumno", idAlumno);

                    // Parámetros de salida
                    SqlParameter parametroRespuesta = new SqlParameter("respuesta", SqlDbType.Bit);
                    parametroRespuesta.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parametroRespuesta);

                    SqlParameter parametroMensaje = new SqlParameter("mensaje", SqlDbType.VarChar, 500);
                    parametroMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parametroMensaje);

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener los valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al dar de baja al alumno" + ex.Message;
            }

            return respuesta;
        }

        // Alta de alumno
        public bool RestaurarAlumno(int idAlumno, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RESTAURARALUMNO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    cmd.Parameters.AddWithValue("id_alumno", idAlumno);

                    // Parámetros de salida
                    SqlParameter parametroRespuesta = new SqlParameter("respuesta", SqlDbType.Bit);
                    parametroRespuesta.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parametroRespuesta);

                    SqlParameter parametroMensaje = new SqlParameter("mensaje", SqlDbType.VarChar, 500);
                    parametroMensaje.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parametroMensaje);

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener los valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al dar de alta al alumno" + ex.Message;
            }

            return respuesta;
        }


        // Verificar si el alumno tiene la cuota al dia
        public bool VerificarCuotaAlumno(int idAlumno, out int mesesAdeudados, out string cuotaAlDia)
        {
            bool resultado = false;
            mesesAdeudados = 0;
            cuotaAlDia = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_VerificarCuotaAlumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    cmd.Parameters.AddWithValue("id_alumno", idAlumno);

                    // Parámetros de salida
                    cmd.Parameters.Add("cuotaAlDia", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mesesAdeudados", SqlDbType.Int).Direction = ParameterDirection.Output;

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener los valores de los parámetros de salida
                    cuotaAlDia = cmd.Parameters["cuotaAlDia"].Value.ToString();
                    mesesAdeudados = Convert.ToInt32(cmd.Parameters["mesesAdeudados"].Value);

                    // Determinar el resultado de la cuota
                    resultado = cuotaAlDia == "Si";
                }
            }
            catch (Exception ex)
            {
                cuotaAlDia = "Error al verificar la cuota: " + ex.Message;
                resultado = false;
            }

            return resultado;
        }


        // Modificacion de un alumno
        public bool Editar(Alumno obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARALUMNO", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros de entrada
                    cmd.Parameters.AddWithValue("id_alumno", obj.id_alumno);
                    cmd.Parameters.AddWithValue("id_usuario", obj.id_usuario);
                    cmd.Parameters.AddWithValue("id_membresia", obj.id_membresia);
                    cmd.Parameters.AddWithValue("id_plan", obj.id_plan);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("apellido", obj.apellido);
                    cmd.Parameters.AddWithValue("email", obj.email);
                    cmd.Parameters.AddWithValue("telefono", obj.telefono);
                    cmd.Parameters.AddWithValue("foto", obj.foto);
                    cmd.Parameters.AddWithValue("dni", obj.dni);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", obj.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("contacto_emergencia", obj.contacto_emergencia);
                    cmd.Parameters.AddWithValue("sexo", obj.sexo);
                    cmd.Parameters.AddWithValue("observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("estado", obj.estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener valores de los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }

    }
}
