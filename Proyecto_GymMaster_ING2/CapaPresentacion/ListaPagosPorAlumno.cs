using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ListaPagosPorAlumno : Form
    {
        private CN_Alumno objCN_Alumno = new CN_Alumno();
        private CN_medioPago objCN_MedioPago = new CN_medioPago();

        private int id_alumno;

        public ListaPagosPorAlumno(int idAlumno)
        {
            InitializeComponent();

            id_alumno = idAlumno;
        }

        private void ListaPagosPorAlumno_Load(object sender, EventArgs e)
        {
            dgvdata.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvdata.ReadOnly = true;
            dgvdata.AllowUserToAddRows = false;
            dgvdata.AllowUserToDeleteRows = false;
            dgvdata.DefaultCellStyle.SelectionBackColor = dgvdata.DefaultCellStyle.BackColor;
            dgvdata.DefaultCellStyle.SelectionForeColor = dgvdata.DefaultCellStyle.ForeColor;


            List<Alumno> listaAlumnos = objCN_Alumno.Listar();

            List<MedioPago> listaMediosPago = objCN_MedioPago.Listar();

            List<Pago> listaPagos = new CN_Pago().ListarPagos();
            foreach (Pago item in listaPagos)
            {
                if(item.id_alumno.id_alumno == id_alumno)
                {
                    DateTime fechaPago = DateTime.Parse(item.fecha);

                    var alumno = listaAlumnos.FirstOrDefault(a => a.id_alumno == item.id_alumno.id_alumno);
                    var medioPago = listaMediosPago.FirstOrDefault(m => m.id_medioPago == item.id_medioPago.id_medioPago);

                    labelAlumno.Text = alumno.nombre + " " + alumno.apellido;

                    dgvdata.Rows.Add(new object[]{" Ver factura ", item.id_pago,
                                    fechaPago.ToString("dd/MM/yyyy"), "$ " + item.cantidad, "+ $ " + item.recargo, "$ " + item.total, medioPago.nombre});
                }
                
            }

            labelCantPagos.Text = $"{dgvdata.Rows.Count} pago";
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvdata.Columns["verFactura"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del pago de la fila seleccionada
                int idPago = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["idPago"].Value);

                using (var modal = new DetalleDePago(idPago, id_alumno))
                {
                    // Mostrar el formulario como un modal
                    var resultado = modal.ShowDialog();
                }

            }
        }
    }
}
