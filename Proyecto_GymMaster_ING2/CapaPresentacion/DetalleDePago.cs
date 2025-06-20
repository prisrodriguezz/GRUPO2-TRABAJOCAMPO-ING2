using CapaEntidad;
using CapaNegocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
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

        private void BGenerarPDF_Click(object sender, EventArgs e)
        {
            // GENERAR ARCHIVO PDF
            string carpetaGuardado = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PdfsDePagos");

            // Nombre del archivo con formato de fecha, hora actual, nombre y apellido del alumno
            string nombreArchivo = $"{DateTime.Now:ddMMyyHHmmss}_{nombreCompletoAlumno.Text}.pdf";
            string rutaCompleta = Path.Combine(carpetaGuardado, nombreArchivo);

            // Si la carpeta no existe se crea una nueva
            if (!Directory.Exists(carpetaGuardado))
            {
                Directory.CreateDirectory(carpetaGuardado);
            }



            // Estructura de la factura
            string paginaHTML = Properties.Resources.plantilla.ToString();

            // Remplazar los campos de la estructura de la factura
            paginaHTML = paginaHTML.Replace("@numeroFactura", nroFactura.Text);
            paginaHTML = paginaHTML.Replace("@dniAlumno", DNIalumno.Text);
            paginaHTML = paginaHTML.Replace("@nombreAlumno", nombreCompletoAlumno.Text);
            paginaHTML = paginaHTML.Replace("@fecha", fecha.Text);

            List<Alumno> listaAlumnos = objCN_Alumno.Listar();
            var alumno = listaAlumnos.FirstOrDefault(a => a.id_alumno == idAlumno);

            List<Usuario> listausuario = new CN_usuario().Listar();
            var usuario = listausuario.FirstOrDefault(u => u.id_usuario == alumno.id_usuario);
            paginaHTML = paginaHTML.Replace("@nombreCoach", $"{usuario.nombre} {usuario.apellido}");

            List<PlanEntrenamiento> listaPlanes = new CN_PlanEntrenamiento().Listar();
            var plan = listaPlanes.FirstOrDefault(p => p.id_plan == alumno.id_plan);
            paginaHTML = paginaHTML.Replace("@nombrePlan", plan.nombre);


            paginaHTML = paginaHTML.Replace("@nombreMedioPago", medioPagoTX.Text);

            paginaHTML = paginaHTML.Replace("@subtotal", subTotal.Text);
            paginaHTML = paginaHTML.Replace("@recargo", recargo.Text);
            paginaHTML = paginaHTML.Replace("@montototal", total.Text);


            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Membresia"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Periodo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Monto"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            paginaHTML = paginaHTML.Replace("@filas", filas);


            MessageBox.Show("Generando factura...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                //Archivo de memoria
                using (FileStream stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    // Guardado del PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); //tipo hoja y margenes

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    using (StringReader sr = new StringReader(paginaHTML))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                }

                // Abrir el archivo PDF automáticamente
                Process.Start(rutaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar o abrir el PDF: " + ex.Message);
            }
    }
    }
}
