
namespace CapaPresentacion
{
    partial class AgregarCoachAlPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvdataAgregarCoach = new System.Windows.Forms.DataGridView();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blimpiar = new FontAwesome.Sharp.IconButton();
            this.Bbuscar = new FontAwesome.Sharp.IconButton();
            this.LnombreColumna = new System.Windows.Forms.Label();
            this.LBuscar = new System.Windows.Forms.Label();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdataAgregarCoach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvdataAgregarCoach
            // 
            this.dgvdataAgregarCoach.AllowUserToAddRows = false;
            this.dgvdataAgregarCoach.AllowUserToDeleteRows = false;
            this.dgvdataAgregarCoach.AllowUserToResizeColumns = false;
            this.dgvdataAgregarCoach.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdataAgregarCoach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdataAgregarCoach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvdataAgregarCoach.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdataAgregarCoach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdataAgregarCoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdataAgregarCoach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuario,
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.Email,
            this.FechaNacimiento,
            this.Telefono});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdataAgregarCoach.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvdataAgregarCoach.Location = new System.Drawing.Point(12, 49);
            this.dgvdataAgregarCoach.MultiSelect = false;
            this.dgvdataAgregarCoach.Name = "dgvdataAgregarCoach";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdataAgregarCoach.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvdataAgregarCoach.RowHeadersWidth = 30;
            this.dgvdataAgregarCoach.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvdataAgregarCoach.RowTemplate.Height = 30;
            this.dgvdataAgregarCoach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdataAgregarCoach.Size = new System.Drawing.Size(561, 202);
            this.dgvdataAgregarCoach.TabIndex = 46;
            this.dgvdataAgregarCoach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdataAgregarCoach_CellDoubleClick);
            this.dgvdataAgregarCoach.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdataAgregarCoach_ColumnHeaderMouseClick);
            // 
            // idUsuario
            // 
            this.idUsuario.HeaderText = "IdUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idUsuario.Visible = false;
            this.idUsuario.Width = 66;
            // 
            // Nombre
            // 
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre.Width = 63;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Apellido.Width = 64;
            // 
            // DNI
            // 
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DNI.DefaultCellStyle = dataGridViewCellStyle4;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DNI.Width = 37;
            // 
            // Email
            // 
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.Email.DefaultCellStyle = dataGridViewCellStyle5;
            this.Email.HeaderText = "E-mail";
            this.Email.Name = "Email";
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Email.Width = 52;
            // 
            // FechaNacimiento
            // 
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.FechaNacimiento.DefaultCellStyle = dataGridViewCellStyle6;
            this.FechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaNacimiento.Width = 111;
            // 
            // Telefono
            // 
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.Telefono.DefaultCellStyle = dataGridViewCellStyle7;
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Telefono.Width = 68;
            // 
            // Blimpiar
            // 
            this.Blimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.Blimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Blimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Blimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Blimpiar.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blimpiar.ForeColor = System.Drawing.Color.White;
            this.Blimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.Blimpiar.IconColor = System.Drawing.Color.White;
            this.Blimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Blimpiar.IconSize = 25;
            this.Blimpiar.Location = new System.Drawing.Point(538, 14);
            this.Blimpiar.Name = "Blimpiar";
            this.Blimpiar.Size = new System.Drawing.Size(35, 26);
            this.Blimpiar.TabIndex = 50;
            this.Blimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Blimpiar.UseVisualStyleBackColor = false;
            this.Blimpiar.Click += new System.EventHandler(this.Blimpiar_Click);
            // 
            // Bbuscar
            // 
            this.Bbuscar.BackColor = System.Drawing.Color.LimeGreen;
            this.Bbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Bbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bbuscar.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbuscar.ForeColor = System.Drawing.Color.White;
            this.Bbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.Bbuscar.IconColor = System.Drawing.Color.White;
            this.Bbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Bbuscar.IconSize = 20;
            this.Bbuscar.Location = new System.Drawing.Point(501, 14);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(35, 26);
            this.Bbuscar.TabIndex = 49;
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = false;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
            // 
            // LnombreColumna
            // 
            this.LnombreColumna.AutoSize = true;
            this.LnombreColumna.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LnombreColumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnombreColumna.ForeColor = System.Drawing.Color.Red;
            this.LnombreColumna.Location = new System.Drawing.Point(194, 20);
            this.LnombreColumna.Name = "LnombreColumna";
            this.LnombreColumna.Size = new System.Drawing.Size(102, 16);
            this.LnombreColumna.TabIndex = 53;
            this.LnombreColumna.Text = "Nombre campo";
            this.LnombreColumna.Visible = false;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(120, 20);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(76, 16);
            this.LBuscar.TabIndex = 52;
            this.LBuscar.Text = "Buscar por:";
            this.LBuscar.Visible = false;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscar.Location = new System.Drawing.Point(320, 15);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(175, 24);
            this.textBoxBuscar.TabIndex = 51;
            // 
            // AgregarCoachAlPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(585, 263);
            this.Controls.Add(this.LnombreColumna);
            this.Controls.Add(this.LBuscar);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.Blimpiar);
            this.Controls.Add(this.Bbuscar);
            this.Controls.Add(this.dgvdataAgregarCoach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgregarCoachAlPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COACHS";
            this.Load += new System.EventHandler(this.AgregarCoachAlPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdataAgregarCoach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvdataAgregarCoach;
        private FontAwesome.Sharp.IconButton Blimpiar;
        private FontAwesome.Sharp.IconButton Bbuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Label LnombreColumna;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.TextBox textBoxBuscar;
    }
}