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

        // Lista para rastrear formularios abiertos - NO STATIC para evitar problemas
        private List<Form> formulariosAbiertos = new List<Form>();

        // Método para cerrar todos los formularios abiertos
        private void CerrarTodosLosFormularios()
        {
            System.Diagnostics.Debug.WriteLine($"Cerrando todos los formularios. Cantidad: {formulariosAbiertos.Count}");

            for (int i = formulariosAbiertos.Count - 1; i >= 0; i--)
            {
                try
                {
                    var form = formulariosAbiertos[i];
                    if (!form.IsDisposed)
                    {
                        // Remover el evento antes de cerrar para evitar conflictos
                        form.FormClosed -= FormularioMantenimiento_FormClosed;
                        form.Close();
                        form.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    // Log silencioso para debugging
                    System.Diagnostics.Debug.WriteLine($"Error cerrando formulario: {ex.Message}");
                }
            }
            formulariosAbiertos.Clear();
            System.Diagnostics.Debug.WriteLine("Todos los formularios cerrados");
        }

        // Método genérico para abrir formularios de mantenimiento
        private void AbrirFormularioMantenimiento<T>() where T : Form, new()
        {
            try
            {
                // Primero, verificar si ya existe un formulario del mismo tipo abierto
                string tipoFormulario = typeof(T).Name;

                // Buscar formularios del mismo tipo
                for (int i = formulariosAbiertos.Count - 1; i >= 0; i--)
                {
                    var form = formulariosAbiertos[i];

                    // Si el formulario está disposed o cerrado, removerlo de la lista
                    if (form.IsDisposed)
                    {
                        formulariosAbiertos.RemoveAt(i);
                        continue;
                    }

                    // Si es del mismo tipo, cerrarlo
                    if (form.GetType().Name == tipoFormulario)
                    {
                        System.Diagnostics.Debug.WriteLine($"Cerrando formulario existente: {tipoFormulario}");
                        formulariosAbiertos.RemoveAt(i);
                        form.FormClosed -= FormularioMantenimiento_FormClosed; // Remover evento para evitar conflictos
                        form.Close();
                        form.Dispose();
                    }
                }

                // Crear nuevo formulario
                T nuevoFormulario = new T();
                System.Diagnostics.Debug.WriteLine($"Creando nuevo formulario: {tipoFormulario}");

                // Configurar evento de cierre
                nuevoFormulario.FormClosed += FormularioMantenimiento_FormClosed;

                // Agregar a la lista
                formulariosAbiertos.Add(nuevoFormulario);

                // Ocultar el menú principal y mostrar el nuevo formulario
                this.Hide();
                nuevoFormulario.Show();
                nuevoFormulario.BringToFront();

                System.Diagnostics.Debug.WriteLine($"Formularios en lista: {formulariosAbiertos.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error abriendo formulario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Asegurar que el menú sea visible si hay error
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.BringToFront();
                }
            }
        }

        // Método separado para manejar el cierre de formularios de mantenimiento
        private void FormularioMantenimiento_FormClosed(object sender, EventArgs e)
        {
            try
            {
                if (sender is Form form)
                {
                    System.Diagnostics.Debug.WriteLine($"Formulario cerrado: {form.GetType().Name}");

                    // Remover de la lista
                    formulariosAbiertos.Remove(form);

                    // Remover el evento para evitar memory leaks
                    form.FormClosed -= FormularioMantenimiento_FormClosed;

                    System.Diagnostics.Debug.WriteLine($"Formularios restantes: {formulariosAbiertos.Count}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en FormClosed: {ex.Message}");
            }

            // Mostrar el menú principal si no está siendo cerrado
            if (!this.IsDisposed && !managerclosing)
            {
                try
                {
                    this.Show();
                    this.BringToFront();
                    System.Diagnostics.Debug.WriteLine("Menú principal mostrado nuevamente");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error mostrando menú principal: {ex.Message}");
                }
            }
        }

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
            AbrirFormularioMantenimiento<FMantenimientoCliente>();
        }

        // Empresa
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoEmpresa>();
        }

        // Usuario
        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoUsuario>();
        }

        // Habitacion
        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoHabitacion>();
        }

        // Inventario
        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoInventario>();
        }

        // Empleado
        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoEmpleado>();
        }

        // Cargo
        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoCargo>();
        }

        // Roles
        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoRol>();
        }

        // Departamento
        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoDepartamento>();
        }

        // Inventario Suministro
        private void button10_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FMantenimientoInv_Suministro>();
        }

        // Factura
        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFormularioMantenimiento<FFactura>();
        }

        // Botón Mantenimientos - Cambiar vista a panel de mantenimientos
        private void button11_Click(object sender, EventArgs e)
        {
            PanelMantenimientos.Visible = true;
            PanelSalidas.Visible = false;
        }

        // Botón Formularios de Salida - Cambiar vista a panel de salidas
        private void button12_Click(object sender, EventArgs e)
        {
            PanelMantenimientos.Visible = false;
            PanelSalidas.Visible = true;
        }

        // Botón Información (placeholder)
        private void button14_Click(object sender, EventArgs e)
        {
            // Funcionalidad pendiente
        }

        // Botón Información - Abrir formulario de información de login
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                FLoginInfo fLoginInfo = new FLoginInfo();
                this.Hide();

                fLoginInfo.FormClosed += (s, args) =>
                {
                    try
                    {
                        // Mostrar el menú principal nuevamente
                        if (!this.IsDisposed && !managerclosing)
                        {
                            this.Show();
                            this.BringToFront();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error mostrando menú después de cerrar FLoginInfo: {ex.Message}");
                    }
                };

                fLoginInfo.ShowDialog();
                fLoginInfo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error abriendo información de login: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Asegurar que el menú sea visible si hay error
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.BringToFront();
                }
            }
        }

        // Botón Cerrar Sesión
        private void button15_Click(object sender, EventArgs e)
        {
            managerclosing = true;
            this.Close();
        }

        // Evento al cerrar el formulario principal
        private void FMenuMantenimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (managerclosing == true)
            {
                // Usuario quiere cerrar sesión
                if (MessageBox.Show("Esto Cerrara su Sesión de la aplicación!\n¿Seguro que desea hacerlo?",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    // Cerrar todos los formularios abiertos antes de cerrar sesión
                    CerrarTodosLosFormularios();
                    e.Cancel = false;
                }
                else
                {
                    // Usuario canceló el cierre de sesión
                    managerclosing = false;
                    e.Cancel = true;
                }
            }
            else
            {
                // Usuario quiere salir de la aplicación completamente
                if (MessageBox.Show("Esto le hará salir de la aplicación!\n¿Seguro que desea hacerlo?",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    // Cerrar todos los formularios abiertos
                    CerrarTodosLosFormularios();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    // Usuario canceló la salida
                    e.Cancel = true;
                }
            }
        }

        // Otro botón de información (placeholder)
        private void button14_Click_1(object sender, EventArgs e)
        {
            // Funcionalidad pendiente
        }
    }
}