using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class DetalleDePago : Form
    {
        private CN_Alumno objCN_Alumno = new CN_Alumno();
        private CN_medioPago objCN_MedioPago = new CN_medioPago();

        private int idPago;
        private int idAlumno;

        public DetalleDePago(int id_pago, int id_alumno)
        {
            InitializeComponent();

            idPago = id_pago;
            idAlumno = id_alumno;

            cargarFormulario(idPago);
        }

        private void cargarFormulario(int idPago)
        {
            // Diccionario para mapear los números a los nombres de los meses
            Dictionary<int, string> meses = new Dictionary<int, string>
            {
                { 1, "Enero" },
                { 2, "Febrero" },
                { 3, "Marzo" },
                { 4, "Abril" },
                { 5, "Mayo" },
                { 6, "Junio" },
                { 7, "Julio" },
                { 8, "Agosto" },
                { 9, "Septiembre" },
                { 10, "Octubre" },
                { 11, "Noviembre" },
                { 12, "Diciembre" }
            };

            List<Membresia> listaMembresias = new CN_membresia().Listar();
            List<PagoDetalle> detalle = new CN_Pago().ListarPagoDetalles(idPago);

            foreach (PagoDetalle item in detalle)
            {
                if(item.id_pago.id_pago == idPago)
                {
                    var membresia = listaMembresias.FirstOrDefault(m => m.id_membresia == item.id_membresia.id_membresia);

                    // Obtén el nombre del mes a partir del diccionario
                    string nombreMes = meses.ContainsKey(item.periodo) ? meses[item.periodo] : "Mes desconocido";

                    nroFactura.Text = item.id_pago.id_pago.ToString();
                    dgvdata.Rows.Add(new object[] { item.id_pago.id_pago, membresia.nombre, nombreMes, "$ " + item.monto});
                }
                
            }

            List<Alumno> listaAlumnos = objCN_Alumno.Listar();
            List<MedioPago> listaMediosPago = objCN_MedioPago.Listar();

            List<Pago> listaPagos = new CN_Pago().ListarPagos();
            foreach (Pago item in listaPagos)
            {
                if (item.id_pago == idPago)
                {
                    var alumno = listaAlumnos.FirstOrDefault(a => a.id_alumno == item.id_alumno.id_alumno);
                    var medioPago = listaMediosPago.FirstOrDefault(m => m.id_medioPago == item.id_medioPago.id_medioPago);


                    fecha.Text = DateTime.Parse(item.fecha).ToString("dd/MM/yyyy");
                    nombreCompletoAlumno.Text = alumno.nombre + " " + alumno.apellido;
                    DNIalumno.Text = alumno.dni;
                    medioPagoTX.Text = medioPago.nombre;
                    subTotal.Text = "$ " + item.cantidad.ToString();
                    recargo.Text = "$ " + item.recargo.ToString();
                    total.Text = "$ " + item.total.ToString();
                }
                    
            }
        }

        private void DetalleDePago_Load(object sender, EventArgs e)
        {
            dgvdata.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvdata.ReadOnly = true;
            dgvdata.AllowUserToAddRows = false;
            dgvdata.AllowUserToDeleteRows = false;
            dgvdata.DefaultCellStyle.SelectionBackColor = dgvdata.DefaultCellStyle.BackColor;
            dgvdata.DefaultCellStyle.SelectionForeColor = dgvdata.DefaultCellStyle.ForeColor;
        }
    }
}
