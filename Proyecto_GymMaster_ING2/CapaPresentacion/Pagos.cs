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
    public partial class Pagos : Form
    {
        private CN_Alumno objCN_Alumno = new CN_Alumno();
        private CN_medioPago objCN_MedioPago = new CN_medioPago();

        public Pagos()
        {
            InitializeComponent();

            listarPagos();
        }

        private void listarPagos()
        {
            dgvdata.Rows.Clear();

            List<Alumno> listaAlumnos = objCN_Alumno.Listar();

            List<MedioPago> listaMediosPago = objCN_MedioPago.Listar();

            List<Pago> listaPagos = new CN_Pago().ListarPagos();
            foreach(Pago item in listaPagos)
            {
                DateTime fechaPago = DateTime.Parse(item.fecha);

                var alumno = listaAlumnos.FirstOrDefault(a => a.id_alumno == item.id_alumno.id_alumno);
                var medioPago = listaMediosPago.FirstOrDefault(m => m.id_medioPago == item.id_medioPago.id_medioPago);

                dgvdata.Rows.Add(new object[]{" Ver factura ", item.id_pago, alumno.id_alumno, alumno.nombre + " " + alumno.apellido,
                                   fechaPago.ToString("dd/MM/yyyy"), "$ " + item.cantidad, "+ $ " + item.recargo, "$ " + item.total, medioPago.nombre});
            }

            labelCantPagos.Text = $"{dgvdata.Rows.Count} pagos";
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            dgvdata.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvdata.ReadOnly = true;
            dgvdata.AllowUserToAddRows = false;
            dgvdata.AllowUserToDeleteRows = false;
            dgvdata.DefaultCellStyle.SelectionBackColor = dgvdata.DefaultCellStyle.BackColor;
            dgvdata.DefaultCellStyle.SelectionForeColor = dgvdata.DefaultCellStyle.ForeColor;
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvdata.Columns["verFactura"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del pago de la fila seleccionada
                int idPago = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["idPago"].Value);

                int idAlumno = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["idAlumno"].Value);

                using (var modal = new DetalleDePago(idPago, idAlumno))
                {
                    // Mostrar el formulario como un modal
                    var resultado = modal.ShowDialog();
                }

            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas en los DateTimePicker
            DateTime fechaDesde = dateTimePickerDesde.Value.Date;
            DateTime fechaHasta = dateTimePickerHasta.Value.Date;

            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show("La fecha 'desde' no puede ser mayor a la fecha 'hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpiar el DataGridView antes de cargar los datos filtrados
            dgvdata.Rows.Clear();

            List<Alumno> listaAlumnos = objCN_Alumno.Listar();
            List<MedioPago> listaMediosPago = objCN_MedioPago.Listar();

            // Filtrar la lista de pagos según las fechas seleccionadas
            List<Pago> listaPagos = new CN_Pago().ListarPagos().Where(p => Convert.ToDateTime(p.fecha) >= fechaDesde && Convert.ToDateTime(p.fecha) <= fechaHasta).ToList();

            // Verificar si hay pagos en el rango de fechas
            if (listaPagos.Count == 0)
            {
                MessageBox.Show("No se encontraron pagos en el rango de fechas especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarPagos();
            }
            else
            {
                foreach (Pago item in listaPagos)
                {
                    var alumno = listaAlumnos.FirstOrDefault(a => a.id_alumno == item.id_alumno.id_alumno);
                    var medioPago = listaMediosPago.FirstOrDefault(m => m.id_medioPago == item.id_medioPago.id_medioPago);

                    dgvdata.Rows.Add(new object[]{" Ver factura ",item.id_pago, alumno.id_alumno, alumno.nombre + " " + alumno.apellido,item.fecha,"$ " + item.cantidad,
                        "+ $ " + item.recargo,"$ " + item.total,medioPago.nombre});
                }
            }

            labelCantPagos.Text = $"{dgvdata.Rows.Count} pagos";

        }

        private void Blimpiar_Click(object sender, EventArgs e)
        {
            dateTimePickerDesde.Value = DateTime.Now;
            dateTimePickerHasta.Value = DateTime.Now;
            listarPagos();
        }
    }
}
