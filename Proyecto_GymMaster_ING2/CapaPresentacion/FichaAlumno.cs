using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FichaAlumno : Form
    {
        private int alumno;
        private CN_Alumno objCN_Alumno = new CN_Alumno(); // Capa de negocio para alumnos

        public event Action AlumnoActualizado; // Evento para notificar al formulario principal
        private Usuario usuarioActual;

        public FichaAlumno(int idAlumno, Usuario usuario)
        {
            InitializeComponent();
            alumno = idAlumno;

            usuarioActual = usuario;
            if (usuarioActual.id_rol.id_rol == 2)
            {
                BModificarAlumno.Visible = false;
                BListaDePagos.Visible = false;
                BCobrarCuota.Visible = false;
                BRestaurarAlumno.Visible = false;
                BbajaAlumno.Visible = false;
            }
        }

        private void BCobrarCuota_Click(object sender, EventArgs e)
        {
            List<Alumno> listaAlumnos = objCN_Alumno.Listar();

            foreach (Alumno item in listaAlumnos)
            {
                if (item.id_alumno == alumno)
                {
                    // Crear un objeto Alumno 
                    Alumno objAlumno = new Alumno
                    {
                        id_alumno = item.id_alumno,
                        id_usuario = item.id_usuario,
                        id_membresia = item.id_membresia,
                        id_plan = item.id_plan,
                        nombre = item.nombre,
                        apellido = item.apellido,
                        email = item.email,
                        telefono = item.telefono,
                        foto = item.foto, 
                        dni = item.dni,
                        fecha_nacimiento = item.fecha_nacimiento,
                        contacto_emergencia = item.contacto_emergencia,
                        sexo = item.sexo,
                        observaciones = item.observaciones,
                        estado = item.estado
                    };

                    //Modal para cobrar cuota del alumno
                    using (var modal = new CobrarCuotaAlumno(objAlumno, 1))
                    {
                        var resultado = modal.ShowDialog();
                    }
                }
            }

        }

        private void FichaAlumno_Load(object sender, EventArgs e)
        {
            int idMembresia = 0;
            int idUsuario = 0;
            int idPlan = 0;

            List<Alumno> listaAlumnos = objCN_Alumno.Listar();

            foreach (Alumno item in listaAlumnos)
            {
                if (item.id_alumno == alumno)
                {
                    if(item.estado == true && usuarioActual.id_rol.id_rol == 1)
                    {
                        BbajaAlumno.Visible = true;
                        BRestaurarAlumno.Visible = false;
                    }
                    else if (item.estado == false && usuarioActual.id_rol.id_rol == 1)
                    {
                        BRestaurarAlumno.Visible = true;
                        BbajaAlumno.Visible = false;
                    }

                    labelNombreCompleto.Text = item.nombre + " " + item.apellido;
                    labelDNI.Text = item.dni;
                    labelFechaNacimiento.Text = item.fecha_nacimiento.ToString("dd/MM/yyyy");
                    labelEmail.Text = item.email;
                    labelSexo.Text = item.sexo;
                    labelTelefono.Text = item.telefono;
                    labelContactoEmergencia.Text = item.contacto_emergencia;
                    labelObservacion.Text = item.observaciones;

                    // Cargar imagen en el PictureBox desde la ruta guardada
                    if (!string.IsNullOrEmpty(item.foto) && File.Exists(item.foto))
                    {
                        pictureBox1.Image = Image.FromFile(item.foto);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la imagen del alumno.", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //pictureBox1.Image = Properties.Resources.siluetaPerfilPersona;
                    }

                    idMembresia = item.id_membresia;
                    idUsuario = item.id_usuario;
                    idPlan = item.id_plan;
                }
            }

            List<Membresia> listaMembresias = new CN_membresia().Listar();
            List<Usuario> listaUsuarios = new CN_usuario().Listar();
            List<PlanEntrenamiento> listaPlanes = new CN_PlanEntrenamiento().Listar();

            // Utilizar LINQ para encontrar las entidades relacionadas
            var membresia = listaMembresias.FirstOrDefault(m => m.id_membresia == idMembresia);
            var usuario = listaUsuarios.FirstOrDefault(u => u.id_usuario == idUsuario);
            var plan = listaPlanes.FirstOrDefault(p => p.id_plan == idPlan);

            // Agregar la información al DataGridView si se encontraron las coincidencias
            if (membresia != null && usuario != null && plan != null)
            {
                labelTipoMembresia.Text = membresia.nombre;
                labelCoachAcargo.Text = $"{usuario.nombre} {usuario.apellido}";
                labelPlanEntrenamiento.Text = plan.nombre;
            }

        }

        private void BbajaAlumno_Click(object sender, EventArgs e)
        {
            int mesesAdeudados;
            string mensaje;

            // control para saber si el alumno adeuda cuota
            bool cuotaAlDia = objCN_Alumno.VerificarCuotaAlumno(alumno, out mesesAdeudados, out mensaje);

            if (cuotaAlDia)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas dar de baja a este alumno?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool alumnoEliminado = objCN_Alumno.EliminarAlumno(alumno, out mensaje);
                    if (alumnoEliminado)
                    {
                        MessageBox.Show(mensaje);
                        FichaAlumno_Load(sender, e);

                        AlumnoActualizado?.Invoke(); // Disparar el evento para que el formulario principal actualice el DataGridView
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show($"El alumno adeuda cuota.\n ¿Deseas dar de baja a este alumno?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (resultado == DialogResult.Yes)
                {
                    bool alumnoEliminado = objCN_Alumno.EliminarAlumno(alumno, out mensaje);
                    if (alumnoEliminado)
                    {
                        MessageBox.Show(mensaje);
                        FichaAlumno_Load(sender, e);

                        AlumnoActualizado?.Invoke(); // Disparar el evento para que el formulario principal actualice el DataGridView
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
            }

        }

        private void BRestaurarAlumno_Click(object sender, EventArgs e)
        {
            string mensaje;

            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas dar de alta a este alumno?", "Confirmar alta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                bool alumnoRestaurado = objCN_Alumno.RestaurarAlumno(alumno, out mensaje);
                if (alumnoRestaurado)
                {
                    MessageBox.Show(mensaje);
                    FichaAlumno_Load(sender, e);

                    AlumnoActualizado?.Invoke(); // Disparar el evento para que el formulario principal actualice el DataGridView
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void BModificarAlumno_Click(object sender, EventArgs e)
        {
            using (var modal = new NuevoAlumno())
            {
                modal.CargarDatosAlumno(alumno);

                modal.AlumnoEditado += RefrescarDatosAlumno;

                var resultado = modal.ShowDialog();

            }
        }

        private void RefrescarDatosAlumno()
        {
            // Recargar los datos del alumno
            FichaAlumno_Load(this, EventArgs.Empty);
        }

        private void BListaDePagos_Click(object sender, EventArgs e)
        {
            using (var modal = new ListaPagosPorAlumno(alumno))
            {

                var resultado = modal.ShowDialog();

            }
        }
    }
}
