using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FMenuMantenimiento : Form
    {
        private bool managerclosing = false;

        public FMenuMantenimiento()
        {
            InitializeComponent();
        }


        private void FMenuMantenimiento_Load(object sender, EventArgs e)
        {
            Program.managerinfo = true;
            PanelSalidas.Visible = false;
            PanelMantenimientos.Visible = true;
        }

        // Cliente
        private void button1_Click(object sender, EventArgs e)
        {
            FMantenimiento_Cliente fCliente = new FMantenimiento_Cliente();
            this.Hide();
            fCliente.Show();
        }

        // Empresa
        private void button2_Click(object sender, EventArgs e)
        {
            FMantenimientoEmpresa fEmpresa = new FMantenimientoEmpresa();
            this.Hide();
            fEmpresa.Show();
        }

        // Usuario
        private void button3_Click(object sender, EventArgs e)
        {
            FMantenimientoUsuario fUsuario = new FMantenimientoUsuario();
            this.Hide();
            fUsuario.Show();
        }

        // Habitacion
        private void button4_Click(object sender, EventArgs e)
        {
            FMantenimientoHabitacion fHabitacion = new FMantenimientoHabitacion();
            this.Hide();
            fHabitacion.Show();
        }

        // Inventario
        private void button5_Click(object sender, EventArgs e)
        {
            FMantenimientoInventario fInventario = new FMantenimientoInventario();
            this.Hide();
            fInventario.Show();
        }

        // Empleado
        private void button6_Click(object sender, EventArgs e)
        {
            FMantenimientoEmpleado fEmpleado = new FMantenimientoEmpleado();
            this.Hide();
            fEmpleado.Show();
        }

        // Cargo
        private void button7_Click(object sender, EventArgs e)
        {
            FMantenimientoCargo fCargo = new FMantenimientoCargo();
            this.Hide();
            fCargo.Show();
        }

        // Roles
        private void button8_Click(object sender, EventArgs e)
        {
            FMantenimientoRol fRol = new FMantenimientoRol();
            this.Hide();
            fRol.Show();
        }

        // Departamento
        private void button9_Click(object sender, EventArgs e)
        {
            FMantenimientoDepartamento fDepartamento = new FMantenimientoDepartamento();
            this.Hide();
            fDepartamento.Show();
        }

        // Inventario Suministro
        private void button10_Click(object sender, EventArgs e)
        {
            FMantenimientoInv_Suministro fInventarioSuministro = new FMantenimientoInv_Suministro();
            this.Hide();
            fInventarioSuministro.Show();
        }
        // Factura
        private void button16_Click(object sender, EventArgs e)
        {
            FFactura fFactura = new FFactura();
            this.Hide();
            fFactura.Show();
        }

        // Mantenimientos
        private void button11_Click(object sender, EventArgs e)
        {
            PanelMantenimientos.Visible = true;
            PanelSalidas.Visible = false;
        }

        // Formularios de Salida
        private void button12_Click(object sender, EventArgs e)
        {
            PanelMantenimientos.Visible = false;
            PanelSalidas.Visible = true;
        }

        // Informacion
        private void button14_Click(object sender, EventArgs e)
        {
        }

        // Informacion
        private void button13_Click(object sender, EventArgs e)
        {
            FLoginInfo fLoginInfo = new FLoginInfo();
            this.Hide();
            fLoginInfo.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            managerclosing = true; // Cambiamos el estado a cerrar sesión
            this.Close();
        }
        private void FMenuMantenimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (managerclosing == true)
            {
                FLogin fLogin = new FLogin();
                if (MessageBox.Show("Esto Cerrara su Sesión de la aplicación!\n¿Seguro que desea hacerlo ? ",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    fLogin.Show();
                }
                else
                {
                    e.Cancel = true; // El usuario canceló el cierre
                }
            }
            else if (managerclosing == false)
            {
                if (MessageBox.Show("Esto le hará salir de la aplicación!\n¿Seguro que desea hacerlo ? ",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    // Terminamos la aplicación
                    Process.GetCurrentProcess().Kill(); // Esto terminará la aplicación inmediatamente sin llamar a otros eventos FormClosing
                }
                else
                {
                    e.Cancel = true; // El usuario canceló el cierre
                }
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {

        }
    }
}