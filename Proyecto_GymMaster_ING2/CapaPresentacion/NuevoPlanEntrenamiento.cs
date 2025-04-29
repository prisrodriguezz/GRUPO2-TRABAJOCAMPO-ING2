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
    public partial class NuevoPlanEntrenamiento : Form
    {
        private Usuario usuarioActual; // Objeto usuario actual
        private List<Usuario> coachsSeleccionados = new List<Usuario>(); // Lista de coachs seleccionados
        private List<Ejercicio> ejerciciosSeleccionados = new List<Ejercicio>(); // Lista de ejercicios seleccionados

        public event Action PlanRegistrado; // evento para actualiar la vista

        public NuevoPlanEntrenamiento(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void NuevoPlanEntrenamiento_Load(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = DateTime.Parse(usuarioActual.fecha_nacimiento);

            dataGridCoachSeleccionados.Rows.Add(" ", usuarioActual.id_usuario, usuarioActual.nombre, usuarioActual.apellido,
                usuarioActual.dni, usuarioActual.email, fechaNacimiento.ToString("dd/MM/yyyy"), usuarioActual.telefono);
        }

        private void BAgregarEjercicio_Click(object sender, EventArgs e)
        {
            //Modal para agregar nuevo ejercicio
            using (var modal = new Ejercicios(this))
            {
                var resultado = modal.ShowDialog();
            }
        }

        private void BAgregarCoach_Click(object sender, EventArgs e)
        {
            //Modal para agregar nuevo coach
            using (var modal = new AgregarCoachAlPlan(usuarioActual, this)) // Pasar instancia de NuevoPlanEntrenamiento
            {
                var resultado = modal.ShowDialog();
            }
        }

        // Método para recibir la lista de coachs seleccionados
        public void ActualizarCoachsSeleccionados(Usuario coach)
        {
            // Verifica si el coach ya está en la lista basada en el id_usuario
            bool coachDuplicado = coachsSeleccionados.Any(c => c.id_usuario == coach.id_usuario);

            if (!coachDuplicado) // Si no está duplicado, agrega a la lista
            {
                coachsSeleccionados.Add(coach);
                dataGridCoachSeleccionados.Rows.Add("Eliminar", coach.id_usuario, coach.nombre, coach.apellido,
                    coach.dni, coach.email, coach.fecha_nacimiento, coach.telefono);
            }
            else
            {
                MessageBox.Show("Este coach ya ha sido agregado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // Método para recibir la lista de ejercicios seleccionados
        public void ActualizarEjerciciosSeleccionados(Ejercicio ejerc)
        {
            // Verifica si el ejercicio ya está en la lista basada en el id_ejercicio
            bool ejercicioDuplicado = ejerciciosSeleccionados.Any(e => e.id_ejercicio == ejerc.id_ejercicio);

            if (!ejercicioDuplicado) // Si no está duplicado, agrega a la lista
            {
                ejerciciosSeleccionados.Add(ejerc);
                dataGridViewEjerciciosSeleccionados.Rows.Add("Eliminar", ejerc.id_ejercicio, ejerc.nombre, ejerc.repeticiones, ejerc.tiempo);
            }
            else
            {
                MessageBox.Show("Este ejercicio ya ha sido agregado.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BConfirmarPlan_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Verifica si el DataGridView de ejercicios tiene filas
            if (dataGridViewEjerciciosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un ejercicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Validaciones de campos vacíos
            if (string.IsNullOrWhiteSpace(textBoxNombrePlan.Text) ||
                string.IsNullOrWhiteSpace(textBoxCantSeries.Text) ||
                (dateTimePicker1.Value == DateTime.MinValue) ||
                (dateTimePicker2.Value == DateTime.MinValue))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Crea el objeto PlanEntrenamiento con los datos ingresados en el formulario
            PlanEntrenamiento planEntre = new PlanEntrenamiento()
            {
                id_plan = Convert.ToInt32(textBoxID.Text),
                nombre = textBoxNombrePlan.Text,
                fechaInicio = dateTimePicker1.Value.Date, // Toma solo la fecha, sin la hora
                fechaFin = dateTimePicker2.Value.Date,
                cantSeries = Convert.ToInt32(textBoxCantSeries.Text),
                estado = true // Estado activo por defecto
            };
            
            if(textBoxID.Text == "0") //si el campo id del formulario es 0, se desea crear un nuevo plan
            {
                //Crea la instancia de la capa de negocio
                CN_PlanEntrenamiento planNegocio = new CN_PlanEntrenamiento();

                //Retorna un entero que puede ser 0 o el id del nuevo plan creado
                int idPlanGenerado = planNegocio.Agregar(planEntre, out mensaje);

                if (idPlanGenerado == 0) //Si es 0 se produjo un error al crear el nuevo plan
                {
                    // Muestra el mensaje que devolvió la capa de negocio
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else // idPlanGenerado !=0, se creo el plan correctamente
                {
                    // Listas para almacenar los IDs seleccionados en el dataGrid y relacionar al plan
                    List<int> listaEjercicios = new List<int>();
                    List<int> listaUsuarios = new List<int>();

                    // Recorre el DataGrid de ejercicios seleccionados
                    foreach (DataGridViewRow row in dataGridViewEjerciciosSeleccionados.Rows)
                    {
                        int idEjercicio = Convert.ToInt32(row.Cells["idEjercicio"].Value);
                        listaEjercicios.Add(idEjercicio);
                    }

                    // Recorre el DataGridView de usuarios seleccionados
                    foreach (DataGridViewRow row in dataGridCoachSeleccionados.Rows)
                    {
                        int idUsuario = Convert.ToInt32(row.Cells["idUsuario"].Value);
                        listaUsuarios.Add(idUsuario);
                    }

                    // Asocia ejercicios y coachs al plan generado
                    planNegocio.AsociarEjercicios(idPlanGenerado, listaEjercicios);
                    planNegocio.AsociarUsuarios(idPlanGenerado, listaUsuarios);

                    // Muestra mensaje de exito
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PlanRegistrado?.Invoke(); // Dispara el evento de plan agregado para refrescar la vista
                    this.Close(); // Cierra el formulario
                }
            }
            else //si el campo id del formulario es !=0, se desea modificar un plan existente
            {
                //Crea la instancia de la capa de negocio
                CN_PlanEntrenamiento planNegocio = new CN_PlanEntrenamiento();

                //Retorna un entero que puede ser 0 o el id del plan modificado
                int idPlanModificado = planNegocio.Editar(planEntre, out mensaje);

                planNegocio.EliminarPlan_Ejercicio(planEntre.id_plan);

                planNegocio.EliminarPlan_Usuario(planEntre.id_plan);

                if (idPlanModificado == 0)
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Listas para almacenar los IDs seleccionados
                    List<int> listaEjercicios = new List<int>();
                    List<int> listaUsuarios = new List<int>();

                    // Recorrer el DataGrid de ejercicios seleccionados
                    foreach (DataGridViewRow row in dataGridViewEjerciciosSeleccionados.Rows)
                    {
                        int idEjercicio = Convert.ToInt32(row.Cells["idEjercicio"].Value);
                        listaEjercicios.Add(idEjercicio);
                    }

                    // Recorrer el DataGrid de usuarios seleccionados
                    foreach (DataGridViewRow row in dataGridCoachSeleccionados.Rows)
                    {
                        int idUsuario = Convert.ToInt32(row.Cells["idUsuario"].Value);
                        listaUsuarios.Add(idUsuario);
                    }

                    // Asociar ejercicios y usuarios al plan generado
                    planNegocio.AsociarEjercicios(idPlanModificado, listaEjercicios);
                    planNegocio.AsociarUsuarios(idPlanModificado, listaUsuarios);

                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PlanRegistrado?.Invoke(); // Dispara el evento de plan agregado para refrescar la vista
                    this.Close(); // Cierra el formulario
                }
            }
        }

        // Carga los datos en el form para realizar la modificacion
        public void CargarDatosPlan(int idPlan)
        {
            BCancelar.Visible = false;

            string mensaje = string.Empty;

            PlanEntrenamiento plan = new CN_PlanEntrenamiento().ObtenerPlanPorID(idPlan, out mensaje);

            // Carga de datos
            textBoxID.Text = idPlan.ToString();
            textBoxNombrePlan.Text = plan.nombre;
            textBoxCantSeries.Text = plan.cantSeries.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(plan.fechaInicio);
            dateTimePicker2.Value = Convert.ToDateTime(plan.fechaFin);

            // Cargar ejercicios en el DataGridView
            List<Ejercicio> listaEjercicios = new CN_PlanEntrenamiento().ListarEjerciciosPorPlan(idPlan);
            dataGridViewEjerciciosSeleccionados.Rows.Clear();
            foreach (Ejercicio ejercicio in listaEjercicios)
            {
                dataGridViewEjerciciosSeleccionados.Rows.Add("Eliminar", ejercicio.id_ejercicio, ejercicio.nombre, ejercicio.repeticiones, ejercicio.tiempo);
            }

            // Cargar coachs en el DataGridView
            List<Usuario> listaCoachs = new CN_PlanEntrenamiento().ListarCoachsPorPlan(idPlan);
            dataGridCoachSeleccionados.Rows.Clear();
            foreach (Usuario coach in listaCoachs)
            {
                dataGridCoachSeleccionados.Rows.Add("Eliminar", coach.id_usuario, coach.nombre, coach.apellido, coach.dni, coach.email, coach.fecha_nacimiento, coach.telefono);
            }
        }

        private void dataGridCoachSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en la columna de eliminar
            if (e.ColumnIndex == dataGridCoachSeleccionados.Columns["eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del coach seleccionado
                int idCoach = Convert.ToInt32(dataGridCoachSeleccionados.Rows[e.RowIndex].Cells["idUsuario"].Value);

                // Condición para evitar la eliminación del coach actual
                if (idCoach == usuarioActual.id_usuario)
                {
                    MessageBox.Show("No se puede eliminar este registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Sale del método sin hacer nada
                }

                // Eliminar el coach de la lista de seleccionados
                Usuario coachAEliminar = coachsSeleccionados.FirstOrDefault(c => c.id_usuario == idCoach);
                if (coachAEliminar != null)
                {
                    coachsSeleccionados.Remove(coachAEliminar);
                }

                // Eliminar la fila del DataGridView
                dataGridCoachSeleccionados.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridViewEjerciciosSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en la columna de eliminar
            if (e.ColumnIndex == dataGridViewEjerciciosSeleccionados.Columns["accion"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del ejercicio seleccionado
                int idEjercicio = Convert.ToInt32(dataGridViewEjerciciosSeleccionados.Rows[e.RowIndex].Cells["idEjercicio"].Value);

                // Eliminar el ejercicio de la lista de seleccionados
                Ejercicio ejercicioEliminar = ejerciciosSeleccionados.FirstOrDefault(c => c.id_ejercicio == idEjercicio);
                if (ejercicioEliminar != null)
                {
                    ejerciciosSeleccionados.Remove(ejercicioEliminar);
                }

                // Eliminar la fila del DataGridView
                dataGridViewEjerciciosSeleccionados.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo admite numeros
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //ignora la tecla si no es numero o backspace
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro desea eliminar todos los datos ingresados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            textBoxNombrePlan.Clear();
            textBoxCantSeries.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dataGridViewEjerciciosSeleccionados.Rows.Clear();

            // Limpia el dataGrid de coach seleccionados menos el registro que pertenece al usuario actual
            for (int i = dataGridCoachSeleccionados.Rows.Count - 1; i >= 0; i--)
            {
                // Verifica si el ID del usuario de la fila no es el del usuario actual
                if (Convert.ToInt32(dataGridCoachSeleccionados.Rows[i].Cells["idUsuario"].Value) != usuarioActual.id_usuario)
                {
                    dataGridCoachSeleccionados.Rows.RemoveAt(i);
                }
            }
        }
    }
}
