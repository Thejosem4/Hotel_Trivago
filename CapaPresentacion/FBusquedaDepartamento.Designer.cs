namespace CapaPresentacion
{
    partial class FBusquedaDepartamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaDepartamento));
            this.label7 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iddepartamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombredepartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripciondepartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadodepartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDepartamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet14 = new CapaPresentacion.DBTrivagoDataSet14();
            this.tbDepartamentoTableAdapter = new CapaPresentacion.DBTrivagoDataSet14TableAdapters.TbDepartamentoTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDepartamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet14)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 25);
            this.label7.TabIndex = 316;
            this.label7.Text = "Buscar Departamento ";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(565, 25);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 41);
            this.button6.TabIndex = 330;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(500, 25);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 41);
            this.button7.TabIndex = 329;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::CapaPresentacion.Properties.Resources._2;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(434, 25);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(49, 41);
            this.button8.TabIndex = 328;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(10, 6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 327;
            this.pictureBox10.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox7.Location = new System.Drawing.Point(118, 43);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(294, 23);
            this.textBox7.TabIndex = 326;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddepartamentoDataGridViewTextBoxColumn,
            this.nombredepartDataGridViewTextBoxColumn,
            this.descripciondepartDataGridViewTextBoxColumn,
            this.fechacreacionDataGridViewTextBoxColumn,
            this.estadodepartDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbDepartamentoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(73, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(509, 196);
            this.dataGridView1.TabIndex = 331;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // iddepartamentoDataGridViewTextBoxColumn
            // 
            this.iddepartamentoDataGridViewTextBoxColumn.DataPropertyName = "id_departamento";
            this.iddepartamentoDataGridViewTextBoxColumn.HeaderText = "id_departamento";
            this.iddepartamentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iddepartamentoDataGridViewTextBoxColumn.Name = "iddepartamentoDataGridViewTextBoxColumn";
            this.iddepartamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddepartamentoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombredepartDataGridViewTextBoxColumn
            // 
            this.nombredepartDataGridViewTextBoxColumn.DataPropertyName = "nombre_depart";
            this.nombredepartDataGridViewTextBoxColumn.HeaderText = "nombre_depart";
            this.nombredepartDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombredepartDataGridViewTextBoxColumn.Name = "nombredepartDataGridViewTextBoxColumn";
            this.nombredepartDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripciondepartDataGridViewTextBoxColumn
            // 
            this.descripciondepartDataGridViewTextBoxColumn.DataPropertyName = "descripcion_depart";
            this.descripciondepartDataGridViewTextBoxColumn.HeaderText = "descripcion_depart";
            this.descripciondepartDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripciondepartDataGridViewTextBoxColumn.Name = "descripciondepartDataGridViewTextBoxColumn";
            this.descripciondepartDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechacreacionDataGridViewTextBoxColumn
            // 
            this.fechacreacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_creacion";
            this.fechacreacionDataGridViewTextBoxColumn.HeaderText = "fecha_creacion";
            this.fechacreacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechacreacionDataGridViewTextBoxColumn.Name = "fechacreacionDataGridViewTextBoxColumn";
            this.fechacreacionDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadodepartDataGridViewTextBoxColumn
            // 
            this.estadodepartDataGridViewTextBoxColumn.DataPropertyName = "estado_depart";
            this.estadodepartDataGridViewTextBoxColumn.HeaderText = "estado_depart";
            this.estadodepartDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.estadodepartDataGridViewTextBoxColumn.Name = "estadodepartDataGridViewTextBoxColumn";
            this.estadodepartDataGridViewTextBoxColumn.Width = 125;
            // 
            // tbDepartamentoBindingSource
            // 
            this.tbDepartamentoBindingSource.DataMember = "TbDepartamento";
            this.tbDepartamentoBindingSource.DataSource = this.dBTrivagoDataSet14;
            // 
            // dBTrivagoDataSet14
            // 
            this.dBTrivagoDataSet14.DataSetName = "DBTrivagoDataSet14";
            this.dBTrivagoDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbDepartamentoTableAdapter
            // 
            this.tbDepartamentoTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(403, 375);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 341;
            this.label5.Text = "Aceptar";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::CapaPresentacion.Properties.Resources.aceptar;
            this.button5.Location = new System.Drawing.Point(405, 327);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 46);
            this.button5.TabIndex = 340;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::CapaPresentacion.Properties.Resources.ultimo;
            this.button4.Location = new System.Drawing.Point(350, 327);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 46);
            this.button4.TabIndex = 339;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::CapaPresentacion.Properties.Resources.siguiente;
            this.button1.Location = new System.Drawing.Point(291, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 46);
            this.button1.TabIndex = 338;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button2.Location = new System.Drawing.Point(231, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 46);
            this.button2.TabIndex = 337;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button3.Location = new System.Drawing.Point(171, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 46);
            this.button3.TabIndex = 336;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(353, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 335;
            this.label4.Text = "Ultimo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 334;
            this.label3.Text = "Siguiente";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 375);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 333;
            this.label2.Text = "Anterior";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 375);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 332;
            this.label1.Text = "Primero";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(455, 375);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 343;
            this.label6.Text = "Limpiar";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.BackgroundImage = global::CapaPresentacion.Properties.Resources.escoba;
            this.btn_Limpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Limpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Limpiar.Location = new System.Drawing.Point(457, 327);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 342;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(640, 402);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Name = "FBusquedaDepartamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaDepartamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaDepartamento_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaDepartamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDepartamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBTrivagoDataSet14 dBTrivagoDataSet14;
        private System.Windows.Forms.BindingSource tbDepartamentoBindingSource;
        private DBTrivagoDataSet14TableAdapters.TbDepartamentoTableAdapter tbDepartamentoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddepartamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombredepartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripciondepartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadodepartDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}