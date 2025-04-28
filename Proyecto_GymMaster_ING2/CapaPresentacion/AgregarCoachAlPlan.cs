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
    public partial class AgregarCoachAlPlan : Form
    {
        private Usuario usuarioActual; // Objeto usuario actual
        private NuevoPlanEntrenamiento planEntrenamientoForm; // Referencia al formulario principal

        private int columnaSeleccionada = -1; // Variable para almacenar el índice de la columna seleccionada

        public AgregarCoachAlPlan(Usuario usuario, NuevoPlanEntrenamiento planEntrenamiento)
        {
            InitializeComponent();
            CargarCoachs(); // Cargar datos cuando se abra el formulario
            usuarioActual = usuario;
            planEntrenamientoForm = planEntrenamiento;
        }

        private void CargarCoachs()
        {
            List<Usuario> listausuario = new CN_usuario().Listar();
            dgvdataAgregarCoach.Rows.Clear(); // Limpia el DataGrid antes de actualizar
            foreach (Usuario item in listausuario)
            {
                if (item.id_rol.id_rol == 2 && item.id_usuario != usuarioActual.id_usuario) //solo lista usuarios 'coach' y el registro del usuario actual saltea
                {
                    DateTime fechaNacimiento = DateTime.Parse(item.fecha_nacimiento);

                    dgvdataAgregarCoach.Rows.Add(new object[]{item.id_usuario,item.nombre, item.apellido,item.dni,
                        item.email,fechaNacimiento.ToString("dd/MM/yyyy"),item.telefono});
                }
            }
        }
        private void AgregarCoachAlPlan_Load(object sender, EventArgs e)
        {
            // Cambia el color de texto de la fila seleccionada en el DataGridView
            dgvdataAgregarCoach.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvdataAgregarCoach.DefaultCellStyle.SelectionBackColor = Color.Silver; // Color gris para la selección de celdas

            // Cambia el modo de selección a que solo permita seleccionar las cabeceras de las columnas
            dgvdataAgregarCoach.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se guardo ninguna seleccion.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Evento para manejar el doble clic en el DataGridView
        private void dgvdataAgregarCoach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el ID y otros datos del coach seleccionado
                int idCoach = Convert.ToInt32(dgvdataAgregarCoach.Rows[e.RowIndex].Cells["idUsuario"].Value);
                string nombre = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string apellido = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                string dni = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["dni"].Value.ToString();
                string email = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["email"].Value.ToString();
                string fechaNacimiento = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString();
                string telefono = dgvdataAgregarCoach.Rows[e.RowIndex].Cells["telefono"].Value.ToString();

                // Crear objeto Usuario con los datos del coach seleccionado
                Usuario coachSeleccionado = new Usuario()
                {
                    id_usuario = idCoach,
                    nombre = nombre,
                    apellido = apellido,
                    dni = dni,
                    email = email,
                    fecha_nacimiento = fechaNacimiento,
                    telefono = telefono
                };

                // Pasar el coach seleccionado al formulario NuevoPlanEntrenamiento
                planEntrenamientoForm.ActualizarCoachsSeleccionados(coachSeleccionado);

                // Cerrar el formulario actual
                this.Close();
            }
        }

        private void dgvdataAgregarCoach_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LBuscar.Visible = true;
            LnombreColumna.Visible = true;

            columnaSeleccionada = e.ColumnIndex; // Guarda el índice de la columna seleccionada

            // Obtiene el nombre de la columna seleccionada
            string nombreColumna = dgvdataAgregarCoach.Columns[columnaSeleccionada].Name;
            LnombreColumna.Text = nombreColumna;

            // Resetea el color de fondo de todas las columnas
            foreach (DataGridViewColumn col in dgvdataAgregarCoach.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White; // Color blanco para las columnas no seleccionadas
            }

            // Cambia el color de la columna seleccionada
            dgvdataAgregarCoach.Columns[columnaSeleccionada].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            if (columnaSeleccionada >= 0 && columnaSeleccionada < dgvdataAgregarCoach.Columns.Count) // Verifica que haya una columna seleccionada
            {
                string textoBusqueda = textBoxBuscar.Text.ToLower(); // Convierte la búsqueda a minúsculas para que no distinga entre mayúsculas y minúsculas
                bool coincidenciaEncontrada = false;

                foreach (DataGridViewRow fila in dgvdataAgregarCoach.Rows)
                {
                    if (fila.Cells[columnaSeleccionada].Value != null) // Verifica si la celda no es nula
                    {
                        string valorCelda = fila.Cells[columnaSeleccionada].Value.ToString().ToLower(); // Valor de la celda

                        if (valorCelda.Contains(textoBusqueda)) // Busca coincidencias
                        {
                            fila.Visible = true;  // Muestra la fila si coincide
                            coincidenciaEncontrada = true;
                        }
                        else
                        {
                            fila.Visible = false; // Oculta la fila si no coincide
                        }
                    }
                }

                // Si no se encontró ninguna coincidencia, muestra mensaje
                if (!coincidenciaEncontrada)
                {
                    MessageBox.Show("No se encontraron coincidencias.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatGrid();
                }
            }
        }

        private void Blimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatGrid();
            columnaSeleccionada = -1; // Reinicia la selección de columna
        }

        private void limpiarDatGrid()
        {
            LBuscar.Visible = false;
            LnombreColumna.Visible = false;

            // Mostrar todas las filas nuevamente
            foreach (DataGridViewRow fila in dgvdataAgregarCoach.Rows)
            {
                fila.Visible = true;
            }

            // Limpiar el TextBox de búsqueda
            textBoxBuscar.Text = "";

            // Resetear el color de las columnas
            foreach (DataGridViewColumn col in dgvdataAgregarCoach.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White;
            }

            // Limpia la selección del DataGridView
            dgvdataAgregarCoach.ClearSelection();
        }
    }
}
