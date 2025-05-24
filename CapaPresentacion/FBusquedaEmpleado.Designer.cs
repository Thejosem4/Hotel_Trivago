using System;

namespace CapaPresentacion
{
    partial class FBusquedaEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBusquedaEmpleado));
            this.tbEmpleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet = new CapaPresentacion.DBTrivagoDataSet();
            this.tbEmpleadoTableAdapter = new CapaPresentacion.DBTrivagoDataSetTableAdapters.TbEmpleadoTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechanacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacontratacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEmpleadoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dBTrivagoDataSet5 = new CapaPresentacion.DBTrivagoDataSet5();
            this.tbEmpleadoTableAdapter1 = new CapaPresentacion.DBTrivagoDataSet5TableAdapters.TbEmpleadoTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpleadoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmpleadoBindingSource
            // 
            this.tbEmpleadoBindingSource.DataMember = "TbEmpleado";
            this.tbEmpleadoBindingSource.DataSource = this.dBTrivagoDataSet;
            // 
            // dBTrivagoDataSet
            // 
            this.dBTrivagoDataSet.DataSetName = "DBTrivagoDataSet";
            this.dBTrivagoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbEmpleadoTableAdapter
            // 
            this.tbEmpleadoTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idempleadoDataGridViewTextBoxColumn,
            this.idcargoDataGridViewTextBoxColumn,
            this.nombreempleadoDataGridViewTextBoxColumn,
            this.apellidoempleadoDataGridViewTextBoxColumn,
            this.telefonoempleadoDataGridViewTextBoxColumn,
            this.correoempleadoDataGridViewTextBoxColumn,
            this.cedulaempleadoDataGridViewTextBoxColumn,
            this.fechanacDataGridViewTextBoxColumn,
            this.fechacontratacionDataGridViewTextBoxColumn,
            this.salarioDataGridViewTextBoxColumn,
            this.estadoempleadoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbEmpleadoBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(22, 110);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(627, 184);
            this.dataGridView1.TabIndex = 205;
            // 
            // idempleadoDataGridViewTextBoxColumn
            // 
            this.idempleadoDataGridViewTextBoxColumn.DataPropertyName = "id_empleado";
            this.idempleadoDataGridViewTextBoxColumn.HeaderText = "id_empleado";
            this.idempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idempleadoDataGridViewTextBoxColumn.Name = "idempleadoDataGridViewTextBoxColumn";
            this.idempleadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // idcargoDataGridViewTextBoxColumn
            // 
            this.idcargoDataGridViewTextBoxColumn.DataPropertyName = "id_cargo";
            this.idcargoDataGridViewTextBoxColumn.HeaderText = "id_cargo";
            this.idcargoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idcargoDataGridViewTextBoxColumn.Name = "idcargoDataGridViewTextBoxColumn";
            this.idcargoDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreempleadoDataGridViewTextBoxColumn
            // 
            this.nombreempleadoDataGridViewTextBoxColumn.DataPropertyName = "nombre_empleado";
            this.nombreempleadoDataGridViewTextBoxColumn.HeaderText = "nombre_empleado";
            this.nombreempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreempleadoDataGridViewTextBoxColumn.Name = "nombreempleadoDataGridViewTextBoxColumn";
            this.nombreempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // apellidoempleadoDataGridViewTextBoxColumn
            // 
            this.apellidoempleadoDataGridViewTextBoxColumn.DataPropertyName = "apellido_empleado";
            this.apellidoempleadoDataGridViewTextBoxColumn.HeaderText = "apellido_empleado";
            this.apellidoempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.apellidoempleadoDataGridViewTextBoxColumn.Name = "apellidoempleadoDataGridViewTextBoxColumn";
            this.apellidoempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefonoempleadoDataGridViewTextBoxColumn
            // 
            this.telefonoempleadoDataGridViewTextBoxColumn.DataPropertyName = "telefono_empleado";
            this.telefonoempleadoDataGridViewTextBoxColumn.HeaderText = "telefono_empleado";
            this.telefonoempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.telefonoempleadoDataGridViewTextBoxColumn.Name = "telefonoempleadoDataGridViewTextBoxColumn";
            this.telefonoempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // correoempleadoDataGridViewTextBoxColumn
            // 
            this.correoempleadoDataGridViewTextBoxColumn.DataPropertyName = "correo_empleado";
            this.correoempleadoDataGridViewTextBoxColumn.HeaderText = "correo_empleado";
            this.correoempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.correoempleadoDataGridViewTextBoxColumn.Name = "correoempleadoDataGridViewTextBoxColumn";
            this.correoempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // cedulaempleadoDataGridViewTextBoxColumn
            // 
            this.cedulaempleadoDataGridViewTextBoxColumn.DataPropertyName = "cedula_empleado";
            this.cedulaempleadoDataGridViewTextBoxColumn.HeaderText = "cedula_empleado";
            this.cedulaempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cedulaempleadoDataGridViewTextBoxColumn.Name = "cedulaempleadoDataGridViewTextBoxColumn";
            this.cedulaempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechanacDataGridViewTextBoxColumn
            // 
            this.fechanacDataGridViewTextBoxColumn.DataPropertyName = "fecha_nac";
            this.fechanacDataGridViewTextBoxColumn.HeaderText = "fecha_nac";
            this.fechanacDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fechanacDataGridViewTextBoxColumn.Name = "fechanacDataGridViewTextBoxColumn";
            this.fechanacDataGridViewTextBoxColumn.Width = 150;
            // 
            // fechacontratacionDataGridViewTextBoxColumn
            // 
            this.fechacontratacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_contratacion";
            this.fechacontratacionDataGridViewTextBoxColumn.HeaderText = "fecha_contratacion";
            this.fechacontratacionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fechacontratacionDataGridViewTextBoxColumn.Name = "fechacontratacionDataGridViewTextBoxColumn";
            this.fechacontratacionDataGridViewTextBoxColumn.Width = 150;
            // 
            // salarioDataGridViewTextBoxColumn
            // 
            this.salarioDataGridViewTextBoxColumn.DataPropertyName = "salario";
            this.salarioDataGridViewTextBoxColumn.HeaderText = "salario";
            this.salarioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.salarioDataGridViewTextBoxColumn.Name = "salarioDataGridViewTextBoxColumn";
            this.salarioDataGridViewTextBoxColumn.Width = 150;
            // 
            // estadoempleadoDataGridViewTextBoxColumn
            // 
            this.estadoempleadoDataGridViewTextBoxColumn.DataPropertyName = "estado_empleado";
            this.estadoempleadoDataGridViewTextBoxColumn.HeaderText = "estado_empleado";
            this.estadoempleadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.estadoempleadoDataGridViewTextBoxColumn.Name = "estadoempleadoDataGridViewTextBoxColumn";
            this.estadoempleadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // tbEmpleadoBindingSource1
            // 
            this.tbEmpleadoBindingSource1.DataMember = "TbEmpleado";
            this.tbEmpleadoBindingSource1.DataSource = this.dBTrivagoDataSet5;
            // 
            // dBTrivagoDataSet5
            // 
            this.dBTrivagoDataSet5.DataSetName = "DBTrivagoDataSet5";
            this.dBTrivagoDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbEmpleadoTableAdapter1
            // 
            this.tbEmpleadoTableAdapter1.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(354, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 287;
            this.label4.Text = "Ultimo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 348);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 286;
            this.label3.Text = "Siguiente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 348);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 285;
            this.label2.Text = "Anterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 348);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 284;
            this.label1.Text = "Primero";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::CapaPresentacion.Properties.Resources.primero;
            this.button1.Location = new System.Drawing.Point(171, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 46);
            this.button1.TabIndex = 294;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::CapaPresentacion.Properties.Resources.anterior;
            this.button2.Location = new System.Drawing.Point(230, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 46);
            this.button2.TabIndex = 295;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::CapaPresentacion.Properties.Resources.siguiente;
            this.button3.Location = new System.Drawing.Point(291, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 46);
            this.button3.TabIndex = 296;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::CapaPresentacion.Properties.Resources.ultimo;
            this.button4.Location = new System.Drawing.Point(350, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 46);
            this.button4.TabIndex = 297;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::CapaPresentacion.Properties.Resources.aceptar;
            this.button5.Location = new System.Drawing.Point(404, 300);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 46);
            this.button5.TabIndex = 298;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 348);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 299;
            this.label5.Text = "Aceptar";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.Login_Trivago1;
            this.pictureBox10.Location = new System.Drawing.Point(33, 12);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(90, 82);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 303;
            this.pictureBox10.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(222, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 25);
            this.label7.TabIndex = 304;
            this.label7.Text = "Buscar Empleado";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F);
            this.textBox1.Location = new System.Drawing.Point(156, 51);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 23);
            this.textBox1.TabIndex = 305;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::CapaPresentacion.Properties.Resources._2;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(470, 33);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 41);
            this.button6.TabIndex = 306;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(535, 33);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 41);
            this.button7.TabIndex = 307;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(600, 33);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(49, 41);
            this.button8.TabIndex = 308;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(458, 348);
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
            this.btn_Limpiar.Location = new System.Drawing.Point(460, 300);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(46, 46);
            this.btn_Limpiar.TabIndex = 329;
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // FBusquedaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Salir__1_3;
            this.ClientSize = new System.Drawing.Size(676, 376);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox10);
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
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FBusquedaEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FBusquedaEmpleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBusquedaEmpleado_FormClosing);
            this.Load += new System.EventHandler(this.FBusquedaEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEmpleadoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBTrivagoDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DBTrivagoDataSet dBTrivagoDataSet;
        private System.Windows.Forms.BindingSource tbEmpleadoBindingSource;
        private DBTrivagoDataSetTableAdapters.TbEmpleadoTableAdapter tbEmpleadoTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DBTrivagoDataSet5 dBTrivagoDataSet5;
        private System.Windows.Forms.BindingSource tbEmpleadoBindingSource1;
        private DBTrivagoDataSet5TableAdapters.TbEmpleadoTableAdapter tbEmpleadoTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechanacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacontratacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Limpiar;
    }
}