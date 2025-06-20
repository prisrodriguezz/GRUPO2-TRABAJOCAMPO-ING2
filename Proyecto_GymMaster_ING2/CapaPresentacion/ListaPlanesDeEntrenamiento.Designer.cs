
namespace CapaPresentacion
{
    partial class ListaPlanesDeEntrenamiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelCantPlanes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTITULO = new System.Windows.Forms.Label();
            this.BLimpiar = new FontAwesome.Sharp.IconButton();
            this.Bbuscar = new FontAwesome.Sharp.IconButton();
            this.dgvdataListaPlanes = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detallesPlan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LnombreColumna = new System.Windows.Forms.Label();
            this.textBoxBusqueda = new System.Windows.Forms.TextBox();
            this.LBuscar = new System.Windows.Forms.Label();
            this.BNuevoPlan = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdataListaPlanes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCantPlanes
            // 
            this.labelCantPlanes.AutoSize = true;
            this.labelCantPlanes.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantPlanes.ForeColor = System.Drawing.Color.Black;
            this.labelCantPlanes.Location = new System.Drawing.Point(205, 555);
            this.labelCantPlanes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCantPlanes.Name = "labelCantPlanes";
            this.labelCantPlanes.Size = new System.Drawing.Size(80, 24);
            this.labelCantPlanes.TabIndex = 46;
            this.labelCantPlanes.Text = "0 planes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 555);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 25);
            this.label3.TabIndex = 45;
            this.label3.Text = "Cantidad de planes:";
            // 
            // labelTITULO
            // 
            this.labelTITULO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTITULO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTITULO.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTITULO.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelTITULO.Location = new System.Drawing.Point(16, 6);
            this.labelTITULO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTITULO.Name = "labelTITULO";
            this.labelTITULO.Size = new System.Drawing.Size(1154, 49);
            this.labelTITULO.TabIndex = 39;
            this.labelTITULO.Text = "LISTA DE PLANES";
            this.labelTITULO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.BLimpiar.Location = new System.Drawing.Point(1109, 16);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(47, 30);
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
            this.Bbuscar.Location = new System.Drawing.Point(1041, 16);
            this.Bbuscar.Margin = new System.Windows.Forms.Padding(4);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(47, 30);
            this.Bbuscar.TabIndex = 43;
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = false;
            this.Bbuscar.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dgvdataListaPlanes
            // 
            this.dgvdataListaPlanes.AllowUserToAddRows = false;
            this.dgvdataListaPlanes.AllowUserToDeleteRows = false;
            this.dgvdataListaPlanes.AllowUserToResizeColumns = false;
            this.dgvdataListaPlanes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdataListaPlanes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdataListaPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdataListaPlanes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdataListaPlanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdataListaPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdataListaPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.eliminar,
            this.idPlan,
            this.Nombre,
            this.fechaInicio,
            this.fechaFin,
            this.series,
            this.detallesPlan,
            this.Estado});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdataListaPlanes.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvdataListaPlanes.Location = new System.Drawing.Point(16, 63);
            this.dgvdataListaPlanes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvdataListaPlanes.MultiSelect = false;
            this.dgvdataListaPlanes.Name = "dgvdataListaPlanes";
            this.dgvdataListaPlanes.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdataListaPlanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvdataListaPlanes.RowHeadersWidth = 30;
            this.dgvdataListaPlanes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvdataListaPlanes.RowTemplate.Height = 30;
            this.dgvdataListaPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdataListaPlanes.Size = new System.Drawing.Size(1155, 485);
            this.dgvdataListaPlanes.TabIndex = 47;
            this.dgvdataListaPlanes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdataListaPlanes_CellContentClick);
            this.dgvdataListaPlanes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdataListaPlanes_ColumnHeaderMouseClick);
            // 
            // Editar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle3;
            this.Editar.HeaderText = "";
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // eliminar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.eliminar.DefaultCellStyle = dataGridViewCellStyle4;
            this.eliminar.HeaderText = "";
            this.eliminar.MinimumWidth = 6;
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            // 
            // idPlan
            // 
            this.idPlan.HeaderText = "Idplan";
            this.idPlan.MinimumWidth = 6;
            this.idPlan.Name = "idPlan";
            this.idPlan.ReadOnly = true;
            this.idPlan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idPlan.Visible = false;
            // 
            // Nombre
            // 
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle5;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fechaInicio
            // 
            this.fechaInicio.HeaderText = "Fecha Inicio";
            this.fechaInicio.MinimumWidth = 6;
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fechaFin
            // 
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.fechaFin.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaFin.HeaderText = "Fecha Fin";
            this.fechaFin.MinimumWidth = 6;
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.ReadOnly = true;
            this.fechaFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // series
            // 
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.series.DefaultCellStyle = dataGridViewCellStyle7;
            this.series.HeaderText = "Series";
            this.series.MinimumWidth = 6;
            this.series.Name = "series";
            this.series.ReadOnly = true;
            this.series.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // detallesPlan
            // 
            this.detallesPlan.HeaderText = "Ejercicios / Coach";
            this.detallesPlan.MinimumWidth = 6;
            this.detallesPlan.Name = "detallesPlan";
            this.detallesPlan.ReadOnly = true;
            this.detallesPlan.Text = "";
            // 
            // Estado
            // 
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.Estado.DefaultCellStyle = dataGridViewCellStyle8;
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LnombreColumna
            // 
            this.LnombreColumna.AutoSize = true;
            this.LnombreColumna.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LnombreColumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnombreColumna.ForeColor = System.Drawing.Color.Red;
            this.LnombreColumna.Location = new System.Drawing.Point(633, 23);
            this.LnombreColumna.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LnombreColumna.Name = "LnombreColumna";
            this.LnombreColumna.Size = new System.Drawing.Size(123, 20);
            this.LnombreColumna.TabIndex = 50;
            this.LnombreColumna.Text = "Nombre campo";
            this.LnombreColumna.Visible = false;
            // 
            // textBoxBusqueda
            // 
            this.textBoxBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBusqueda.Location = new System.Drawing.Point(793, 17);
            this.textBoxBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBusqueda.Name = "textBoxBusqueda";
            this.textBoxBusqueda.Size = new System.Drawing.Size(239, 29);
            this.textBoxBusqueda.TabIndex = 48;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscar.Location = new System.Drawing.Point(535, 23);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(97, 20);
            this.LBuscar.TabIndex = 49;
            this.LBuscar.Text = "Buscar por:";
            this.LBuscar.Visible = false;
            // 
            // BNuevoPlan
            // 
            this.BNuevoPlan.BackColor = System.Drawing.Color.Green;
            this.BNuevoPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoPlan.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BNuevoPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevoPlan.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoPlan.ForeColor = System.Drawing.Color.White;
            this.BNuevoPlan.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.BNuevoPlan.IconColor = System.Drawing.Color.White;
            this.BNuevoPlan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BNuevoPlan.IconSize = 30;
            this.BNuevoPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevoPlan.Location = new System.Drawing.Point(907, 555);
            this.BNuevoPlan.Margin = new System.Windows.Forms.Padding(4);
            this.BNuevoPlan.Name = "BNuevoPlan";
            this.BNuevoPlan.Size = new System.Drawing.Size(264, 55);
            this.BNuevoPlan.TabIndex = 51;
            this.BNuevoPlan.Text = "AGREGAR NUEVO PLAN";
            this.BNuevoPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BNuevoPlan.UseVisualStyleBackColor = false;
            this.BNuevoPlan.Click += new System.EventHandler(this.BNuevoPlan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxFecha);
            this.groupBox1.Location = new System.Drawing.Point(387, 556);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(385, 55);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "PLAN VIGENTE";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(215, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(29, 26);
            this.textBox1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "PLAN VENCIDO";
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.BackColor = System.Drawing.Color.MistyRose;
            this.textBoxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFecha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxFecha.Location = new System.Drawing.Point(8, 17);
            this.textBoxFecha.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.ReadOnly = true;
            this.textBoxFecha.Size = new System.Drawing.Size(29, 26);
            this.textBoxFecha.TabIndex = 64;
            // 
            // ListaPlanesDeEntrenamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BNuevoPlan);
            this.Controls.Add(this.LnombreColumna);
            this.Controls.Add(this.textBoxBusqueda);
            this.Controls.Add(this.LBuscar);
            this.Controls.Add(this.labelCantPlanes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.Bbuscar);
            this.Controls.Add(this.labelTITULO);
            this.Controls.Add(this.dgvdataListaPlanes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaPlanesDeEntrenamiento";
            this.Text = "ListaPlanesDeEntrenamiento";
            this.Load += new System.EventHandler(this.ListaPlanesDeEntrenamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdataListaPlanes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCantPlanes;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton BLimpiar;
        private FontAwesome.Sharp.IconButton Bbuscar;
        private System.Windows.Forms.Label labelTITULO;
        private System.Windows.Forms.DataGridView dgvdataListaPlanes;
        private System.Windows.Forms.Label LnombreColumna;
        private System.Windows.Forms.TextBox textBoxBusqueda;
        private System.Windows.Forms.Label LBuscar;
        private FontAwesome.Sharp.IconButton BNuevoPlan;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn series;
        private System.Windows.Forms.DataGridViewButtonColumn detallesPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFecha;
    }
}