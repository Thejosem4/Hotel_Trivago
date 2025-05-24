namespace CapaPresentacion
{
    partial class FBusquedaCliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaCliente));
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet11 = new CapaPresentacion.DBTrivagoDataSet11();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbClienteTableAdapter = new CapaPresentacion.DBTrivagoDataSet11TableAdapters.TbClienteTableAdapter();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(16, 11);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 243;
            this.pictureBox10.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idclienteDataGridViewTextBoxColumn,
            this.nombreclienteDataGridViewTextBoxColumn,
            this.apellidoclienteDataGridViewTextBoxColumn,
            this.telefonoclienteDataGridViewTextBoxColumn,
            this.emailclienteDataGridViewTextBoxColumn,
            this.direccionclienteDataGridViewTextBoxColumn,
            this.cedulaclienteDataGridViewTextBoxColumn,
            this.fecharegistroDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbClienteBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 105);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(604, 202);
            this.dataGridView1.TabIndex = 237;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // idclienteDataGridViewTextBoxColumn
            // 
            this.idclienteDataGridViewTextBoxColumn.DataPropertyName = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.HeaderText = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idclienteDataGridViewTextBoxColumn.Name = "idclienteDataGridViewTextBoxColumn";
            this.idclienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreclienteDataGridViewTextBoxColumn
            // 
            this.nombreclienteDataGridViewTextBoxColumn.DataPropertyName = "nombre_cliente";
            this.nombreclienteDataGridViewTextBoxColumn.HeaderText = "nombre_cliente";
            this.nombreclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreclienteDataGridViewTextBoxColumn.Name = "nombreclienteDataGridViewTextBoxColumn";
            this.nombreclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // apellidoclienteDataGridViewTextBoxColumn
            // 
            this.apellidoclienteDataGridViewTextBoxColumn.DataPropertyName = "apellido_cliente";
            this.apellidoclienteDataGridViewTextBoxColumn.HeaderText = "apellido_cliente";
            this.apellidoclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.apellidoclienteDataGridViewTextBoxColumn.Name = "apellidoclienteDataGridViewTextBoxColumn";
            this.apellidoclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefonoclienteDataGridViewTextBoxColumn
            // 
            this.telefonoclienteDataGridViewTextBoxColumn.DataPropertyName = "telefono_cliente";
            this.telefonoclienteDataGridViewTextBoxColumn.HeaderText = "telefono_cliente";
            this.telefonoclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.telefonoclienteDataGridViewTextBoxColumn.Name = "telefonoclienteDataGridViewTextBoxColumn";
            this.telefonoclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // emailclienteDataGridViewTextBoxColumn
            // 
            this.emailclienteDataGridViewTextBoxColumn.DataPropertyName = "email_cliente";
            this.emailclienteDataGridViewTextBoxColumn.HeaderText = "email_cliente";
            this.emailclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.emailclienteDataGridViewTextBoxColumn.Name = "emailclienteDataGridViewTextBoxColumn";
            this.emailclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // direccionclienteDataGridViewTextBoxColumn
            // 
            this.direccionclienteDataGridViewTextBoxColumn.DataPropertyName = "direccion_cliente";
            this.direccionclienteDataGridViewTextBoxColumn.HeaderText = "direccion_cliente";
            this.direccionclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.direccionclienteDataGridViewTextBoxColumn.Name = "direccionclienteDataGridViewTextBoxColumn";
            this.direccionclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // cedulaclienteDataGridViewTextBoxColumn
            // 
            this.cedulaclienteDataGridViewTextBoxColumn.DataPropertyName = "cedula_cliente";
            this.cedulaclienteDataGridViewTextBoxColumn.HeaderText = "cedula_cliente";
            this.cedulaclienteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cedulaclienteDataGridViewTextBoxColumn.Name = "cedulaclienteDataGridViewTextBoxColumn";
            this.cedulaclienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // fecharegistroDataGridViewTextBoxColumn
            // 
            this.fecharegistroDataGridViewTextBoxColumn.DataPropertyName = "fecha_registro";
            this.fecharegistroDataGridViewTextBoxColumn.HeaderText = "fecha_registro";
            this.fecharegistroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fecharegistroDataGridViewTextBoxColumn.Name = "fecharegistroDataGridViewTextBoxColumn";
            this.fecharegistroDataGridViewTextBoxColumn.Width = 150;
            // 
            // tbClienteBindingSource
            // 
            this.tbClienteBindingSource.DataMember = "TbCliente";
            this.tbClienteBindingSource.DataSource = this.dBTrivagoDataSet11;
            // 
            // dBTrivagoDataSet11
            // 
            this.dBTrivagoDataSet11.DataSetName = "DBTrivagoDataSet11";
            this.dBTrivagoDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox7.Location = new System.Drawing.Point(124, 48);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(294, 23);
            this.textBox7.TabIndex = 236;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 235;
            this.label6.Text = "Buscar Cliente";
            // 
            // tbClienteTableAdapter
            // 
            this.tbClienteTableAdapter.ClearBeforeFill = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::CapaPresentacion.Properties.Resources._2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(440, 30);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 41);
            this.button3.TabIndex = 244;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(506, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 41);
            this.button1.TabIndex = 245;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(571, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 41);
            this.button2.TabIndex = 246;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(387, 370);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 309;
            this.label5.Text = "Aceptar";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::CapaPresentacion.Properties.Resources.aceptar;
            this.button5.Location = new System.Drawing.Point(389, 322);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 46);
            this.button5.TabIndex = 308;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::CapaPresentacion.Properties.Resources.ultimo;
            this.button4.Location = new System.Drawing.Point(334, 322);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 46);
            this.button4.TabIndex = 307;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Image = global::CapaPresentacion.Properties.Resources.siguiente;
            this.button6.Location = new System.Drawing.Point(275, 322);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 46);
            this.button6.TabIndex = 306;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button7.Location = new System.Drawing.Point(215, 322);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(46, 46);
            this.button7.TabIndex = 305;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button8.Location = new System.Drawing.Point(155, 322);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 46);
            this.button8.TabIndex = 304;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(337, 370);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 303;
            this.label4.Text = "Ultimo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 370);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Siguiente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 370);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "Anterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 370);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Primero";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(439, 370);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 330;
            this.label7.Text = "Limpiar";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.BackgroundImage = global::CapaPresentacion.Properties.Resources.escoba;
            this.btn_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Limpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.Location = new System.Drawing.Point(441, 322);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 329;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(640, 392);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FBusquedaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaCliente_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private DBTrivagoDataSet11 dBTrivagoDataSet11;
        private System.Windows.Forms.BindingSource tbClienteBindingSource;
        private DBTrivagoDataSet11TableAdapters.TbClienteTableAdapter tbClienteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}