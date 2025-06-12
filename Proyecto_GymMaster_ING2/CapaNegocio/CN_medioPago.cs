using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_medioPago
    {
        private CD_medioPago objcd_medioPago = new CD_medioPago();

        public List<MedioPago> Listar()
        {
            return objcd_medioPago.Listar();
        }

    }
}
