
namespace CapaPresentacion
{
    partial class NuevoAlumno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxContactoEmerg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRutaImagen = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxFemenino = new System.Windows.Forms.CheckBox();
            this.checkBoxMasculino = new System.Windows.Forms.CheckBox();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCoachs = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPlan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTipoMembresia = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BCargarImagen = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxIDalumno = new System.Windows.Forms.TextBox();
            this.BCancelar = new FontAwesome.Sharp.IconButton();
            this.BConfirmarAlumno = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxApellido.Location = new System.Drawing.Point(512, 49);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(240, 24);
            this.textBoxApellido.TabIndex = 17;
            this.textBoxApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxApellido_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(244, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Nombre/s *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(508, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Apellido *";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.Location = new System.Drawing.Point(248, 49);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(240, 24);
            this.textBoxNombre.TabIndex = 16;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDNI.Location = new System.Drawing.Point(248, 104);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(240, 24);
            this.textBoxDNI.TabIndex = 19;
            this.textBoxDNI.TextChanged += new System.EventHandler(this.textBoxDNI_TextChanged);
            this.textBoxDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDNI_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(244, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "DNI *";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(248, 159);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(240, 24);
            this.textBoxEmail.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(244, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "E-mail *";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(512, 104);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(240, 24);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(508, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fecha de nacimiento *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(508, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Sexo *";
            // 
            // textBoxContactoEmerg
            // 
            this.textBoxContactoEmerg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContactoEmerg.Location = new System.Drawing.Point(512, 213);
            this.textBoxContactoEmerg.Name = "textBoxContactoEmerg";
            this.textBoxContactoEmerg.Size = new System.Drawing.Size(240, 24);
            this.textBoxContactoEmerg.TabIndex = 27;
            this.textBoxContactoEmerg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxContactoEmerg_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(508, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Contacto emergencia";
            // 
            // textBoxRutaImagen
            // 
            this.textBoxRutaImagen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxRutaImagen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxRutaImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRutaImagen.Location = new System.Drawing.Point(16, 246);
            this.textBoxRutaImagen.Name = "textBoxRutaImagen";
            this.textBoxRutaImagen.ReadOnly = true;
            this.textBoxRutaImagen.Size = new System.Drawing.Size(203, 20);
            this.textBoxRutaImagen.TabIndex = 29;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelefono.Location = new System.Drawing.Point(248, 213);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(240, 24);
            this.textBoxTelefono.TabIndex = 31;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelefono_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(244, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Teléfono *";
            // 
            // checkBoxFemenino
            // 
            this.checkBoxFemenino.AutoSize = true;
            this.checkBoxFemenino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFemenino.Location = new System.Drawing.Point(517, 161);
            this.checkBoxFemenino.Name = "checkBoxFemenino";
            this.checkBoxFemenino.Size = new System.Drawing.Size(87, 20);
            this.checkBoxFemenino.TabIndex = 32;
            this.checkBoxFemenino.Text = "Femenino";
            this.checkBoxFemenino.UseVisualStyleBackColor = true;
            this.checkBoxFemenino.CheckedChanged += new System.EventHandler(this.checkBoxFemenino_CheckedChanged);
            // 
            // checkBoxMasculino
            // 
            this.checkBoxMasculino.AutoSize = true;
            this.checkBoxMasculino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMasculino.Location = new System.Drawing.Point(626, 161);
            this.checkBoxMasculino.Name = "checkBoxMasculino";
            this.checkBoxMasculino.Size = new System.Drawing.Size(88, 20);
            this.checkBoxMasculino.TabIndex = 33;
            this.checkBoxMasculino.Text = "Masculino";
            this.checkBoxMasculino.UseVisualStyleBackColor = true;
            this.checkBoxMasculino.CheckedChanged += new System.EventHandler(this.checkBoxMasculino_CheckedChanged);
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservaciones.Location = new System.Drawing.Point(248, 267);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.Size = new System.Drawing.Size(504, 55);
            this.textBoxObservaciones.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(244, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Observaciones";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCoachs);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxPlan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxTipoMembresia);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxObservaciones);
            this.groupBox1.Controls.Add(this.BCargarImagen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBoxMasculino);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBoxFemenino);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBoxTelefono);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.textBoxRutaImagen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxContactoEmerg);
            this.groupBox1.Controls.Add(this.textBoxDNI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.textBoxApellido);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 403);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxCoachs
            // 
            this.comboBoxCoachs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCoachs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCoachs.FormattingEnabled = true;
            this.comboBoxCoachs.Location = new System.Drawing.Point(552, 363);
            this.comboBoxCoachs.Name = "comboBoxCoachs";
            this.comboBoxCoachs.Size = new System.Drawing.Size(200, 26);
            this.comboBoxCoachs.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(548, 340);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 20);
            this.label12.TabIndex = 42;
            this.label12.Text = "COACH A CARGO:";
            // 
            // comboBoxPlan
            // 
            this.comboBoxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlan.FormattingEnabled = true;
            this.comboBoxPlan.Location = new System.Drawing.Point(288, 363);
            this.comboBoxPlan.Name = "comboBoxPlan";
            this.comboBoxPlan.Size = new System.Drawing.Size(200, 26);
            this.comboBoxPlan.TabIndex = 39;
            this.comboBoxPlan.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(284, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "PLAN ENTRENAMIENTO:";
            // 
            // comboBoxTipoMembresia
            // 
            this.comboBoxTipoMembresia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoMembresia.FormattingEnabled = true;
            this.comboBoxTipoMembresia.Location = new System.Drawing.Point(23, 363);
            this.comboBoxTipoMembresia.Name = "comboBoxTipoMembresia";
            this.comboBoxTipoMembresia.Size = new System.Drawing.Size(200, 26);
            this.comboBoxTipoMembresia.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(19, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "TIPO MEMBRESIA:";
            // 
            // BCargarImagen
            // 
            this.BCargarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCargarImagen.IconChar = FontAwesome.Sharp.IconChar.CameraAlt;
            this.BCargarImagen.IconColor = System.Drawing.Color.Black;
            this.BCargarImagen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BCargarImagen.IconSize = 40;
            this.BCargarImagen.Location = new System.Drawing.Point(16, 38);
            this.BCargarImagen.Margin = new System.Windows.Forms.Padding(0);
            this.BCargarImagen.Name = "BCargarImagen";
            this.BCargarImagen.Size = new System.Drawing.Size(46, 44);
            this.BCargarImagen.TabIndex = 4;
            this.BCargarImagen.UseVisualStyleBackColor = true;
            this.BCargarImagen.Click += new System.EventHandler(this.BCargarImagen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Location = new System.Drawing.Point(15, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxIDalumno
            // 
            this.textBoxIDalumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDalumno.Location = new System.Drawing.Point(12, 421);
            this.textBoxIDalumno.Name = "textBoxIDalumno";
            this.textBoxIDalumno.Size = new System.Drawing.Size(27, 24);
            this.textBoxIDalumno.TabIndex = 39;
            this.textBoxIDalumno.Text = "0";
            this.textBoxIDalumno.Visible = false;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.BCancelar.IconColor = System.Drawing.Color.White;
            this.BCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BCancelar.IconSize = 35;
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCancelar.Location = new System.Drawing.Point(529, 421);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(115, 35);
            this.BCancelar.TabIndex = 27;
            this.BCancelar.Text = "LIMPIAR";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmarAlumno
            // 
            this.BConfirmarAlumno.BackColor = System.Drawing.Color.Green;
            this.BConfirmarAlumno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BConfirmarAlumno.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BConfirmarAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConfirmarAlumno.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConfirmarAlumno.ForeColor = System.Drawing.Color.White;
            this.BConfirmarAlumno.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.BConfirmarAlumno.IconColor = System.Drawing.Color.White;
            this.BConfirmarAlumno.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BConfirmarAlumno.IconSize = 35;
            this.BConfirmarAlumno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BConfirmarAlumno.Location = new System.Drawing.Point(653, 421);
            this.BConfirmarAlumno.Name = "BConfirmarAlumno";
            this.BConfirmarAlumno.Size = new System.Drawing.Size(135, 35);
            this.BConfirmarAlumno.TabIndex = 26;
            this.BConfirmarAlumno.Text = "GUARDAR";
            this.BConfirmarAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BConfirmarAlumno.UseVisualStyleBackColor = false;
            this.BConfirmarAlumno.Click += new System.EventHandler(this.BConfirmarAlumno_Click);
            // 
            // NuevoAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.textBoxIDalumno);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmarAlumno);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NuevoAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALUMNO";
            this.Load += new System.EventHandler(this.NuevoAlumno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton BCargarImagen;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxContactoEmerg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRutaImagen;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxFemenino;
        private System.Windows.Forms.CheckBox checkBoxMasculino;
        private System.Windows.Forms.TextBox textBoxObservaciones;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton BConfirmarAlumno;
        private FontAwesome.Sharp.IconButton BCancelar;
        private System.Windows.Forms.TextBox textBoxIDalumno;
        private System.Windows.Forms.ComboBox comboBoxCoachs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoMembresia;
        private System.Windows.Forms.Label label11;
    }
}