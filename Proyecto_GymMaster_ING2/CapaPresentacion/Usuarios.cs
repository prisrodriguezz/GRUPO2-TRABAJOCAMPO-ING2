using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CapaEntidad;
using System.Drawing;

namespace CapaPresentacion
{
    public partial class Usuarios : Form
    {

        private int columnaSeleccionada = -1; // Variable para almacenar el índice de la columna seleccionada

        public Usuarios(Usuario usuario)
        {
            InitializeComponent();
        }

        private void BNuevoUsuario_Click(object sender, EventArgs e)
        {
            
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            //lista los usuarios de la bd
            NuevoUsuario_UsuarioRegistrado();

            // Cambia el color de texto de la fila seleccionada en el DataGridView
            dgvdata.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvdata.DefaultCellStyle.SelectionBackColor = Color.Silver; // Color gris para la selección de celdas

            // Cambia el modo de selección a que solo permita seleccionar las cabeceras de las columnas
            dgvdata.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }


        private void NuevoUsuario_UsuarioRegistrado()
        {
            // Se carga la lista de usuarios al dataGrid
            List<Usuario> listausuario = new CN_usuario().Listar();
            dgvdata.Rows.Clear(); // Limpia el DataGrid antes de actualizar
            foreach (Usuario item in listausuario)
            {
                DateTime fechaNacimiento = DateTime.Parse(item.fecha_nacimiento);

                // Verifica si el usuario está activo o inactivo
                string accion = item.estado ? "Eliminar" : "Restaurar";

                dgvdata.Rows.Add(new object[]{"Editar",accion,item.id_usuario,item.nombre, item.apellido,item.dni,
                  item.email,fechaNacimiento.ToString("dd/MM/yyyy"),item.telefono,"Ver horario",item.id_rol.descripcion,item.estado == true ? "Activo" : "Inactivo", item.contraseña });
            }
            labelCantUsuarios.Text = $"{dgvdata.Rows.Count} usuarios";
        }

        private void dgvdata_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LBuscar.Visible = true;
            LnombreColumna.Visible = true;

            columnaSeleccionada = e.ColumnIndex; // Guarda el índice de la columna seleccionada

            // Obtiene el nombre de la columna seleccionada
            string nombreColumna = dgvdata.Columns[columnaSeleccionada].Name;
            LnombreColumna.Text = nombreColumna;

            // Resetea el color de fondo de todas las columnas
            foreach (DataGridViewColumn col in dgvdata.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White; // Color blanco para las columnas no seleccionadas
            }

            // Cambia el color de la columna seleccionada
            dgvdata.Columns[columnaSeleccionada].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (columnaSeleccionada >= 0 && columnaSeleccionada < dgvdata.Columns.Count) // Verifica que haya una columna seleccionada
            {
                string textoBusqueda = textBoxBusqueda.Text.ToLower(); // Convierte la búsqueda a minúsculas para que no distinga entre mayúsculas y minúsculas
                bool coincidenciaEncontrada = false;

                foreach (DataGridViewRow fila in dgvdata.Rows)
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

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatGrid();
            columnaSeleccionada = -1; // Reinicia la selección de columna
        }

        private void limpiarDatGrid()
        {
            LBuscar.Visible = false;
            LnombreColumna.Visible = false;

            // Mostrar todas las filas nuevamente
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                fila.Visible = true;
            }

            // Limpiar el TextBox de búsqueda
            textBoxBusqueda.Text = "";

            // Resetear el color de las columnas
            foreach (DataGridViewColumn col in dgvdata.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White;
            }

            // Limpia la selección del DataGridView
            dgvdata.ClearSelection(); 
        }
    }
}
