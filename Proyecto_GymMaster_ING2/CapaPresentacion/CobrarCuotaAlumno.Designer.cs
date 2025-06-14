
namespace CapaPresentacion
{
    partial class CobrarCuotaAlumno
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Membresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRecargo = new System.Windows.Forms.TextBox();
            this.BCobrarInscripcion = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxFormaPago = new System.Windows.Forms.ComboBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSubTotal = new System.Windows.Forms.TextBox();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreAlumno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Membresia,
            this.Periodo,
            this.Monto});
            this.dataGridView1.Location = new System.Drawing.Point(7, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 263);
            this.dataGridView1.TabIndex = 20;
            // 
            // Membresia
            // 
            this.Membresia.HeaderText = "Membresia";
            this.Membresia.MinimumWidth = 6;
            this.Membresia.Name = "Membresia";
            // 
            // Periodo
            // 
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.MinimumWidth = 6;
            this.Periodo.Name = "Periodo";
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.MinimumWidth = 6;
            this.Monto.Name = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(267, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "Recargo";
            // 
            // textBoxRecargo
            // 
            this.textBoxRecargo.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxRecargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRecargo.Location = new System.Drawing.Point(272, 66);
            this.textBoxRecargo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRecargo.Name = "textBoxRecargo";
            this.textBoxRecargo.ReadOnly = true;
            this.textBoxRecargo.Size = new System.Drawing.Size(169, 29);
            this.textBoxRecargo.TabIndex = 37;
            // 
            // BCobrarInscripcion
            // 
            this.BCobrarInscripcion.BackColor = System.Drawing.Color.OrangeRed;
            this.BCobrarInscripcion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCobrarInscripcion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BCobrarInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCobrarInscripcion.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCobrarInscripcion.ForeColor = System.Drawing.Color.White;
            this.BCobrarInscripcion.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.BCobrarInscripcion.IconColor = System.Drawing.Color.White;
            this.BCobrarInscripcion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BCobrarInscripcion.IconSize = 40;
            this.BCobrarInscripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCobrarInscripcion.Location = new System.Drawing.Point(813, 38);
            this.BCobrarInscripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BCobrarInscripcion.Name = "BCobrarInscripcion";
            this.BCobrarInscripcion.Size = new System.Drawing.Size(213, 55);
            this.BCobrarInscripcion.TabIndex = 51;
            this.BCobrarInscripcion.Text = "COBRAR";
            this.BCobrarInscripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCobrarInscripcion.UseVisualStyleBackColor = false;
            this.BCobrarInscripcion.Click += new System.EventHandler(this.BCobrarInscripcion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRecargo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxFormaPago);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxTotal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BCobrarInscripcion);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 399);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1035, 114);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pago";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 25);
            this.label8.TabIndex = 53;
            this.label8.Text = "FORMA DE PAGO:";
            // 
            // comboBoxFormaPago
            // 
            this.comboBoxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFormaPago.FormattingEnabled = true;
            this.comboBoxFormaPago.Location = new System.Drawing.Point(15, 66);
            this.comboBoxFormaPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxFormaPago.Name = "comboBoxFormaPago";
            this.comboBoxFormaPago.Size = new System.Drawing.Size(239, 28);
            this.comboBoxFormaPago.TabIndex = 52;
            this.comboBoxFormaPago.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormaPago_SelectedIndexChanged);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.Color.White;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTotal.Location = new System.Drawing.Point(633, 64);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(171, 29);
            this.textBoxTotal.TabIndex = 48;
            this.textBoxTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(628, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "TOTAL:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(725, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "SUBTOTAL:";
            // 
            // textBoxSubTotal
            // 
            this.textBoxSubTotal.BackColor = System.Drawing.Color.White;
            this.textBoxSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubTotal.Location = new System.Drawing.Point(853, 294);
            this.textBoxSubTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSubTotal.Name = "textBoxSubTotal";
            this.textBoxSubTotal.ReadOnly = true;
            this.textBoxSubTotal.Size = new System.Drawing.Size(172, 29);
            this.textBoxSubTotal.TabIndex = 40;
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.BackColor = System.Drawing.Color.White;
            this.textBoxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFecha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxFecha.Location = new System.Drawing.Point(887, 17);
            this.textBoxFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.ReadOnly = true;
            this.textBoxFecha.Size = new System.Drawing.Size(163, 26);
            this.textBoxFecha.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(819, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 25);
            this.label9.TabIndex = 39;
            this.label9.Text = "Fecha:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.textBoxSubTotal);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 54);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1035, 337);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Alumno:";
            // 
            // NombreAlumno
            // 
            this.NombreAlumno.AutoSize = true;
            this.NombreAlumno.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreAlumno.ForeColor = System.Drawing.Color.Black;
            this.NombreAlumno.Location = new System.Drawing.Point(103, 17);
            this.NombreAlumno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NombreAlumno.Name = "NombreAlumno";
            this.NombreAlumno.Size = new System.Drawing.Size(213, 24);
            this.NombreAlumno.TabIndex = 65;
            this.NombreAlumno.Text = "Nombre completo - DNI";
            // 
            // CobrarCuotaAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1067, 524);
            this.Controls.Add(this.NombreAlumno);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CobrarCuotaAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REALIZAR PAGO";
            this.Load += new System.EventHandler(this.CobrarNuevoAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRecargo;
        private FontAwesome.Sharp.IconButton BCobrarInscripcion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSubTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxFormaPago;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NombreAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Membresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}