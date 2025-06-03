using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaNegocio
{
    public class CN_Pago
    {
        private CD_Pago objPago = new CD_Pago();
        public int ProcesarPago(Pago pago, List<PagoDetalle> detalles)
        {
            int idPago = objPago.RegistrarPago(pago);  // Registrar el pago y obtener el ID generado

            if (idPago > 0)
            {
                foreach (var detalle in detalles)
                {
                    detalle.id_pago = new Pago { id_pago = idPago };  // Asignar el ID de pago al detalle
                    if (!objPago.RegistrarPagoDetalle(detalle))
                    {
                        return -1;  // Si falla la inserción de algún detalle, retornar -1 indicando error
                    }
                }
                return idPago;
            }

            return -1; // Si no se generó el pago, retornar -1
        }


        public List<Pago> ListarPagos()
        {
            return objPago.ListarPagos();
        }

        public List<PagoDetalle> ListarPagoDetalles(int idPago)
        {
            return objPago.ListarPagoDetalles(idPago);
        }



        public List<FechaAdeudada> ObtenerFechasAdeudadas(int idAlumno)
        {
            return objPago.ObtenerFechasAdeudadas(idAlumno);
        }
    }
}
