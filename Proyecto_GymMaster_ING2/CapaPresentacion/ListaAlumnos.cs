using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class ListaAlumnos : Form
    {
        private CN_Alumno objCN_Alumno = new CN_Alumno(); // Capa de negocio para alumnos
        private Usuario usuarioActual; // Objeto usuario actual

        private int columnaSeleccionada = -1; // Variable para almacenar el índice de la columna seleccionada

        public ListaAlumnos(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarAlumnos(); // Cargar datos al abrir el formulario
        }

        // Método para cargar alumnos en el DataGridView
        private void CargarAlumnos()
        {
            List<Alumno> listaAlumnos = objCN_Alumno.Listar();

            dgvdata.Rows.Clear(); // Limpia el DataGrid antes de actualizar
            foreach (Alumno item in listaAlumnos)
            {
                if(usuarioActual.id_rol.id_rol == 3)
                {
                    labelTITULO.Text = "MIS ALUMNOS";

                    if(item.id_usuario == usuarioActual.id_usuario)
                    {
                        dgvdata.Rows.Add(new object[]{"Ver ficha",item.id_alumno,item.nombre, item.apellido,item.dni,
                        item.email,item.fecha_nacimiento.ToString("dd/MM/yyyy"),item.telefono, item.sexo, item.estado == true ? "Activo" : "Inactivo"});

                    }
                }
                else
                {
                    // Verifica si el alumno adeuda cuotas
                    bool cuotaAlDia = objCN_Alumno.VerificarCuotaAlumno(item.id_alumno, out int mesesAdeudados, out string mensaje);

                    var row = dgvdata.Rows.Add(new object[]{
                        "Ver ficha", item.id_alumno, item.nombre, item.apellido, item.dni,
                        item.email, item.fecha_nacimiento.ToString("dd/MM/yyyy"), item.telefono, item.sexo, item.estado == true ? "Activo" : "Inactivo"
                    });

                    // Cambia el color de la fila si adeuda cuota
                    if (!cuotaAlDia)
                    {
                        dgvdata.Rows[row].DefaultCellStyle.BackColor = Color.MistyRose; // Cambia el color de la fila si adeuda cuota
                    }

                    /*
                    dgvdata.Rows.Add(new object[]{"Ver ficha",item.id_alumno,item.nombre, item.apellido,item.dni,
                    item.email,item.fecha_nacimiento.ToString("dd/MM/yyyy"),item.telefono, item.sexo, item.estado == true ? "Activo" : "Inactivo"});
                    */
                }
            }

            labelCantidad.Text = $"{dgvdata.Rows.Count} alumnos";
        }


        private void BNuevoAlumno_Click(object sender, EventArgs e)
        {
            //Modal para agregar nuevo alumno
            
            using (var modal = new NuevoAlumno())
            {
                modal.AlumnoRegistrado += CargarAlumnos; // Evento
                var resultado = modal.ShowDialog();
            }
        }

        private void ListaAlumnos_Load(object sender, EventArgs e)
        {
            // Si el rol es de coach ocultamos el botón de nuevo alumno
            if (usuarioActual.id_rol.descripcion == "Coach")
            {
                BNuevoAlumno.Visible = false;
                groupBox1.Visible = false;
            }

            // Cambia el color de texto de la fila seleccionada en el DataGridView
            dgvdata.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvdata.DefaultCellStyle.SelectionBackColor = Color.Silver; // Color gris para la selección de celdas

            // Cambia el modo de selección a que solo permita seleccionar las cabeceras de las columnas
            dgvdata.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvdata.Columns["verFicha"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del alumno de la fila seleccionada
                int idAlumno = Convert.ToInt32(dgvdata.Rows[e.RowIndex].Cells["idAlumno"].Value);

                //Modal para ver ficha del alumno
                /*using (var modal = new FichaAlumno(idAlumno, usuarioActual))
                {
                    modal.AlumnoActualizado += () => CargarAlumnos(); // evento para actualizar dataGrid
                    var resultado = modal.ShowDialog();
                }*/
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

        private void iconButton1_Click(object sender, EventArgs e)
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

        private void iconButton2_Click(object sender, EventArgs e)
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
