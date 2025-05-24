namespace CapaPresentacion
{
    partial class FBusquedaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaEmpresa));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rncDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sloganDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gerenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet4 = new CapaPresentacion.DBTrivagoDataSet4();
            this.tbEmpresaTableAdapter = new CapaPresentacion.DBTrivagoDataSet4TableAdapters.TbEmpresaTableAdapter();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idempresaDataGridViewTextBoxColumn,
            this.nombreempresaDataGridViewTextBoxColumn,
            this.correoempresaDataGridViewTextBoxColumn,
            this.rncDataGridViewTextBoxColumn,
            this.direccionempresaDataGridViewTextBoxColumn,
            this.telefonoempresaDataGridViewTextBoxColumn,
            this.sloganDataGridViewTextBoxColumn,
            this.gerenteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbEmpresaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(86, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(506, 221);
            this.dataGridView1.TabIndex = 186;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // idempresaDataGridViewTextBoxColumn
            // 
            this.idempresaDataGridViewTextBoxColumn.DataPropertyName = "id_empresa";
            this.idempresaDataGridViewTextBoxColumn.HeaderText = "id_empresa";
            this.idempresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idempresaDataGridViewTextBoxColumn.Name = "idempresaDataGridViewTextBoxColumn";
            this.idempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idempresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreempresaDataGridViewTextBoxColumn
            // 
            this.nombreempresaDataGridViewTextBoxColumn.DataPropertyName = "nombre_empresa";
            this.nombreempresaDataGridViewTextBoxColumn.HeaderText = "nombre_empresa";
            this.nombreempresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreempresaDataGridViewTextBoxColumn.Name = "nombreempresaDataGridViewTextBoxColumn";
            this.nombreempresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // correoempresaDataGridViewTextBoxColumn
            // 
            this.correoempresaDataGridViewTextBoxColumn.DataPropertyName = "correo_empresa";
            this.correoempresaDataGridViewTextBoxColumn.HeaderText = "correo_empresa";
            this.correoempresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.correoempresaDataGridViewTextBoxColumn.Name = "correoempresaDataGridViewTextBoxColumn";
            this.correoempresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // rncDataGridViewTextBoxColumn
            // 
            this.rncDataGridViewTextBoxColumn.DataPropertyName = "rnc";
            this.rncDataGridViewTextBoxColumn.HeaderText = "rnc";
            this.rncDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.rncDataGridViewTextBoxColumn.Name = "rncDataGridViewTextBoxColumn";
            this.rncDataGridViewTextBoxColumn.Width = 150;
            // 
            // direccionempresaDataGridViewTextBoxColumn
            // 
            this.direccionempresaDataGridViewTextBoxColumn.DataPropertyName = "direccion_empresa";
            this.direccionempresaDataGridViewTextBoxColumn.HeaderText = "direccion_empresa";
            this.direccionempresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.direccionempresaDataGridViewTextBoxColumn.Name = "direccionempresaDataGridViewTextBoxColumn";
            this.direccionempresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefonoempresaDataGridViewTextBoxColumn
            // 
            this.telefonoempresaDataGridViewTextBoxColumn.DataPropertyName = "telefono_empresa";
            this.telefonoempresaDataGridViewTextBoxColumn.HeaderText = "telefono_empresa";
            this.telefonoempresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.telefonoempresaDataGridViewTextBoxColumn.Name = "telefonoempresaDataGridViewTextBoxColumn";
            this.telefonoempresaDataGridViewTextBoxColumn.Width = 150;
            // 
            // sloganDataGridViewTextBoxColumn
            // 
            this.sloganDataGridViewTextBoxColumn.DataPropertyName = "slogan";
            this.sloganDataGridViewTextBoxColumn.HeaderText = "slogan";
            this.sloganDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sloganDataGridViewTextBoxColumn.Name = "sloganDataGridViewTextBoxColumn";
            this.sloganDataGridViewTextBoxColumn.Width = 150;
            // 
            // gerenteDataGridViewTextBoxColumn
            // 
            this.gerenteDataGridViewTextBoxColumn.DataPropertyName = "gerente";
            this.gerenteDataGridViewTextBoxColumn.HeaderText = "gerente";
            this.gerenteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.gerenteDataGridViewTextBoxColumn.Name = "gerenteDataGridViewTextBoxColumn";
            this.gerenteDataGridViewTextBoxColumn.Width = 150;
            // 
            // tbEmpresaBindingSource
            // 
            this.tbEmpresaBindingSource.DataMember = "TbEmpresa";
            this.tbEmpresaBindingSource.DataSource = this.dBTrivagoDataSet4;
            // 
            // dBTrivagoDataSet4
            // 
            this.dBTrivagoDataSet4.DataSetName = "DBTrivagoDataSet4";
            this.dBTrivagoDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbEmpresaTableAdapter
            // 
            this.tbEmpresaTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(895, 533);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(63, 52);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 192;
            this.pictureBox7.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(416, 389);
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
            this.button5.Location = new System.Drawing.Point(415, 341);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 46);
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
            this.button4.Location = new System.Drawing.Point(361, 341);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 46);
            this.button4.TabIndex = 307;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::CapaPresentacion.Properties.Resources.siguiente;
            this.button3.Location = new System.Drawing.Point(302, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 46);
            this.button3.TabIndex = 306;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button2.Location = new System.Drawing.Point(241, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 46);
            this.button2.TabIndex = 305;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button1.Location = new System.Drawing.Point(182, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 46);
            this.button1.TabIndex = 304;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 389);
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
            this.label3.Location = new System.Drawing.Point(299, 389);
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
            this.label2.Location = new System.Drawing.Point(240, 389);
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
            this.label1.Location = new System.Drawing.Point(180, 389);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 300;
            this.label1.Text = "Primero";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(588, 41);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(49, 41);
            this.button8.TabIndex = 312;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(523, 41);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 41);
            this.button7.TabIndex = 311;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::CapaPresentacion.Properties.Resources._2;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(458, 41);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 41);
            this.button6.TabIndex = 310;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(219, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 25);
            this.label7.TabIndex = 313;
            this.label7.Text = "Buscar Empresa";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox1.Location = new System.Drawing.Point(146, 50);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 23);
            this.textBox1.TabIndex = 314;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(24, 12);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 315;
            this.pictureBox10.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(469, 389);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 330;
            this.label6.Text = "Limpiar";
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.BackgroundImage = global::CapaPresentacion.Properties.Resources.escoba;
            this.btn_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Limpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.Location = new System.Drawing.Point(471, 341);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 329;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(662, 409);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FBusquedaEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaEmpresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaEmpresa_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBTrivagoDataSet4 dBTrivagoDataSet4;
        private System.Windows.Forms.BindingSource tbEmpresaBindingSource;
        private DBTrivagoDataSet4TableAdapters.TbEmpresaTableAdapter tbEmpresaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rncDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sloganDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gerenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}