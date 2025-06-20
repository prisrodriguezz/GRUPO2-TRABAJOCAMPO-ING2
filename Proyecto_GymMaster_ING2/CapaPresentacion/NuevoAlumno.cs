using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class NuevoAlumno : Form
    {
        private string rutaImagen;

        public event Action AlumnoRegistrado;

        public event Action AlumnoEditado;


        public NuevoAlumno()
        {
            InitializeComponent();

            if(textBoxIDalumno.Text == "0")
            {
                // Deshabilitar el ComboBox de coachs al inicio
                comboBoxCoachs.Enabled = false;

            }

            CargarCoachs();
            CargarPlanes();
            CargarMembresias();

        }

        // Metodo para cargar el formulario con los datos del Alumno a modificar
        public void CargarDatosAlumno(int idAlumno)
        {
            BCancelar.Visible = false;

            List<Alumno> listaAlumno = new CN_Alumno().Listar();

            foreach (Alumno item in listaAlumno)
            {
                if(item.id_alumno == idAlumno)
                {
                    // Asignar los valores a los controles del formulario
                    textBoxIDalumno.Text = item.id_alumno.ToString();
                    textBoxNombre.Text = item.nombre;
                    textBoxApellido.Text = item.apellido;
                    textBoxEmail.Text = item.email;
                    textBoxDNI.Text = item.dni;
                    textBoxTelefono.Text = item.telefono;
                    textBoxContactoEmerg.Text = item.contacto_emergencia;
                    textBoxObservaciones.Text = item.observaciones;
                    dateTimePicker1.Value = item.fecha_nacimiento;
                    textBoxRutaImagen.Text = item.foto;

                    rutaImagen = item.foto;
                    pictureBox1.Image = Image.FromFile(rutaImagen); // Cargar la imagen si está disponible

                    // Asignar el sexo
                    if (item.sexo == "Masculino")
                        checkBoxMasculino.Checked = true;
                    else
                        checkBoxFemenino.Checked = true;


                    // Seleccionar el plan en el ComboBox
                    var planItem = comboBoxPlan.Items.Cast<dynamic>()
                        .FirstOrDefault(p => p.Value == item.id_plan);
                    if (planItem != null)
                    {
                        comboBoxPlan.SelectedItem = planItem;
                    }

                    // Seleccionar el coach en el ComboBox
                    var coachItem = comboBoxCoachs.Items.Cast<dynamic>()
                        .FirstOrDefault(c => c.Value == item.id_usuario);
                    if (coachItem != null)
                    {
                        comboBoxCoachs.SelectedItem = coachItem;
                    }


                    // Seleccionar la membresía en el ComboBox
                    var membresiaItem = comboBoxTipoMembresia.Items.Cast<dynamic>()
                        .FirstOrDefault(m => m.Value == item.id_membresia);
                    if (membresiaItem != null)
                    {
                        comboBoxTipoMembresia.SelectedItem = membresiaItem;
                    }
                }
            }

        }

        // Método para cargar los coachs en el ComboBox
        private void CargarCoachs()
        {
            // Limpiar el ComboBox antes de agregar nuevos elementos
            comboBoxCoachs.Items.Clear();

            // Obtener la lista de usuarios
            List<Usuario> listausuario = new CN_usuario().ListarCoachs();

            // Añadir los coachs al ComboBox
            foreach (Usuario item in listausuario)
            {
                // Verifica si un coach esta activo
                if (item.estado == true)
                {
                    // Agregar el coach como un nuevo item en el ComboBox
                    comboBoxCoachs.Items.Add(new { Text = $"{item.nombre} {item.apellido}", Value = item.id_usuario });
                }
            }

            comboBoxCoachs.DisplayMember = "Text"; // Muestra el nombre y apellido
            comboBoxCoachs.ValueMember = "Value";   // Valor del id_usuario
        }


        // Método para cargar los planes en el ComboBox
        private void CargarPlanes()
        {
            // Limpiar el ComboBox antes de agregar nuevos elementos
            comboBoxPlan.Items.Clear();

            // Obtener la lista de planes
            List<PlanEntrenamiento> listaPlanes = new CN_PlanEntrenamiento().Listar();

            // Añadir los planes al ComboBox
            foreach (PlanEntrenamiento item in listaPlanes)
            {
                // Solo añade planes activos al ComboBox y si estan dentro las fechas validas
                if (item.estado && item.fechaInicio <= DateTime.Now && item.fechaFin >= DateTime.Now)
                {
                    comboBoxPlan.Items.Add(new { Text = item.nombre, Value = item.id_plan });
                }
                /*
                if (item.estado)
                {
                    // Agregar el plan como un nuevo item en el ComboBox
                    comboBoxPlan.Items.Add(new { Text = item.nombre, Value = item.id_plan });
                }*/
            }

            comboBoxPlan.DisplayMember = "Text"; // Muestra el nombre del plan
            comboBoxPlan.ValueMember = "Value";   // Valor del id_plan
        }

        // Método para cargar las membresías en el ComboBox
        private void CargarMembresias()
        {
            // Limpiar el ComboBox antes de agregar nuevos elementos
            comboBoxTipoMembresia.Items.Clear();

            // Obtener la lista de membresías
            List<Membresia> listaMembresias = new CN_membresia().Listar();

            // Añadir las membresías al ComboBox
            foreach (Membresia item in listaMembresias)
            {
                if(item.estado == true)
                {
                    // Agregar la membresía como un nuevo item en el ComboBox
                    comboBoxTipoMembresia.Items.Add(new { Text = item.nombre, Value = item.id_membresia });
                }
            }

            // Configura el ComboBox para mostrar el texto adecuado
            comboBoxTipoMembresia.DisplayMember = "Text"; // Muestra el nombre de la membresía
            comboBoxTipoMembresia.ValueMember = "Value";   // Valor del id_membresia
        }



        private void BConfirmarAlumno_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Validaciones para campos obligatorios
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                mensaje = "Todos los campos son obligatorios.";
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validacion para la carga de imagen
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, cargue una imagen antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud del teléfono
            if (textBoxTelefono.Text.Length < 7 || textBoxTelefono.Text.Length > 15)
            {
                mensaje = "El número de teléfono debe tener entre 7 y 15 dígitos.";
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud del contacto de emergencia
            if (!string.IsNullOrWhiteSpace(textBoxContactoEmerg.Text) &&
                (textBoxContactoEmerg.Text.Length < 7 || textBoxContactoEmerg.Text.Length > 15))
            {
                mensaje = "El número de contacto de emergencia debe tener entre 7 y 15 dígitos.";
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud del DNI
            if (textBoxDNI.Text.Length != 8)
            {
                mensaje = "El DNI debe tener exactamente 8 caracteres.";
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato del email
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensaje = "El formato del Email no es válido.";
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que los ComboBox no estén vacíos
            if (comboBoxPlan.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un plan.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxCoachs.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un coach.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTipoMembresia.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una membresia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar la seleccion de los checkBox
            if (!checkBoxFemenino.Checked && !checkBoxMasculino.Checked)
            {
                MessageBox.Show("Debe seleccionar el sexo del alumno.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el sexo según el CheckBox seleccionado
            string sexoCheckBox = checkBoxMasculino.Checked ? "Masculino" : "Femenino";


            // Crear un objeto Alumno 
            Alumno alumno = new Alumno
            {
                id_alumno = Convert.ToInt32(textBoxIDalumno.Text),
                id_usuario = ((dynamic)comboBoxCoachs.SelectedItem).Value,
                id_membresia = ((dynamic)comboBoxTipoMembresia.SelectedItem).Value,
                id_plan = ((dynamic)comboBoxPlan.SelectedItem).Value,
                nombre = textBoxNombre.Text,
                apellido = textBoxApellido.Text,
                email = textBoxEmail.Text,
                telefono = textBoxTelefono.Text,
                foto = rutaImagen,  // La ruta de la imagen seleccionada
                dni = textBoxDNI.Text,
                fecha_nacimiento = dateTimePicker1.Value,
                contacto_emergencia = textBoxContactoEmerg.Text,
                sexo = sexoCheckBox,
                observaciones = textBoxObservaciones.Text,
                estado = true
            };

            if(textBoxIDalumno.Text == "0") //Nuevo alumno
            {
                int idUsuarioGenerado = new CN_Alumno().Registrar(alumno, out mensaje);

                if (idUsuarioGenerado == 0) //mensaje de error 
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    // Mensaje de éxito
                    MessageBox.Show(mensaje);
                    AlumnoRegistrado?.Invoke(); //evento

                    Alumno alumnoCreado = new Alumno
                    {
                        id_usuario = ((dynamic)comboBoxCoachs.SelectedItem).Value,
                        id_membresia = ((dynamic)comboBoxTipoMembresia.SelectedItem).Value,
                        id_plan = ((dynamic)comboBoxPlan.SelectedItem).Value,
                        id_alumno = idUsuarioGenerado,
                        nombre = textBoxNombre.Text,
                        apellido = textBoxApellido.Text,
                        email = textBoxEmail.Text,
                        telefono = textBoxTelefono.Text,
                        foto = rutaImagen,  // La ruta de la imagen seleccionada
                        dni = textBoxDNI.Text,
                        fecha_nacimiento = dateTimePicker1.Value,
                        contacto_emergencia = textBoxContactoEmerg.Text,
                        sexo = sexoCheckBox,
                        observaciones = textBoxObservaciones.Text,
                        estado = true
                    };

                    //Modal para cobrar la inscripcion del alumno
                    using (var modal = new CobrarCuotaAlumno(alumnoCreado, 0))
                    {
                        var resultado = modal.ShowDialog();

                        this.Close(); //cierra modal actual
                    }
                }
            }
            else //Alumno a modificar
            {

                bool resultado = new CN_Alumno().Editar(alumno, out mensaje);

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AlumnoRegistrado?.Invoke();
                    AlumnoEditado?.Invoke(); 

                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro desea eliminar todos los datos ingresados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                textBoxNombre.Clear();
                textBoxApellido.Clear();
                textBoxDNI.Clear();
                textBoxEmail.Clear();
                textBoxTelefono.Clear();
                textBoxContactoEmerg.Clear();
                textBoxObservaciones.Clear();
                textBoxRutaImagen.Clear();
                checkBoxFemenino.Checked = false;
                checkBoxMasculino.Checked = false;
                //dateTimePicker1.Value = DateTime.Now;
                pictureBox1.Image = null;
            }
        }

        private void BCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Cargar la imagen en el PictureBox
                this.pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                // Almacenar la ruta o el nombre del archivo para usarlo al guardar
                this.rutaImagen = openFileDialog.FileName;
            }

            textBoxRutaImagen.Text = rutaImagen;
        }

        private void NuevoAlumno_Load(object sender, EventArgs e)
        {
            if(textBoxIDalumno.Text == "0")
            {
                // Limitar el DateTimePicker para que solo permita fechas entre hace 120 años y hace 10 años
                dateTimePicker1.MaxDate = DateTime.Today.AddYears(-10); 
                dateTimePicker1.MinDate = DateTime.Today.AddYears(-120); 

            }
        }

        private void checkBoxFemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemenino.Checked)
            {
                checkBoxMasculino.Checked = false;
            }
        }

        private void checkBoxMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMasculino.Checked)
            {
                checkBoxFemenino.Checked = false;
            }
        }

        private void comboBoxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asegúrate de que haya un elemento seleccionado
            if (comboBoxPlan.SelectedItem != null)
            {
                // Habilitar el ComboBox de coachs cuando se selecciona un plan
                comboBoxCoachs.Enabled = true;

                // Obtener el ID del plan seleccionado
                int selectedPlanId = (int)((dynamic)comboBoxPlan.SelectedItem).Value;

                // Obtener la lista de coachs para el plan seleccionado
                List<Usuario> listaCoachs = new CN_PlanEntrenamiento().ListarCoachsPorPlan(selectedPlanId);

                comboBoxCoachs.Items.Clear(); // Limpiar el ComboBox de coachs

                // Añadir los coachs filtrados al ComboBox
                foreach (Usuario coach in listaCoachs)
                {
                    comboBoxCoachs.Items.Add(new { Text = $"{coach.nombre} {coach.apellido}", Value = coach.id_usuario });
                }

                comboBoxCoachs.DisplayMember = "Text"; // Muestra el nombre y apellido
                comboBoxCoachs.ValueMember = "Value";   // Valor del id_usuario
            }
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDNI.Text.Length > 8)
            {
                // limita el campo a 8 digitos
                textBoxDNI.Text = textBoxDNI.Text.Substring(0, 8);
                textBoxDNI.SelectionStart = textBoxDNI.Text.Length; //coloca el cursor al final del texto
            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo admite numeros
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //ignora la tecla si no es numero o backspace
            }
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo admite numeros
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //ignora la tecla si no es numero o backspace
            }
        }

        private void textBoxContactoEmerg_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo admite numeros
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //ignora la tecla si no es numero o backspace
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y espacios
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignora la tecla si no es letra o espacio
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y espacios
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignora la tecla si no es letra o espacio
            }
        }

    }
}
