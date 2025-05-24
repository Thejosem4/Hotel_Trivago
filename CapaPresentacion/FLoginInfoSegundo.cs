using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FLoginInfoSegundo : Form
    {
        public bool exception = false;
        public FLoginInfoSegundo()
        {
            InitializeComponent();
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            exception = true;
            FLoginInfo fLoginInfo = new FLoginInfo();
            this.Close();
            fLoginInfo.ShowDialog();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            if (Program.managerinfo == false)
            {
                FLogin fLogin = new FLogin();
                this.Hide();
                fLogin.ShowDialog();
            }
            else
            {
                FMenuMantenimiento menu = new FMenuMantenimiento();
                this.Hide();
                menu.ShowDialog();
            }
        }

        private void FLoginInfoSegundo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exception == true)
            {
                this.Hide();
            }
        }
    }
}
