
namespace CapaPresentacion
{
    partial class Ejercicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LnombreColumna = new System.Windows.Forms.Label();
            this.LBuscar = new System.Windows.Forms.Label();
            this.dataGridViewEjercicios = new System.Windows.Forms.DataGridView();
            this.idEjercicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeticiones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.BLimpiar = new FontAwesome.Sharp.IconButton();
            this.Bbuscar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEjercicios)).BeginInit();
            this.SuspendLayout();
            // 
            // LnombreColumna
            // 
            this.LnombreColumna.AutoSize = true;
            this.LnombreColumna.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LnombreColumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnombreColumna.ForeColor = System.Drawing.Color.Red;
            this.LnombreColumna.Location = new System.Drawing.Point(209, 28);
            this.LnombreColumna.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LnombreColumna.Name = "LnombreColumna";
            this.LnombreColumna.Size = new System.Drawing.Size(123, 20);
            this.LnombreColumna.TabIndex = 49;
            this.LnombreColumna.Text = "Nombre campo";
            this.LnombreColumna.Visible = false;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(112, 28);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(97, 20);
            this.LBuscar.TabIndex = 48;
            this.LBuscar.Text = "Buscar por:";
            this.LBuscar.Visible = false;
            // 
            // dataGridViewEjercicios
            // 
            this.dataGridViewEjercicios.AllowUserToAddRows = false;
            this.dataGridViewEjercicios.AllowUserToDeleteRows = false;
            this.dataGridViewEjercicios.AllowUserToResizeColumns = false;
            this.dataGridViewEjercicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewEjercicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEjercicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEjercicios.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEjercicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEjercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEjercicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEjercicio,
            this.nombre,
            this.repeticiones,
            this.tiempo,
            this.editar,
            this.eliminar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEjercicios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewEjercicios.Location = new System.Drawing.Point(13, 61);
            this.dataGridViewEjercicios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewEjercicios.MultiSelect = false;
            this.dataGridViewEjercicios.Name = "dataGridViewEjercicios";
            this.dataGridViewEjercicios.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEjercicios.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewEjercicios.RowHeadersWidth = 30;
            this.dataGridViewEjercicios.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridViewEjercicios.RowTemplate.Height = 30;
            this.dataGridViewEjercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEjercicios.Size = new System.Drawing.Size(682, 268);
            this.dataGridViewEjercicios.TabIndex = 47;
            this.dataGridViewEjercicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEjercicios_CellDoubleClick);
            this.dataGridViewEjercicios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEjercicios_ColumnHeaderMouseClick);
            // 
            // idEjercicio
            // 
            this.idEjercicio.HeaderText = "ID";
            this.idEjercicio.MinimumWidth = 6;
            this.idEjercicio.Name = "idEjercicio";
            this.idEjercicio.ReadOnly = true;
            this.idEjercicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idEjercicio.Visible = false;
            this.idEjercicio.Width = 25;
            // 
            // nombre
            // 
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.nombre.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nombre.Width = 74;
            // 
            // repeticiones
            // 
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.repeticiones.DefaultCellStyle = dataGridViewCellStyle4;
            this.repeticiones.HeaderText = "Repeticiones";
            this.repeticiones.MinimumWidth = 6;
            this.repeticiones.Name = "repeticiones";
            this.repeticiones.ReadOnly = true;
            this.repeticiones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.repeticiones.Width = 112;
            // 
            // tiempo
            // 
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.tiempo.DefaultCellStyle = dataGridViewCellStyle5;
            this.tiempo.HeaderText = "Tiempo en segundos";
            this.tiempo.MinimumWidth = 6;
            this.tiempo.Name = "tiempo";
            this.tiempo.ReadOnly = true;
            this.tiempo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tiempo.Width = 153;
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar";
            this.editar.MinimumWidth = 6;
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.Width = 59;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.MinimumWidth = 6;
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eliminar.Width = 76;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscar.Location = new System.Drawing.Point(352, 22);
            this.textBoxBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(232, 29);
            this.textBoxBuscar.TabIndex = 45;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.BLimpiar.IconColor = System.Drawing.Color.White;
            this.BLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BLimpiar.IconSize = 25;
            this.BLimpiar.Location = new System.Drawing.Point(642, 19);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(47, 32);
            this.BLimpiar.TabIndex = 44;
            this.BLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);
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
            this.Bbuscar.Location = new System.Drawing.Point(593, 19);
            this.Bbuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(47, 32);
            this.Bbuscar.TabIndex = 43;
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = false;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
            // 
            // Ejercicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 342);
            this.Controls.Add(this.LnombreColumna);
            this.Controls.Add(this.LBuscar);
            this.Controls.Add(this.dataGridViewEjercicios);
            this.Controls.Add(this.Bbuscar);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.BLimpiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ejercicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EJERCICIOS";
            this.Load += new System.EventHandler(this.Ejercicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEjercicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxBuscar;
        private FontAwesome.Sharp.IconButton BLimpiar;
        private FontAwesome.Sharp.IconButton Bbuscar;
        private System.Windows.Forms.DataGridView dataGridViewEjercicios;
        private System.Windows.Forms.Label LnombreColumna;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEjercicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeticiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempo;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
    }
}