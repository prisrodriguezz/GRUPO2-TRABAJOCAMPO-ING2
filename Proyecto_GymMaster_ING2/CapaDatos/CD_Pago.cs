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
    public class CD_Pago
    {
        public int RegistrarPago(Pago pago)
        {
            int idPago = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_PAGO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@id_usuario", pago.id_usuario.id_usuario);
                cmd.Parameters.AddWithValue("@id_alumno", pago.id_alumno.id_alumno);
                cmd.Parameters.AddWithValue("@id_medioPago", pago.id_medioPago.id_medioPago);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@cantidad", pago.cantidad);
                cmd.Parameters.AddWithValue("@total", pago.total);
                cmd.Parameters.AddWithValue("@recargo", pago.recargo);

                // Parámetro de salida
                SqlParameter outputIdPago = new SqlParameter("@id_pago", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdPago);

                conexion.Open();
                cmd.ExecuteNonQuery();

                // Asignar el id_pago de salida a la variable
                idPago = Convert.ToInt32(outputIdPago.Value);
            }

            return idPago;
        }


        public bool RegistrarPagoDetalle(PagoDetalle detalle)
        {
            bool resultado = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_PAGO_DETALLE", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pago", detalle.id_pago.id_pago);
                cmd.Parameters.AddWithValue("@id_membresia", detalle.id_membresia.id_membresia);
                cmd.Parameters.AddWithValue("@periodo", detalle.periodo);
                cmd.Parameters.AddWithValue("@monto", detalle.monto);

                conexion.Open();
                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }

        public List<Pago> ListarPagos()
        {
            List<Pago> listaPagos = new List<Pago>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_PAGOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pago pago = new Pago
                        {
                            id_pago = Convert.ToInt32(dr["id_pago"]),
                            id_usuario = new Usuario { id_usuario = Convert.ToInt32(dr["id_usuario"]) },
                            id_alumno = new Alumno { id_alumno = Convert.ToInt32(dr["id_alumno"]) },
                            id_medioPago = new MedioPago { id_medioPago = Convert.ToInt32(dr["id_medioPago"]) },
                            fecha = dr["fecha"].ToString(),
                            cantidad = Convert.ToDecimal(dr["cantidad"]),
                            total = Convert.ToDecimal(dr["total"]),
                            recargo = Convert.ToDecimal(dr["recargo"])
                        };
                        listaPagos.Add(pago);
                    }
                }
            }

            return listaPagos;
        }



        public List<PagoDetalle> ListarPagoDetalles(int idPago)
        {
            List<PagoDetalle> listaDetalles = new List<PagoDetalle>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_DETALLES_PAGO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pago", idPago);

                conexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PagoDetalle detalle = new PagoDetalle
                        {
                            id_pagoDetalle = Convert.ToInt32(dr["id_pagoDetalle"]),
                            id_pago = new Pago { id_pago = Convert.ToInt32(dr["id_pago"]) },
                            id_membresia = new Membresia { id_membresia = Convert.ToInt32(dr["id_membresia"]) },
                            periodo = Convert.ToInt32(dr["periodo"]),
                            monto = Convert.ToDecimal(dr["monto"])
                        };
                        listaDetalles.Add(detalle);
                    }
                }
            }

            return listaDetalles;
        }


        public List<FechaAdeudada> ObtenerFechasAdeudadas(int idAlumno)
        {
            List<FechaAdeudada> fechas = new List<FechaAdeudada>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerFechasAdeudadas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_alumno", idAlumno);

                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Leer los resultados
                    while (reader.Read())
                    {
                        fechas.Add(new FechaAdeudada
                        {
                            IdAlumno = Convert.ToInt32(reader["id_alumno"]),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            DniAlumno = Convert.ToInt32(reader["dni"]),
                            FechasAdeudada = Convert.ToDateTime(reader["fecha_adeudada"]),
                            NombreMembresia = reader["nombreMembresia"].ToString(),
                            CostoMembresia = Convert.ToDecimal(reader["costo"])
                        });

                    }
                }

            }

            return fechas;
        }
    }
}
