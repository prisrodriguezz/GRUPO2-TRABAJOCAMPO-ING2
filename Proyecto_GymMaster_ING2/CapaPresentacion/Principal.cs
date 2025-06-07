using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        //variables que sirven para almacenar el menu y formulario que se esta visualizando
        private static IconMenuItem MenuActivo = null;
        private static IconMenuItem SubMenuActivo = null;
        private static Form formularioActivo = null;

        private static Usuario usuarioActual;

        public Principal(Usuario usuario)
        {
            usuarioActual = usuario;

            InitializeComponent();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro desea cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(respuesta == DialogResult.Yes){
                this.Close();
            }
        }

        //metodo para abrir los distintos formularios
        public void AbrirFormulario(IconMenuItem menu, IconMenuItem subMenu, Form formulario) //recibe el menu que fue clickeado y el formulario que se desea abrir
        {
            //si hay un menu/subMenu activo se vuelve a su color normal
            if (MenuActivo != null){
                MenuActivo.BackColor = Color.OrangeRed;
            }
            if(SubMenuActivo != null){
                SubMenuActivo.BackColor = Color.White;
            }


            //nuevo menu a visualizar
            menu.BackColor = Color.White; //cambia color del menu para identificar que esta siendo clikeado
            MenuActivo = menu; //pasa a ser el menu activo


            //si existe un subMenu
            if(subMenu != null)
            {
                subMenu.BackColor = Color.Silver; //cambia color del sub menu para identificar que esta siendo clikeado
                SubMenuActivo = subMenu;
            }


            /*visualizar formulario del menu seleccionado*/

            if (formularioActivo != null){
                formularioActivo.Close(); //el formulario que se encuentra activo se cierra
            }

            formularioActivo = formulario; //formulario que se desea visualizar

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill; //se adapta a todo el espacio del contenedor
            formulario.BackColor = Color.White; //color de fondo del formulario

            contenedor.Controls.Add(formulario); //agrega el formulario al panel de la pagina principal
            formulario.Show();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, null, new Usuarios(usuarioActual));
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            nombreUsuario.Text = usuarioActual.nombre + " " + usuarioActual.apellido;

            if(usuarioActual.id_rol != null)
            {
                rolUsuario.Text = usuarioActual.id_rol.descripcion;
            }


            // permisos de vistas segun el rol
            List<Permiso> listaPermisos = new CN_permiso().Listar(usuarioActual.id_usuario);

            foreach (IconMenuItem iconmenu in menuOpciones.Items )
            {
                bool encontrado = listaPermisos.Any(m => m.nombreMenu == iconmenu.Name);

                if(encontrado == false)
                {
                    iconmenu.Visible = false; //oculta el menu no encontrado en la lista de permisos
                }
            }
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToString("dddd, MMMM yyyy");
        }

        private void menuPlanes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, null, new ListaPlanesDeEntrenamiento(usuarioActual));
        }
        private void menuAlumnos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, null, new ListaAlumnos(usuarioActual));
        }
    }
}
