using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FLoginInfo : Form
    {
        public bool exception = false;
        public FLoginInfo()
        {
            InitializeComponent();
        }

        private void btn_MasInfo_Click(object sender, EventArgs e)
        {
            exception = true;
            FLoginInfoSegundo fLoginInfoSegundo = new FLoginInfoSegundo();
            this.Close();
            fLoginInfoSegundo.ShowDialog();
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
                this.Close();
            }
        }

        private void FLoginInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exception == true)
            {
                this.Hide();
            }
        }
    }
}
