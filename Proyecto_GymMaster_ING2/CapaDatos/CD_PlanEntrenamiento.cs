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
    public class CD_PlanEntrenamiento
    {
        // Método para listar los planes de entrenamiento
        public List<PlanEntrenamiento> Listar()
        {
            List<PlanEntrenamiento> lista = new List<PlanEntrenamiento>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_PLAN_ENTRENAMIENTO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new PlanEntrenamiento
                        {
                            id_plan = Convert.ToInt32(reader["id_plan"]),
                            nombre = reader["nombre"].ToString(),
                            fechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                            fechaFin = Convert.ToDateTime(reader["fechaFin"]),
                            cantSeries = Convert.ToInt32(reader["cantSeries"]),
                            estado = Convert.ToBoolean(reader["estado"])
                        });
                    }
                }
            }
            return lista;
        }

        // Método para agregar un nuevo plan de entrenamiento
        public int Agregar(PlanEntrenamiento plan, out string mensaje)
        {
            int idPlanGenerado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_AGREGAR_PLAN_ENTRENAMIENTO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@nombre", plan.nombre);
                cmd.Parameters.AddWithValue("@fechaInicio", plan.fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", plan.fechaFin);
                cmd.Parameters.AddWithValue("@cantSeries", plan.cantSeries);
                cmd.Parameters.AddWithValue("@estado", plan.estado);

                // Parámetros de salida
                SqlParameter respuestaParam = new SqlParameter("@respuesta", SqlDbType.Int);
                respuestaParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(respuestaParam);

                SqlParameter mensajeParam = new SqlParameter("@mensaje", SqlDbType.VarChar, 500);
                mensajeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(mensajeParam);

                conexion.Open();
                cmd.ExecuteNonQuery();

                // Obtener los valores de salida
                idPlanGenerado = Convert.ToInt32(respuestaParam.Value);  // El ID del plan generado
                mensaje = mensajeParam.Value.ToString();
            }

            return idPlanGenerado;  // Retorna el ID del plan generado
        }

        // Metodo para asociar ejercicios con el plan
        public void AsociarEjercicio(int idPlan, int idEjercicio)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ASOCIAR_PLAN_EJERCICIO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_plan", idPlan);
                cmd.Parameters.AddWithValue("@id_ejercicio", idEjercicio);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Metodo para asociar usuarios con el plan
        public void AsociarUsuario(int idUsuario, int idPlan)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ASOCIAR_USUARIO_PLAN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@id_plan", idPlan);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // Método para editar un plan de entrenamiento
        public int Editar(PlanEntrenamiento plan, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_EDITAR_PLAN_ENTRENAMIENTO", conexion);
                cmd.Parameters.AddWithValue("@id_plan", plan.id_plan);
                cmd.Parameters.AddWithValue("@nombre", plan.nombre);
                cmd.Parameters.AddWithValue("@fechaInicio", plan.fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", plan.fechaFin);
                cmd.Parameters.AddWithValue("@cantSeries", plan.cantSeries);
                cmd.Parameters.AddWithValue("@estado", plan.estado);

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


        // Metodos para realizar la modificacion de ejercicios/usuarios con el plan
        public void EliminarPlan_Ejercicio(int idPlan)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PLAN_EJERCICIO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_plan", idPlan);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPlan_Usuario(int idPlan)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO_PLAN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_plan", idPlan);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para eliminar un plan de entrenamiento
        public int Eliminar(int id_plan, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PLAN_ENTRENAMIENTO", conexion);
                cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = id_plan;
                cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["@respuesta"].Value);
                    mensaje = cmd.Parameters["@mensaje"].Value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    mensaje = $"Error: {ex.Message}";
                }
            }

            return resultado;
        }


        // Metodo para restaurar un plan de entrenamiento
        public int Restaurar(int id_plan, out string mensaje)
        {
            int resultado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_RESTAURAR_PLAN_ENTRENAMIENTO", conexion);
                cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = id_plan;
                cmd.Parameters.Add("@respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["@respuesta"].Value);
                    mensaje = cmd.Parameters["@mensaje"].Value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    mensaje = $"Error: {ex.Message}";
                }
            }

            return resultado;
        }


        public PlanEntrenamiento ObtenerPlanPorID(int idPlan, out string mensaje)
        {
            PlanEntrenamiento plan = null;
            mensaje = string.Empty;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENER_PLAN_ENTRENAMIENTO_PORID", conexion);
                    cmd.Parameters.AddWithValue("@id_plan", idPlan);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        plan = new PlanEntrenamiento
                        {
                            id_plan = Convert.ToInt32(reader["id_plan"]),
                            nombre = reader["nombre"].ToString(),
                            fechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                            fechaFin = Convert.ToDateTime(reader["fechaFin"]),
                            cantSeries = Convert.ToInt32(reader["cantSeries"]),
                            estado = Convert.ToBoolean(reader["estado"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message; // Captura el mensaje de error
                }
            }

            return plan;
        }


        // METODOS PARA LISTAR EJERCICIOS Y COACHS EN BASE AL ID_PLAN
        public List<Ejercicio> ListarEjerciciosPorPlan(int idPlan)
        {
            List<Ejercicio> lista = new List<Ejercicio>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_EJERCICIOS_POR_PLAN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro que está esperando el procedimiento almacenado
                cmd.Parameters.AddWithValue("@id_plan", idPlan);

                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Ejercicio()
                    {
                        id_ejercicio = Convert.ToInt32(dr["id_ejercicio"]),
                        nombre = dr["nombre"].ToString(),
                        repeticiones = Convert.ToInt32(dr["repeticiones"]),
                        tiempo = Convert.ToInt32(dr["tiempo"])
                    });
                }
                dr.Close();
            }

            return lista;
        }


        public List<Usuario> ListarCoachsPorPlan(int idPlan)
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_COACHS_POR_PLAN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro que está esperando el procedimiento almacenado
                cmd.Parameters.AddWithValue("@id_plan", idPlan);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario coach = new Usuario
                    {
                        id_usuario = Convert.ToInt32(reader["id_usuario"]),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        dni = reader["dni"].ToString(),
                        email = reader["email"].ToString(),
                        fecha_nacimiento = reader["fecha_nacimiento"].ToString(),
                        telefono = reader["telefono"].ToString()
                    };
                    lista.Add(coach);
                }
                reader.Close();
            }

            return lista;
        }



        public List<PlanEntrenamiento> ListarPlanesPorCoachs(int idUsuario)
        {
            List<PlanEntrenamiento> listaPlanes = new List<PlanEntrenamiento>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_PLAN_POR_COACHS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro que está esperando el procedimiento almacenado
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PlanEntrenamiento plan = new PlanEntrenamiento
                    {
                        id_plan = Convert.ToInt32(reader["id_plan"]),
                        nombre = reader["nombre"].ToString(),
                        fechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                        fechaFin = Convert.ToDateTime(reader["fechaFin"]),
                        cantSeries = Convert.ToInt32(reader["cantSeries"]),
                        estado = Convert.ToBoolean(reader["estado"])
                    };
                    listaPlanes.Add(plan);
                }
                reader.Close();
            }

            return listaPlanes;
        }


    }
}
