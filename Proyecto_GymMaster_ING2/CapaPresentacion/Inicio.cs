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
