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
    public partial class Ejercicios : Form
    {
        private CN_Ejercicio objCN_Ejercicio = new CN_Ejercicio(); // Capa de negocio para ejercicios
        private NuevoPlanEntrenamiento planEntrenamientoForm; // Referencia al formulario principal

        private int columnaSeleccionada = -1; // Variable para almacenar el índice de la columna seleccionada

        public Ejercicios(NuevoPlanEntrenamiento planEntrenamiento)
        {
            InitializeComponent();
            CargarEjercicios(); // Cargar datos cuando se abra el formulario
            planEntrenamientoForm = planEntrenamiento;
        }

        // Método para cargar ejercicios en el DataGridView
        private void CargarEjercicios()
        {
            List<Ejercicio> listaEjercicios = objCN_Ejercicio.Listar();
            dataGridViewEjercicios.Rows.Clear();

            foreach (Ejercicio item in listaEjercicios)
            {
                dataGridViewEjercicios.Rows.Add(new object[] { item.id_ejercicio, item.nombre, item.repeticiones, item.tiempo, "Editar", "Eliminar" });
            }

        }

        private void dataGridViewEjercicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el ID y otros datos del ejercicio seleccionado
                int idEjercicio = Convert.ToInt32(dataGridViewEjercicios.Rows[e.RowIndex].Cells["idEjercicio"].Value);
                string nombre = dataGridViewEjercicios.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                int repeticion = Convert.ToInt32(dataGridViewEjercicios.Rows[e.RowIndex].Cells["repeticiones"].Value);
                int v_tiempo = Convert.ToInt32(dataGridViewEjercicios.Rows[e.RowIndex].Cells["tiempo"].Value);

                // Crear objeto Ejercicio con los datos seleccionado
                Ejercicio EjercicioSeleccionado = new Ejercicio()
                {
                    id_ejercicio = idEjercicio,
                    nombre = nombre,
                    repeticiones = repeticion,
                    tiempo = v_tiempo
                };

                // Pasar el ejercicio seleccionado al formulario NuevoPlanEntrenamiento
                planEntrenamientoForm.ActualizarEjerciciosSeleccionados(EjercicioSeleccionado);

                // Cerrar el formulario actual
                this.Close();
            }
        }

        private void Ejercicios_Load(object sender, EventArgs e)
        {
            // Cambia el color de texto de la fila seleccionada en el DataGridView
            dataGridViewEjercicios.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEjercicios.DefaultCellStyle.SelectionBackColor = Color.Silver; // Color gris para la selección de celdas

            // Cambia el modo de selección a que solo permita seleccionar las cabeceras de las columnas
            dataGridViewEjercicios.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dataGridViewEjercicios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LBuscar.Visible = true;
            LnombreColumna.Visible = true;

            columnaSeleccionada = e.ColumnIndex; // Guarda el índice de la columna seleccionada

            // Obtiene el nombre de la columna seleccionada
            string nombreColumna = dataGridViewEjercicios.Columns[columnaSeleccionada].Name;
            LnombreColumna.Text = nombreColumna;

            // Resetea el color de fondo de todas las columnas
            foreach (DataGridViewColumn col in dataGridViewEjercicios.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White; // Color blanco para las columnas no seleccionadas
            }

            // Cambia el color de la columna seleccionada
            dataGridViewEjercicios.Columns[columnaSeleccionada].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            if (columnaSeleccionada >= 0 && columnaSeleccionada < dataGridViewEjercicios.Columns.Count) // Verifica que haya una columna seleccionada
            {
                string textoBusqueda = textBoxBuscar.Text.ToLower(); // Convierte la búsqueda a minúsculas para que no distinga entre mayúsculas y minúsculas
                bool coincidenciaEncontrada = false;

                foreach (DataGridViewRow fila in dataGridViewEjercicios.Rows)
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
            foreach (DataGridViewRow fila in dataGridViewEjercicios.Rows)
            {
                fila.Visible = true;
            }

            // Limpiar el TextBox de búsqueda
            textBoxBuscar.Text = "";

            // Resetear el color de las columnas
            foreach (DataGridViewColumn col in dataGridViewEjercicios.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.White;
            }

            // Limpia la selección del DataGridView
            dataGridViewEjercicios.ClearSelection();
        }
    }
}
