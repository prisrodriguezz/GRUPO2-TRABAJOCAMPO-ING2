using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Diagnostics;

namespace CapaPresentacion
{
    public partial class CobrarCuotaAlumno : Form
    {
        private Alumno objAlumno;
        private int valor_; // para identificar si se trata de una inscripcion(0) o cobro de cuota(1)

        private decimal comisionPorcentaje = 0; // Variable para almacenar la comisión

        public CobrarCuotaAlumno(Alumno alumno, int valor)
        {
            InitializeComponent();

            objAlumno = alumno;
            valor_ = valor;

            NombreAlumno.Text = objAlumno.nombre + " " + objAlumno.apellido + " - " + objAlumno.dni;

        }

        private void CobrarNuevoAlumno_Load(object sender, EventArgs e)
        {
            textBoxFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cargarMediosDePago();

            if(valor_ == 0)
            {
                cargarDataGridInscripcion();
            }
            else if(valor_ == 1)
            {
                cargarDataGridCobroCuota();
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;

        }

        private void cargarMediosDePago()
        {
            comboBoxFormaPago.Items.Clear();

            List<MedioPago> listaMediosDePago = new CN_medioPago().Listar();

            foreach (MedioPago item in listaMediosDePago)
            {
               if(item.estado == true)
                {
                    comboBoxFormaPago.Items.Add(new { Text = item.nombre, Value = item.id_medioPago });
                }
            }

            // Configura el ComboBox para mostrar el texto adecuado
            comboBoxFormaPago.DisplayMember = "Text"; 
            comboBoxFormaPago.ValueMember = "Value";  
        }

        private void cargarDataGridInscripcion()
        {
            dataGridView1.Rows.Clear();
            this.FormBorderStyle = FormBorderStyle.None;

            List<Membresia> listaMembresias = new CN_membresia().Listar();

            foreach (Membresia item in listaMembresias)
            {
                if(item.id_membresia == objAlumno.id_membresia)
                {
                    // Obtener el mes actual como nombre
                    string mesActual = DateTime.Now.ToString("MMMM");

                    dataGridView1.Rows.Add(item.nombre, mesActual, item.costo);
                }
            }

            SumarMontos();
        }

        private void cargarDataGridCobroCuota()
        {
            dataGridView1.Rows.Clear();


            List<FechaAdeudada> listaPagos = new CN_Pago().ObtenerFechasAdeudadas(objAlumno.id_alumno);

            if(listaPagos.Count == 0)
            {
                MessageBox.Show("El alumno no tiene pagos pendientes.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            foreach (FechaAdeudada item in listaPagos)
            {
                if (item.IdAlumno == objAlumno.id_alumno)
                {
                    // Obtener solo el nombre del mes
                    string mesAdeudado = item.FechasAdeudada.ToString("MMMM");

                    dataGridView1.Rows.Add(item.NombreMembresia, mesAdeudado, item.CostoMembresia);
                }
            }

            SumarMontos();
        }

        private void SumarMontos()
        {
            decimal totalMonto = 0;

            // Iterar a través de cada fila del DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificar si la fila no es nueva y contiene un valor en la columna 'monto'
                if (!row.IsNewRow)
                {
                    // Sumar el valor de la columna 'monto'
                    totalMonto += Convert.ToDecimal(row.Cells["monto"].Value);
                }
            }

            // Calcular el total incluyendo la comisión
            decimal totalConComision = totalMonto + (totalMonto * comisionPorcentaje / 100);

            // Mostrar el subTotal
            textBoxSubTotal.Text = totalMonto.ToString("C2"); // Formatear como moneda
            textBoxTotal.Text = totalConComision.ToString("C2"); // Mostrar total con comisión

            // Calcular la diferencia y mostrarla en textBoxRecargo
            decimal diferencia = totalConComision - totalMonto;
            textBoxRecargo.Text = diferencia.ToString("C2");
        }


        private void BCobrarInscripcion_Click(object sender, EventArgs e)
        {

            if (comboBoxFormaPago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un medio de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            var selectedMedioPago = (dynamic)comboBoxFormaPago.SelectedItem;
            int idMedioPago = selectedMedioPago.Value;

            // Convierte los valores eliminando cualquier símbolo de moneda 
            decimal subTotal = decimal.Parse(textBoxSubTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
            decimal total = decimal.Parse(textBoxTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
            decimal recargo = decimal.Parse(textBoxRecargo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);

            Pago nuevoPago = new Pago
            {
                id_usuario = new Usuario { id_usuario = objAlumno.id_usuario },
                id_alumno = objAlumno,
                id_medioPago = new MedioPago { id_medioPago = idMedioPago },
                fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                cantidad = subTotal,
                total = total,
                recargo = recargo
            };

            List<PagoDetalle> detalles = new List<PagoDetalle>();

            //Registra el detalle del pago
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    PagoDetalle detalle = new PagoDetalle
                    {
                        id_membresia = new Membresia { id_membresia = objAlumno.id_membresia },
                        periodo = ConvertirMesANumero(row.Cells["periodo"].Value.ToString()),
                        monto = Convert.ToDecimal(row.Cells["monto"].Value)
                    };
                    detalles.Add(detalle);
                }
            }

            CN_Pago objPago = new CN_Pago();
            int idPagoGenerado = objPago.ProcesarPago(nuevoPago, detalles);

            if (idPagoGenerado > 0)
            {
                MessageBox.Show("El pago se realizó correctamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;

                // GENERAR ARCHIVO PDF
                string carpetaGuardado = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PdfsDePagos");

                // Nombre del archivo con formato de fecha, hora actual, nombre y apellido del alumno
                string nombreArchivo = $"{DateTime.Now:ddMMyyHHmmss}_{objAlumno.nombre}_{objAlumno.apellido}.pdf";
                string rutaCompleta = Path.Combine(carpetaGuardado, nombreArchivo);

                // Si la carpeta no existe se crea una nueva
                if (!Directory.Exists(carpetaGuardado))
                {
                    Directory.CreateDirectory(carpetaGuardado);
                }

               

                // Estructura de la factura
                string paginaHTML = Properties.Resources.plantilla.ToString();

                // Remplazar los campos de la estructura de la factura
                paginaHTML = paginaHTML.Replace("@numeroFactura", idPagoGenerado.ToString());
                paginaHTML = paginaHTML.Replace("@dniAlumno", objAlumno.dni);
                paginaHTML = paginaHTML.Replace("@nombreAlumno", objAlumno.nombre + " " + objAlumno.apellido);
                paginaHTML = paginaHTML.Replace("@fecha", textBoxFecha.Text);

                List<Usuario> listausuario = new CN_usuario().Listar();
                var usuario = listausuario.FirstOrDefault(u => u.id_usuario == objAlumno.id_usuario);
                paginaHTML = paginaHTML.Replace("@nombreCoach", $"{usuario.nombre} {usuario.apellido}");

                List<PlanEntrenamiento> listaPlanes = new CN_PlanEntrenamiento().Listar();
                var plan = listaPlanes.FirstOrDefault(p => p.id_plan == objAlumno.id_plan);
                paginaHTML = paginaHTML.Replace("@nombrePlan", plan.nombre);


                string formaMedioPago = comboBoxFormaPago.Text;
                paginaHTML = paginaHTML.Replace("@nombreMedioPago", formaMedioPago);

                paginaHTML = paginaHTML.Replace("@subtotal", textBoxSubTotal.Text);
                paginaHTML = paginaHTML.Replace("@recargo", textBoxRecargo.Text);
                paginaHTML = paginaHTML.Replace("@montototal", textBoxTotal.Text);


                string filas = string.Empty;
                foreach(DataGridViewRow row in dataGridView1.Rows)
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

                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al procesar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBoxFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el medio de pago seleccionado
            if (comboBoxFormaPago.SelectedItem != null)
            {
                var selectedMedioPago = (dynamic)comboBoxFormaPago.SelectedItem;
                int idMedioPago = selectedMedioPago.Value;


                List<MedioPago> listaMediosDePago = new CN_medioPago().Listar();

                foreach (MedioPago item in listaMediosDePago)
                {
                    if(item.id_medioPago == idMedioPago)
                    {
                        comisionPorcentaje = item.comision; // Obtener la comisión para el medio de pago seleccionado
                    }
                }
            }

            // Volver a calcular el subtotal al cambiar el medio de pago
            SumarMontos();
        }


        private int ConvertirMesANumero(string nombreMes)
        {
            DateTime mes;
            if (DateTime.TryParseExact(nombreMes, "MMMM", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out mes))
            {
                return mes.Month;
            }
            return 0; // Valor de respaldo si la conversión falla
        }

    }
}
