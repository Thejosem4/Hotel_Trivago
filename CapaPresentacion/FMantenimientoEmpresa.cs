using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FMantenimientoEmpresa : Form
    {
        int caso;
        private CNEmpresa objEmpresa = new CNEmpresa();
        public FMantenimientoEmpresa()
        {
            InitializeComponent();
            txttelefono.TextChanged += txttelefono_TextChanged;
            txttelefono.KeyPress += SoloNumeros_KeyPress;
        }
        private void FMantenimientoEmpresa_Load(object sender, EventArgs e)
        {
            // Cargar la primera empresa
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = objEmpresa.EmpresaConsultar(Program.parametro); // Método que devuelve todas las empresas

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos de la primera empresa
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text = fila["id_empresa"].ToString();
                    txtnombre.Text = fila["nombre_empresa"].ToString();
                    txtemail.Text = fila["correo_empresa"].ToString();
                    txtrnc.Text = fila["rnc"].ToString();
                    txtdireccion.Text = fila["direccion_empresa"].ToString();
                    txttelefono.Text = fila["telefono_empresa"].ToString();
                    txtslogan.Text = fila["slogan"].ToString();
                    txtgerente.Text = fila["gerente"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodigo.ReadOnly = bloquear;
            txtrnc.ReadOnly = bloquear;
            txtnombre.ReadOnly = bloquear;
            txtslogan.ReadOnly = bloquear;
            txtemail.ReadOnly = bloquear;
            txtdireccion.ReadOnly = bloquear;
            txttelefono.ReadOnly = bloquear;
            txtgerente.ReadOnly = bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtnombre.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }
        // Evento KeyPress para restringir a solo números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, tecla de retroceso y tecla de suprimir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Cancelar la entrada del carácter
            }
        }

        // Manejador para el formato de teléfono (xxx-xxx-xxxx)
        private void txttelefono_TextChanged(object sender, EventArgs e)
        {
            string texto = Regex.Replace(txttelefono.Text, @"[^\d]", ""); // Eliminar todos los no dígitos

            // Limitar a 10 dígitos (la cantidad necesaria para el teléfono)
            if (texto.Length > 10)
                texto = texto.Substring(0, 10);

            // Aplicar formato xxx-xxx-xxxx
            string formateado = "";

            if (texto.Length > 0)
            {
                // Primeros 3 dígitos
                formateado = texto.Substring(0, Math.Min(3, texto.Length));

                // Guion después de los primeros 3 dígitos
                if (texto.Length > 3)
                {
                    formateado += "-";

                    // Siguientes 3 dígitos
                    int longitudMedia = Math.Min(3, texto.Length - 3);
                    formateado += texto.Substring(3, longitudMedia);

                    // Guion después de los siguientes 3 dígitos
                    if (texto.Length > 6)
                    {
                        formateado += "-";

                        // Últimos 4 dígitos
                        int longitudFinal = Math.Min(4, texto.Length - 6);
                        formateado += texto.Substring(6, longitudFinal);
                    }
                }
            }

            // Actualizar texto sin disparar este evento de nuevo
            txttelefono.TextChanged -= txttelefono_TextChanged;
            txttelefono.Text = formateado;
            txttelefono.TextChanged += txttelefono_TextChanged;

            // Colocar cursor al final del texto
            txttelefono.SelectionStart = txttelefono.Text.Length;
        }

        // Método para validar que el teléfono esté completo
        public bool ValidarTelefono(string telefono)
        {
            // El teléfono formateado correctamente debe tener exactamente 12 caracteres (incluyendo guiones)
            if (telefono.Length != 12)
                return false;

            // Verificar el formato xxx-xxx-xxxx
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            return regex.IsMatch(telefono);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de la empresa
            txtcodigo.Text = "";
            txtrnc.Text = "";
            txtnombre.Text = "";
            txtslogan.Text = "";
            txtemail.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtgerente.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de empresa
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaEmpresa FBusquedaEmpresa = new FBusquedaEmpresa();
            this.Close();
            FBusquedaEmpresa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Si el ID de empresa no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    txtcodigo.Text = "1";
                    int id_Empresa = Convert.ToInt32(txtcodigo.Text);
                    
                    string actualizar = CNEmpresa.EmpresaActualizar(
                        id_Empresa,
                        txtnombre.Text,
                        txtemail.Text,
                        txtrnc.Text,
                        txtdireccion.Text,
                        txttelefono.Text,
                        txtslogan.Text,
                        txtgerente.Text
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);

                }

                // Si el ID de empresa está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNEmpresa.EmpresaInsertar(
                        txtnombre.Text,
                        txtemail.Text,
                        txtrnc.Text,
                        txtdireccion.Text,
                        txttelefono.Text,
                        txtslogan.Text,
                        txtgerente.Text,
                        out nuevo_id
                    );
                    txtcodigo.Text = Convert.ToString(nuevo_id);
                    // Mostrar resultado
                    MessageBox.Show(mantenimiento);
                }

                BloquearControles(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string telefono = txttelefono.Text.Trim();
                // Validar el teléfono
                if (!ValidarTelefono(telefono))
                {
                    MessageBox.Show("El teléfono debe tener el formato 000-000-0000",
                        "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttelefono.Focus();
                    return;
                }
                string id_empresa = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_empresa))
                {
                    MessageBox.Show("Por favor, ingrese un ID de empresa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar la empresa
                if (MessageBox.Show("¿Está seguro de que desea eliminar la empresa con ID " + id_empresa + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNEmpresa.EmpresaEliminar(id_empresa);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Empresa eliminada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("La empresa no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMantenimientoEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == 1)
            {
                // Si el caso es 1, no se muestra el mensaje de advertencia
            }
            else
            {
                if (MessageBox.Show("Esto le hará volver al Menu Principal!\n¿Seguro que desea hacerlo ? ",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    e.Cancel = false;

                    FMenuMantenimiento fmenu = new FMenuMantenimiento();
                    fmenu.Show();
                }

                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
