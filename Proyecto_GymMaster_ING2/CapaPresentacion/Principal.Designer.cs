
namespace CapaPresentacion
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenimiento = new FontAwesome.Sharp.IconMenuItem();
            this.menuAlumnos = new FontAwesome.Sharp.IconMenuItem();
            this.menuPlanes = new FontAwesome.Sharp.IconMenuItem();
            this.menuPagos = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.Label();
            this.rolUsuario = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.BCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.labelHora = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.menuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOpciones
            // 
            this.menuOpciones.AutoSize = false;
            this.menuOpciones.BackColor = System.Drawing.Color.OrangeRed;
            this.menuOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuOpciones.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenimiento,
            this.menuAlumnos,
            this.menuPlanes,
            this.menuPagos});
            this.menuOpciones.Location = new System.Drawing.Point(0, 114);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuOpciones.Size = new System.Drawing.Size(280, 624);
            this.menuOpciones.TabIndex = 0;
            this.menuOpciones.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.BackColor = System.Drawing.Color.OrangeRed;
            this.menuUsuarios.Enabled = false;
            this.menuUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(220, 54);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.AutoSize = false;
            this.menuMantenimiento.Enabled = false;
            this.menuMantenimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMantenimiento.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuMantenimiento.IconColor = System.Drawing.Color.Black;
            this.menuMantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenimiento.IconSize = 50;
            this.menuMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(230, 54);
            this.menuMantenimiento.Text = "Mantenimiento";
            // 
            // menuAlumnos
            // 
            this.menuAlumnos.AutoSize = false;
            this.menuAlumnos.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAlumnos.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuAlumnos.IconColor = System.Drawing.Color.Black;
            this.menuAlumnos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAlumnos.IconSize = 50;
            this.menuAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAlumnos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAlumnos.Name = "menuAlumnos";
            this.menuAlumnos.Size = new System.Drawing.Size(220, 54);
            this.menuAlumnos.Text = "Alumnos";
            this.menuAlumnos.Click += new System.EventHandler(this.menuAlumnos_Click);
            // 
            // menuPlanes
            // 
            this.menuPlanes.AutoSize = false;
            this.menuPlanes.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPlanes.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.menuPlanes.IconColor = System.Drawing.Color.Black;
            this.menuPlanes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPlanes.IconSize = 50;
            this.menuPlanes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuPlanes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuPlanes.Name = "menuPlanes";
            this.menuPlanes.Size = new System.Drawing.Size(220, 54);
            this.menuPlanes.Text = "Planes";
            this.menuPlanes.Click += new System.EventHandler(this.menuPlanes_Click);
            // 
            // menuPagos
            // 
            this.menuPagos.AutoSize = false;
            this.menuPagos.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPagos.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            this.menuPagos.IconColor = System.Drawing.Color.Black;
            this.menuPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPagos.IconSize = 50;
            this.menuPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuPagos.Name = "menuPagos";
            this.menuPagos.Size = new System.Drawing.Size(220, 54);
            this.menuPagos.Text = "Pagos";
            this.menuPagos.Click += new System.EventHandler(this.menuPagos_Click);
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.Black;
            this.menuTitulo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1467, 114);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.LightGray;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(280, 114);
            this.contenedor.Margin = new System.Windows.Forms.Padding(4);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1187, 624);
            this.contenedor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1055, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.AutoSize = true;
            this.nombreUsuario.BackColor = System.Drawing.Color.Black;
            this.nombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreUsuario.ForeColor = System.Drawing.Color.White;
            this.nombreUsuario.Location = new System.Drawing.Point(1136, 32);
            this.nombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(165, 24);
            this.nombreUsuario.TabIndex = 7;
            this.nombreUsuario.Text = "Nombre Completo";
            // 
            // rolUsuario
            // 
            this.rolUsuario.AutoSize = true;
            this.rolUsuario.BackColor = System.Drawing.Color.Black;
            this.rolUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolUsuario.ForeColor = System.Drawing.Color.Gray;
            this.rolUsuario.Location = new System.Drawing.Point(1055, 58);
            this.rolUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rolUsuario.Name = "rolUsuario";
            this.rolUsuario.Size = new System.Drawing.Size(136, 24);
            this.rolUsuario.TabIndex = 8;
            this.rolUsuario.Text = "Rol del usuario";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Black;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.OrangeRed;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;
            this.iconButton1.IconColor = System.Drawing.Color.OrangeRed;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 50;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(280, 114);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.Text = "GYMMASTER";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.BackColor = System.Drawing.Color.Black;
            this.BCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarSesion.FlatAppearance.BorderSize = 0;
            this.BCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.ForeColor = System.Drawing.Color.Red;
            this.BCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.RectangleXmark;
            this.BCerrarSesion.IconColor = System.Drawing.Color.Red;
            this.BCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BCerrarSesion.IconSize = 50;
            this.BCerrarSesion.Location = new System.Drawing.Point(1361, 21);
            this.BCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(89, 76);
            this.BCerrarSesion.TabIndex = 5;
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.BackColor = System.Drawing.Color.OrangeRed;
            this.labelHora.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.Location = new System.Drawing.Point(63, 635);
            this.labelHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(133, 36);
            this.labelHora.TabIndex = 0;
            this.labelHora.Text = "00:00:00";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.BackColor = System.Drawing.Color.OrangeRed;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(28, 672);
            this.labelFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(232, 23);
            this.labelFecha.TabIndex = 9;
            this.labelFecha.Text = "domingo, septiembre 2024";
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 738);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.rolUsuario);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BCerrarSesion);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menuOpciones);
            this.Controls.Add(this.menuTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuOpciones;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuMantenimiento;
        private FontAwesome.Sharp.IconMenuItem menuAlumnos;
        private FontAwesome.Sharp.IconMenuItem menuPlanes;
        private FontAwesome.Sharp.IconMenuItem menuPagos;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton BCerrarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nombreUsuario;
        private System.Windows.Forms.Label rolUsuario;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Timer horaFecha;
    }
}

