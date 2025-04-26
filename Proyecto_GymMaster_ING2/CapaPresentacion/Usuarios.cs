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
        private Usuario usuarioActual; // Objeto usuario actual

        public Usuarios(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void BNuevoUsuario_Click(object sender, EventArgs e)
        {
            //Modal para agregar nuevo usuario
            using (var modal = new NuevoUsuario(usuarioActual))
            {
                modal.UsuarioRegistrado += NuevoUsuario_UsuarioRegistrado; // Evento
                var resultado = modal.ShowDialog();
            }
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
            if (usuarioActual.id_rol.id_rol == 2) //usuario administrador, solo se listan coachs 
            {
                List<Usuario> listausuario = new CN_usuario().Listar();
                dgvdata.Rows.Clear(); // Limpia el DataGrid antes de actualizar
                foreach (Usuario item in listausuario)
                {
                    if (item.id_rol.id_rol != 1 && item.id_rol.id_rol != 2)
                    {
                        DateTime fechaNacimiento = DateTime.Parse(item.fecha_nacimiento);

                        // Verifica si el usuario está activo o inactivo
                        string accion = item.estado ? "Eliminar" : "Restaurar";

                        dgvdata.Rows.Add(new object[]{"Editar",accion,item.id_usuario,item.nombre, item.apellido,item.dni,
                        item.email,fechaNacimiento.ToString("dd/MM/yyyy"),item.telefono,"Ver horario",item.id_rol.descripcion,item.estado == true ? "Activo" : "Inactivo", item.contraseña });
                    }
                }

                labelCantUsuarios.Text = $"{dgvdata.Rows.Count} usuarios";
            }
            else //para usuario Propietario se listan administradores y propietarios 
            {
                List<Usuario> listausuario = new CN_usuario().Listar();
                dgvdata.Rows.Clear(); // Limpia el DataGrid antes de actualizar
                foreach (Usuario item in listausuario)
                {
                    if (item.id_rol.id_rol == 1 || item.id_rol.id_rol == 2)
                    {
                        DateTime fechaNacimiento = DateTime.Parse(item.fecha_nacimiento);

                        // Verifica si el usuario está activo o inactivo
                        string accion = item.estado ? "Eliminar" : "Restaurar";

                        dgvdata.Rows.Add(new object[]{"Editar",accion,item.id_usuario,item.nombre, item.apellido,item.dni,
                        item.email,fechaNacimiento.ToString("dd/MM/yyyy"),item.telefono,"Ver horario",item.id_rol.descripcion,item.estado == true ? "Activo" : "Inactivo", item.contraseña });
                    }
                        
                }

                labelCantUsuarios.Text = $"{dgvdata.Rows.Count} usuarios";
            }
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


        //BOTON ELIMINAR / RESTAURAR / EDITAR DE REGISTROS / VER HORARIO
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna de editar
            if (e.ColumnIndex == dgvdata.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del usuario de la fila seleccionada
                int id_usuario = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["idUsuario"].Value);

                // Abrir el formulario de NuevoUsuario con los datos seleccionados
                using (var modal = new NuevoUsuario(usuarioActual))
                {
                    // Pasar los datos al formulario de NuevoUsuario
                    modal.CargarDatosUsuario(id_usuario);

                    modal.UsuarioRegistrado += NuevoUsuario_UsuarioRegistrado; // Evento

                    // Mostrar el formulario como un modal
                    var resultado = modal.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        // Refrescar el DataGridView después de editar
                        NuevoUsuario_UsuarioRegistrado();
                    }
                }
            }

            
            // Verificar si se hizo click en la columna de eliminar
            if (e.ColumnIndex == dgvdata.Columns["eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del usuario de la fila seleccionada
                int id_usuario = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["IdUsuario"].Value);

                // Obtener el estado actual del usuario
                string estadoActual = dgvdata.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                string mensaje = string.Empty;

                Usuario objUsuario = new Usuario()
                {
                    id_usuario = id_usuario
                };

                // Confirmar la acción según el estado actual del usuario
                if (estadoActual == "Activo")
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool respuesta = new CN_usuario().Eliminar(objUsuario, out mensaje);

                        if (respuesta)
                        {
                            MessageBox.Show("Usuario eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NuevoUsuario_UsuarioRegistrado();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el usuario: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else //usuario inactivo
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas restaurar este usuario?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool respuesta = new CN_usuario().Restaurar(objUsuario, out mensaje);

                        if (respuesta)
                        {
                            MessageBox.Show("Usuario restaurado correctamente.", "Restauración exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NuevoUsuario_UsuarioRegistrado(); // Refresca la lista
                        }
                        else
                        {
                            MessageBox.Show("Error al restaurar el usuario: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            // Verificar si se hizo click en la columna de ver horario
            if (e.ColumnIndex == dgvdata.Columns["horario"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del usuario de la fila seleccionada
                int idUsuario = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["IdUsuario"].Value);
                string nombreUsuario = string.Empty;

                List<Usuario> listausuario = new CN_usuario().Listar();
                foreach (Usuario item in listausuario)
                {
                    if(item.id_usuario == idUsuario)
                    {
                        nombreUsuario = item.nombre + " " + item.apellido;
                        break;
                    }
                }

                //Modal para ver horario del usuario
                using (var modal = new AgregarHorarioUsuario(idUsuario, nombreUsuario))
                {
                    var resultado = modal.ShowDialog();
                }
            }
        }
    }
}
