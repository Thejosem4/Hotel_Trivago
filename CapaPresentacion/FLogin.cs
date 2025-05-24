using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FLogin : Form
    {
        public Form FLoginInfo { get; set; }
        public Form FLoginInfoSegundo { get; set; }

        public bool LoginExitoso { get; private set; } = false;
        private int caso;

        private bool contrafirst = true;
        private bool usuafirst = true;
        private bool formLoaded = false;

        private int intentosFallidos = 0; // Contador de intentos fallidos 
        
        public FLogin()
        {
            InitializeComponent();
            this.AcceptButton = button2; // Establece el botón de inicio de sesión como el botón predeterminado
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            // Establecer el foco en un control neutral (puede ser el formulario mismo)
            this.ActiveControl = button2;

            // Marcar que el formulario ya está cargado
            formLoaded = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text.Trim();
            string clave = txtclave.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusuario.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingrese la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtclave.Focus();
                return;
            }

            // Autenticación de usuario
            CNUsuario objUsuario = new CNUsuario();
            int loginExitoso = objUsuario.IniciarSesion(usuario, clave);

            if (loginExitoso == 0)
            {
                // Marcar que el login fue exitoso
                this.LoginExitoso = true;
                caso = 1; // Cambia el caso para indicar que el login fue exitoso

                // Cerrar el formulario de login para continuar con el menú principal
                this.Close();
            }
            else
            {
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Usuario bloqueado. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    caso = 1; // Cambia el caso para indicar que el usuario está bloqueado
                    this.Close(); // Cierra el formulario de login
                }
                else
                {
                    string mensaje = "";
                    if (loginExitoso == 1)
                        mensaje = "El Usuario al que intenta acceder no está disponible";
                    else if (loginExitoso == 2)
                        mensaje = "Usuario o contraseña incorrectos";

                    MessageBox.Show($"{mensaje}. Intentos restantes: {3 - intentosFallidos}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtclave.Clear();
                    txtclave.Focus();
                }
            }
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            // Solo ejecutar cuando el formulario ya esté cargado
            if (formLoaded && (usuafirst || txtusuario.Text == "Usuario"))
            {
                txtusuario.Text = string.Empty;
                usuafirst = false;
            }
        }

        private void txtclave_Enter(object sender, EventArgs e)
        {
            // Solo ejecutar cuando el formulario ya esté cargado
            if (formLoaded && contrafirst)
            {
                txtclave.Text = string.Empty;
                txtclave.PasswordChar = '•'; // Ocultar la contraseña
                contrafirst = false;
            }
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            // Verificar el estado actual de la contraseña
            if (txtclave.PasswordChar == '\0')
            {
                // Si el texto es visible, ocultarlo
                txtclave.PasswordChar = '•';
            }
            else
            {
                // Si el texto está oculto, mostrarlo
                txtclave.PasswordChar = '\0';
            }
        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            FLoginInfo fLoginInfo = new FLoginInfo();
            caso = 1;
            this.Hide();
            fLoginInfo.ShowDialog();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == 1)
            {
            }
            else
            {
                if (MessageBox.Show("Esto le hará salir de la aplicación!\n¿Seguro que desea hacerlo ? ",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true; // El usuario canceló el cierre
                }
            }
        }
    }
}
// Desarrollador: Thejosem4 (De un Junior para Juniors)
// Colaboradores: Emyraich, hermesshc and JBCMRnot
// Este código es de un formulario de inicio de sesión en C#, Elabora para un sistema de gestión de Reservaciones y Inventario.
// El código incluye validaciones para campos vacíos, autenticación de usuario y manejo de intentos fallidos.
// Se recomienda agregar más validaciones y mejorar la seguridad del sistema de autenticación.

