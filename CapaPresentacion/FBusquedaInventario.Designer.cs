namespace CapaPresentacion
{
    partial class FBusquedaInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaInventario));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idsuministroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombresuministroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionsuministroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadsuministroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadosuministroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet8 = new CapaPresentacion.DBTrivagoDataSet8();
            this.tbInventarioTableAdapter = new CapaPresentacion.DBTrivagoDataSet8TableAdapters.TbInventarioTableAdapter();
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
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idsuministroDataGridViewTextBoxColumn,
            this.nombresuministroDataGridViewTextBoxColumn,
            this.descripcionsuministroDataGridViewTextBoxColumn,
            this.cantidadsuministroDataGridViewTextBoxColumn,
            this.estadosuministroDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbInventarioBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 105);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(624, 201);
            this.dataGridView1.TabIndex = 221;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // idsuministroDataGridViewTextBoxColumn
            // 
            this.idsuministroDataGridViewTextBoxColumn.DataPropertyName = "id_suministro";
            this.idsuministroDataGridViewTextBoxColumn.HeaderText = "id_suministro";
            this.idsuministroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idsuministroDataGridViewTextBoxColumn.Name = "idsuministroDataGridViewTextBoxColumn";
            this.idsuministroDataGridViewTextBoxColumn.ReadOnly = true;
            this.idsuministroDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombresuministroDataGridViewTextBoxColumn
            // 
            this.nombresuministroDataGridViewTextBoxColumn.DataPropertyName = "nombre_suministro";
            this.nombresuministroDataGridViewTextBoxColumn.HeaderText = "nombre_suministro";
            this.nombresuministroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombresuministroDataGridViewTextBoxColumn.Name = "nombresuministroDataGridViewTextBoxColumn";
            this.nombresuministroDataGridViewTextBoxColumn.Width = 150;
            // 
            // descripcionsuministroDataGridViewTextBoxColumn
            // 
            this.descripcionsuministroDataGridViewTextBoxColumn.DataPropertyName = "descripcion_suministro";
            this.descripcionsuministroDataGridViewTextBoxColumn.HeaderText = "descripcion_suministro";
            this.descripcionsuministroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descripcionsuministroDataGridViewTextBoxColumn.Name = "descripcionsuministroDataGridViewTextBoxColumn";
            this.descripcionsuministroDataGridViewTextBoxColumn.Width = 150;
            // 
            // cantidadsuministroDataGridViewTextBoxColumn
            // 
            this.cantidadsuministroDataGridViewTextBoxColumn.DataPropertyName = "cantidad_suministro";
            this.cantidadsuministroDataGridViewTextBoxColumn.HeaderText = "cantidad_suministro";
            this.cantidadsuministroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cantidadsuministroDataGridViewTextBoxColumn.Name = "cantidadsuministroDataGridViewTextBoxColumn";
            this.cantidadsuministroDataGridViewTextBoxColumn.Width = 150;
            // 
            // estadosuministroDataGridViewTextBoxColumn
            // 
            this.estadosuministroDataGridViewTextBoxColumn.DataPropertyName = "estado_suministro";
            this.estadosuministroDataGridViewTextBoxColumn.HeaderText = "estado_suministro";
            this.estadosuministroDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.estadosuministroDataGridViewTextBoxColumn.Name = "estadosuministroDataGridViewTextBoxColumn";
            this.estadosuministroDataGridViewTextBoxColumn.Width = 150;
            // 
            // tbInventarioBindingSource
            // 
            this.tbInventarioBindingSource.DataMember = "TbInventario";
            this.tbInventarioBindingSource.DataSource = this.dBTrivagoDataSet8;
            // 
            // dBTrivagoDataSet8
            // 
            this.dBTrivagoDataSet8.DataSetName = "DBTrivagoDataSet8";
            this.dBTrivagoDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbInventarioTableAdapter
            // 
            this.tbInventarioTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(393, 374);
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
            this.button5.Location = new System.Drawing.Point(395, 326);
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
            this.button4.Location = new System.Drawing.Point(340, 326);
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
            this.button6.Location = new System.Drawing.Point(281, 326);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 46);
            this.button6.TabIndex = 316;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button7.Location = new System.Drawing.Point(221, 326);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(46, 46);
            this.button7.TabIndex = 315;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button8.Location = new System.Drawing.Point(161, 326);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(46, 46);
            this.button8.TabIndex = 314;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 374);
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
            this.label3.Location = new System.Drawing.Point(270, 374);
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
            this.label2.Location = new System.Drawing.Point(217, 374);
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
            this.label1.Location = new System.Drawing.Point(158, 374);
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
            this.button2.Location = new System.Drawing.Point(570, 33);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 41);
            this.button2.TabIndex = 325;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(505, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.button3.Location = new System.Drawing.Point(439, 33);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 41);
            this.button3.TabIndex = 323;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(15, 14);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 322;
            this.pictureBox10.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox7.Location = new System.Drawing.Point(123, 51);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(294, 23);
            this.textBox7.TabIndex = 321;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(189, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 25);
            this.label6.TabIndex = 320;
            this.label6.Text = "Buscar Inventario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(445, 374);
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
            this.btn_Limpiar.Location = new System.Drawing.Point(447, 326);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 329;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(641, 404);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_Limpiar);
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
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FBusquedaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaInventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaInventario_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBTrivagoDataSet8 dBTrivagoDataSet8;
        private System.Windows.Forms.BindingSource tbInventarioBindingSource;
        private DBTrivagoDataSet8TableAdapters.TbInventarioTableAdapter tbInventarioTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsuministroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombresuministroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionsuministroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadsuministroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadosuministroDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}