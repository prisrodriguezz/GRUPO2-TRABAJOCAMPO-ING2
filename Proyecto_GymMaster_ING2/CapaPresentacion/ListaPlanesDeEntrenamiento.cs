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
    public partial class ListaPlanesDeEntrenamiento : Form
    {
        private CN_PlanEntrenamiento objCN_PlanEntrenamiento = new CN_PlanEntrenamiento(); // Capa de negocio para planes

        private int columnaSeleccionada = -1; // Variable para almacenar el índice de la columna seleccionada

        private Usuario usuarioActual; // Objeto usuario actual

        public ListaPlanesDeEntrenamiento(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarPlanesDeEntrenamiento(); // Cargar datos cuando se abra el formulario
        }

        // Método para cargar planes de entrenamiento en el DataGridView
        private void CargarPlanesDeEntrenamiento()
        {
            if(usuarioActual.id_rol.id_rol == 2) //Usuario Administrador ve todos los planes
            {
                BNuevoPlan.Visible = false;

                List<PlanEntrenamiento> listaPlanes = objCN_PlanEntrenamiento.Listar();

                dgvdataListaPlanes.Rows.Clear();
                foreach (PlanEntrenamiento item in listaPlanes)
                {
                    string accion = item.estado ? "Eliminar" : "Restaurar";

                    dgvdataListaPlanes.Rows.Add(new object[] {"Editar", accion, item.id_plan, item.nombre, item.fechaInicio.ToString("dd/MM/yyyy"),
                    item.fechaFin.ToString("dd/MM/yyyy"), item.cantSeries, "Ver detalles", item.estado == true ? "Activo" : "Inactivo" });
                }

                dgvdataListaPlanes.Columns["editar"].Visible = false;
                dgvdataListaPlanes.Columns["eliminar"].Visible = false;
            }
            else if(usuarioActual.id_rol.id_rol == 3) // Usuario coach ve solo sus planes
            {
                labelTITULO.Text = "MIS PLANES";

                List<PlanEntrenamiento> listaPlanes = objCN_PlanEntrenamiento.ListarPlanesPorCoachs(usuarioActual.id_usuario);
                
                dgvdataListaPlanes.Rows.Clear();
                foreach (PlanEntrenamiento item in listaPlanes)
                {
                    string accion = item.estado ? "Eliminar" : "Restaurar";

                    dgvdataListaPlanes.Rows.Add(new object[] {"Editar", accion, item.id_plan, item.nombre, item.fechaInicio.ToString("dd/MM/yyyy"),
                    item.fechaFin.ToString("dd/MM/yyyy"), item.cantSeries, "Ver detalles", item.estado == true ? "Activo" : "Inactivo" });
                }
            }
            

            labelCantPlanes.Text = $"{dgvdataListaPlanes.Rows.Count} planes";
        }

        private void ListaPlanesDeEntrenamiento_Load(object sender, EventArgs e)
        {
            // Cambia el color de texto de la fila seleccionada en el DataGridView
            dgvdataListaPlanes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvdataListaPlanes.DefaultCellStyle.SelectionBackColor = Color.Silver; // Color gris para la selección de celdas

            // Cambia el modo de selección a que solo permita seleccionar las cabeceras de las columnas
            dgvdataListaPlanes.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dgvdataListaPlanes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LBuscar.Visible = true;
            LnombreColumna.Visible = true;

            columnaSeleccionada = e.ColumnIndex; // Guarda el índice de la columna seleccionada

            // Obtiene el nombre de la columna seleccionada
            string nombreColumna = dgvdataListaPlanes.Columns[columnaSeleccionada].Name;
            LnombreColumna.Text = nombreColumna;

            // Resetea el color de fondo de todas las columnas
            foreach (DataGridViewColumn col in dgvdataListaPlanes.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White; // Color blanco para las columnas no seleccionadas
            }

            // Cambia el color de la columna seleccionada
            dgvdataListaPlanes.Columns[columnaSeleccionada].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (columnaSeleccionada >= 0 && columnaSeleccionada < dgvdataListaPlanes.Columns.Count) // Verifica que haya una columna seleccionada
            {
                string textoBusqueda = textBoxBusqueda.Text.ToLower(); // Convierte la búsqueda a minúsculas para que no distinga entre mayúsculas y minúsculas
                bool coincidenciaEncontrada = false;

                foreach (DataGridViewRow fila in dgvdataListaPlanes.Rows)
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
            foreach (DataGridViewRow fila in dgvdataListaPlanes.Rows)
            {
                fila.Visible = true;
            }

            // Limpiar el TextBox de búsqueda
            textBoxBusqueda.Text = "";

            // Resetear el color de las columnas
            foreach (DataGridViewColumn col in dgvdataListaPlanes.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White;
            }

            // Limpia la selección del DataGridView
            dgvdataListaPlanes.ClearSelection();
        }

        private void BNuevoPlan_Click(object sender, EventArgs e)
        {
            //Modal para agregar nuevo plan
            using (var modal = new NuevoPlanEntrenamiento(usuarioActual))
            {
                modal.PlanRegistrado += CargarPlanesDeEntrenamiento; //evento
                var resultado = modal.ShowDialog();
            }
        }

        private void dgvdataListaPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //verifica que hizo click en la columna 'detalles plan'
            if (e.ColumnIndex == dgvdataListaPlanes.Columns["detallesPlan"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del plan de la fila seleccionada
                int idPlan = Convert.ToInt32(dgvdataListaPlanes.Rows[e.RowIndex].Cells["idPlan"].Value);

                //Modal para ver detalles del plan
                using (var modal = new DetallesPlanEntrenamiento(idPlan))
                {
                    var resultado = modal.ShowDialog();
                }
            }

            // Verificar si se hizo click en la columna de editar
            if (e.ColumnIndex == dgvdataListaPlanes.Columns["editar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del plan de la fila seleccionada
                int idPlan = Convert.ToInt32(dgvdataListaPlanes.Rows[e.RowIndex].Cells["idPlan"].Value);

                using (var modal = new NuevoPlanEntrenamiento(usuarioActual))
                {
                    modal.PlanRegistrado += CargarPlanesDeEntrenamiento; //evento

                    modal.CargarDatosPlan(idPlan);
                    var resultado = modal.ShowDialog();
                }
            }


            // Verificar si se hizo click en la columna de eliminar
            if (e.ColumnIndex == dgvdataListaPlanes.Columns["eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del plan de la fila seleccionada
                int idPlan = Convert.ToInt32(dgvdataListaPlanes.Rows[e.RowIndex].Cells["idPlan"].Value);

                string estadoActual = dgvdataListaPlanes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                string mensaje = string.Empty;

                if (estadoActual == "Activo")
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int respuesta = new CN_PlanEntrenamiento().Eliminar(idPlan, out mensaje);

                        if(respuesta == 1)
                        {
                            MessageBox.Show(mensaje, "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPlanesDeEntrenamiento();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else //plan inactivo
                {
                    DialogResult result = MessageBox.Show("¿Estás seguro de que deseas restaurar este plan?", "Confirmar restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        int respuesta = new CN_PlanEntrenamiento().Restaurar(idPlan, out mensaje);

                        if (respuesta == 1)
                        {
                            MessageBox.Show(mensaje, "Restauracion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPlanesDeEntrenamiento();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
