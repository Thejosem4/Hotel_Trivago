namespace CapaPresentacion
{
    partial class FBusquedaCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaCargo));
            this.tbCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet6 = new CapaPresentacion.DBTrivagoDataSet6();
            this.tbCargoTableAdapter = new CapaPresentacion.DBTrivagoDataSet6TableAdapters.TbCargoTableAdapter();
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idcargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcioncargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadocargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dBTrivagoDataSet12 = new CapaPresentacion.DBTrivagoDataSet12();
            this.tbInventarioSuministroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbInventario_SuministroTableAdapter = new CapaPresentacion.DBTrivagoDataSet12TableAdapters.TbInventario_SuministroTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbCargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInventarioSuministroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCargoBindingSource
            // 
            this.tbCargoBindingSource.DataMember = "TbCargo";
            this.tbCargoBindingSource.DataSource = this.dBTrivagoDataSet6;
            // 
            // dBTrivagoDataSet6
            // 
            this.dBTrivagoDataSet6.DataSetName = "DBTrivagoDataSet6";
            this.dBTrivagoDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbCargoTableAdapter
            // 
            this.tbCargoTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(397, 376);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 319;
            this.label5.Text = "Aceptar";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::CapaPresentacion.Properties.Resources.aceptar;
            this.button5.Location = new System.Drawing.Point(399, 328);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 46);
            this.button5.TabIndex = 318;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::CapaPresentacion.Properties.Resources.ultimo;
            this.button4.Location = new System.Drawing.Point(344, 328);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 46);
            this.button4.TabIndex = 317;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Image = global::CapaPresentacion.Properties.Resources.siguiente;
            this.button6.Location = new System.Drawing.Point(285, 328);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 46);
            this.button6.TabIndex = 316;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button7.Location = new System.Drawing.Point(225, 328);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(46, 46);
            this.button7.TabIndex = 315;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button8.Location = new System.Drawing.Point(165, 328);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 46);
            this.button8.TabIndex = 314;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(347, 376);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 313;
            this.label4.Text = "Ultimo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 376);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 312;
            this.label3.Text = "Siguiente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 376);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Anterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 376);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 310;
            this.label1.Text = "Primero";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(565, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 41);
            this.button2.TabIndex = 325;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(500, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 41);
            this.button1.TabIndex = 324;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::CapaPresentacion.Properties.Resources._2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(434, 25);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 41);
            this.button3.TabIndex = 323;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(10, 6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 322;
            this.pictureBox10.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox7.Location = new System.Drawing.Point(118, 43);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(294, 23);
            this.textBox7.TabIndex = 321;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(204, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 25);
            this.label6.TabIndex = 320;
            this.label6.Text = "Buscar Cargo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcargoDataGridViewTextBoxColumn,
            this.nombrecargoDataGridViewTextBoxColumn,
            this.descripcioncargoDataGridViewTextBoxColumn,
            this.estadocargoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbCargoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(118, 127);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(413, 196);
            this.dataGridView1.TabIndex = 326;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // idcargoDataGridViewTextBoxColumn
            // 
            this.idcargoDataGridViewTextBoxColumn.DataPropertyName = "id_cargo";
            this.idcargoDataGridViewTextBoxColumn.HeaderText = "id_cargo";
            this.idcargoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idcargoDataGridViewTextBoxColumn.Name = "idcargoDataGridViewTextBoxColumn";
            this.idcargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcargoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombrecargoDataGridViewTextBoxColumn
            // 
            this.nombrecargoDataGridViewTextBoxColumn.DataPropertyName = "nombre_cargo";
            this.nombrecargoDataGridViewTextBoxColumn.HeaderText = "nombre_cargo";
            this.nombrecargoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombrecargoDataGridViewTextBoxColumn.Name = "nombrecargoDataGridViewTextBoxColumn";
            this.nombrecargoDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcioncargoDataGridViewTextBoxColumn
            // 
            this.descripcioncargoDataGridViewTextBoxColumn.DataPropertyName = "descripcion_cargo";
            this.descripcioncargoDataGridViewTextBoxColumn.HeaderText = "descripcion_cargo";
            this.descripcioncargoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcioncargoDataGridViewTextBoxColumn.Name = "descripcioncargoDataGridViewTextBoxColumn";
            this.descripcioncargoDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadocargoDataGridViewTextBoxColumn
            // 
            this.estadocargoDataGridViewTextBoxColumn.DataPropertyName = "estado_cargo";
            this.estadocargoDataGridViewTextBoxColumn.HeaderText = "estado_cargo";
            this.estadocargoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.estadocargoDataGridViewTextBoxColumn.Name = "estadocargoDataGridViewTextBoxColumn";
            this.estadocargoDataGridViewTextBoxColumn.Width = 125;
            // 
            // dBTrivagoDataSet12
            // 
            this.dBTrivagoDataSet12.DataSetName = "DBTrivagoDataSet12";
            this.dBTrivagoDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbInventarioSuministroBindingSource
            // 
            this.tbInventarioSuministroBindingSource.DataMember = "TbInventario_Suministro";
            this.tbInventarioSuministroBindingSource.DataSource = this.dBTrivagoDataSet12;
            // 
            // tbInventario_SuministroTableAdapter
            // 
            this.tbInventario_SuministroTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(449, 376);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 328;
            this.label7.Text = "Limpiar";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.BackgroundImage = global::CapaPresentacion.Properties.Resources.escoba;
            this.btn_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Limpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.Location = new System.Drawing.Point(451, 328);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 327;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(640, 404);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FBusquedaCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaCargo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaCargo_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbCargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInventarioSuministroBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DBTrivagoDataSet6 dBTrivagoDataSet6;
        private System.Windows.Forms.BindingSource tbCargoBindingSource;
        private DBTrivagoDataSet6TableAdapters.TbCargoTableAdapter tbCargoTableAdapter;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBTrivagoDataSet12 dBTrivagoDataSet12;
        private System.Windows.Forms.BindingSource tbInventarioSuministroBindingSource;
        private DBTrivagoDataSet12TableAdapters.TbInventario_SuministroTableAdapter tbInventario_SuministroTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcioncargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadocargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}