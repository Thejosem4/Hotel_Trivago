namespace CapaPresentacion
{
    partial class FLoginInfo
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
            this.btn_MasInfo = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_MasInfo
            // 
            this.btn_MasInfo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MasInfo.Location = new System.Drawing.Point(713, 599);
            this.btn_MasInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MasInfo.Name = "btn_MasInfo";
            this.btn_MasInfo.Size = new System.Drawing.Size(159, 37);
            this.btn_MasInfo.TabIndex = 0;
            this.btn_MasInfo.Text = "Más información";
            this.btn_MasInfo.UseVisualStyleBackColor = true;
            this.btn_MasInfo.Click += new System.EventHandler(this.btn_MasInfo_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar.Location = new System.Drawing.Point(16, 599);
            this.btn_Cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(108, 37);
            this.btn_Cerrar.TabIndex = 1;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // FLoginInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.infologin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(888, 640);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_MasInfo);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FLoginInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLoginInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLoginInfo_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_MasInfo;
        private System.Windows.Forms.Button btn_Cerrar;
    }
}