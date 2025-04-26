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

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_usuario().Listar();
            Usuario ousuario = new CN_usuario().Listar().Where(u => u.dni == textBoxDni.Text && u.contraseña == textBoxContraseña.Text).FirstOrDefault();

            if (ousuario == null)
            {
                MessageBox.Show("Los datos ingresados son incorrectos o el usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxDni.Text = "";
                textBoxContraseña.Text = "";
            }
            else if (!ousuario.estado)
            {
                MessageBox.Show("El usuario está inactivo.", "Usuario Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxDni.Text = "";
                textBoxContraseña.Text = "";
            }
            else
            {
                Principal form = new Principal(ousuario); //crea una instancia del formulario principal

                this.Hide(); //el formulario del login(inicio) se oculta una vez ingresado

                form.ShowDialog(); //muestra el formulario principal como diálogo modal

                textBoxDni.Text = "";
                textBoxContraseña.Text = "";
            }

            //this.Close(); //cuando el formulario principal se cierra tambien se cierra el programa

            this.Show(); //muestra de nuevo el formulario de inicio cuando el principal se cierra
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxDni_TextChanged(object sender, EventArgs e)
        {
            if(textBoxDni.Text.Length > 8)
            {
                // limita el campo a 8 digitos
                textBoxDni.Text = textBoxDni.Text.Substring(0, 8);
                textBoxDni.SelectionStart = textBoxDni.Text.Length; //coloca el cursor al final del texto
            }
        }

        private void TextBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo admite numeros
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; //ignora la tecla si no es numero o backspace
            }
        }

        private void TextBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            if(textBoxContraseña.Text.Length < 8)
            {
                errorProvider1.SetError(textBoxContraseña, "La contraseña debe tener al menos 8 caracteres.");
            }
            else
            {
                errorProvider1.SetError(textBoxContraseña, "");
            }
        }
    }
}
