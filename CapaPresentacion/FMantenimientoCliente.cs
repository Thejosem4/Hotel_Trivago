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
    public partial class FMantenimientoCliente : Form
    {
        int caso;
        private CNCliente objCliente = new CNCliente();
        public int id_cliente;

        public FMantenimientoCliente()
        {
            InitializeComponent(); 

            // Agregar los manejadores de eventos a los TextBox
            txtcedula.TextChanged += txtcedula_TextChanged;
            txttelefono.TextChanged += txttelefono_TextChanged;

            // Asegurarse de que solo se acepten números y algunos caracteres de control
            txtcedula.KeyPress += SoloNumeros_KeyPress;
            txttelefono.KeyPress += SoloNumeros_KeyPress;
        }

        private void FMantenimiento_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                // Si venimos desde la factura con una cédula específica
                if (Program.managersalida == true && !string.IsNullOrEmpty(Program.cedulaCliente))
                {
                    // Configurar para nuevo cliente con la cédula predefinida
                    BloquearControles(false);
                    txtcodigo.ReadOnly = true;
                    txtcodigo.Text = "";
                    txtnombre.Text = "";
                    txtapellido.Text = "";
                    txttelefono.Text = "";
                    txtemail.Text = "";
                    txtdireccion.Text = "";
                    txtcedula.Text = Program.cedulaCliente; // Precargar la cédula
                    dateTimePicker1.Value = DateTime.Now;

                    // Enfocar el campo nombre para que el usuario pueda empezar a llenar
                    txtnombre.Focus();
                }
                else
                {
                    // Comportamiento normal - cargar datos existentes
                    CargarDatos();
                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // En caso de error, configurar modo de nuevo cliente
                BloquearControles(false);
                txtcodigo.ReadOnly = true;
            }
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = objCliente.ClienteConsultar(Program.parametro); // Método que devuelve todos los usuarios

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer usuario
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text= fila["id_cliente"].ToString();
                    txtnombre.Text = fila["nombre_cliente"].ToString();
                    txtapellido.Text = fila["apellido_cliente"].ToString();
                    txttelefono.Text = fila["telefono_cliente"].ToString();
                    txtemail.Text = fila["email_cliente"].ToString();
                    txtdireccion.Text = fila["direccion_cliente"].ToString();
                    txtcedula.Text = fila["cedula_cliente"].ToString();

                    // Para la fecha, asegúrate de convertirla correctamente
                    dateTimePicker1.Value = Convert.ToDateTime(fila["fecha_registro"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodigo.ReadOnly = bloquear;
            txtnombre.ReadOnly = bloquear;
            txtapellido.ReadOnly = bloquear;
            txttelefono.ReadOnly = bloquear;
            txtemail.ReadOnly = bloquear;
            txtdireccion.ReadOnly = bloquear;
            txtcedula.ReadOnly = bloquear;
            dateTimePicker1.Enabled = !bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if(txtnombre.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        // Evento KeyPress compartido para restringir a solo números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, tecla de retroceso y tecla de suprimir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Cancelar la entrada del carácter
            }
        }

        // Manejador para el formato de cédula (xxx-xxxxxxx-x)
        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            string texto = Regex.Replace(txtcedula.Text, @"[^\d]", ""); // Eliminar todos los no dígitos

            // Limitar a 11 dígitos (la cantidad necesaria para la cédula)
            if (texto.Length > 11)
                texto = texto.Substring(0, 11);

            // Aplicar formato xxx-xxxxxxx-x
            string formateado = "";

            if (texto.Length > 0)
            {
                // Primeros 3 dígitos
                formateado = texto.Substring(0, Math.Min(3, texto.Length));

                // Guion después de los primeros 3 dígitos
                if (texto.Length > 3)
                {
                    formateado += "-";

                    // Siguientes 7 dígitos
                    int longitudMedia = Math.Min(7, texto.Length - 3);
                    formateado += texto.Substring(3, longitudMedia);

                    // Guion después de los siguientes 7 dígitos
                    if (texto.Length > 10)
                    {
                        formateado += "-";
                        formateado += texto.Substring(10, 1); // Último dígito
                    }
                }
            }

            // Actualizar texto sin disparar este evento de nuevo
            txtcedula.TextChanged -= txtcedula_TextChanged;
            txtcedula.Text = formateado;
            txtcedula.TextChanged += txtcedula_TextChanged;

            // Colocar cursor al final del texto
            txtcedula.SelectionStart = txtcedula.Text.Length;
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

        // Método para validar que la cédula esté completa
        public bool ValidarCedula(string cedula)
        {
            // La cédula formateada correctamente debe tener exactamente 13 caracteres (incluyendo guiones)
            if (cedula.Length != 13)
                return false;

            // Verificar el formato xxx-xxxxxxx-x
            Regex regex = new Regex(@"^\d{3}-\d{7}-\d{1}$");
            return regex.IsMatch(cedula);
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
            txtcodigo.ReadOnly = true; // No permitir editar el ID de usuario
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txttelefono.Text = "";
            txtemail.Text = "";
            txtdireccion.Text = "";
            txtcedula.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de usuario
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaCliente FBusquedaCliente = new FBusquedaCliente();
            this.Close();
            FBusquedaCliente.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtcedula.Text.Trim();
                string telefono = txttelefono.Text.Trim();

                // Validaciones básicas de campos obligatorios
                if (string.IsNullOrEmpty(txtnombre.Text.Trim()))
                {
                    MessageBox.Show("El nombre del cliente es obligatorio", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtapellido.Text.Trim()))
                {
                    MessageBox.Show("El apellido del cliente es obligatorio", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtapellido.Focus();
                    return;
                }

                // Validar la cédula
                if (!ValidarCedula(cedula))
                {
                    MessageBox.Show("La cédula debe tener el formato 000-0000000-0",
                        "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcedula.Focus();
                    return;
                }

                // Validar el teléfono si no está vacío
                if (!string.IsNullOrEmpty(telefono) && !ValidarTelefono(telefono))
                {
                    MessageBox.Show("El teléfono debe tener el formato 000-000-0000",
                        "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttelefono.Focus();
                    return;
                }

                DateTime fechaRegistro = dateTimePicker1.Value;

                // Si el ID de cliente no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    id_cliente = Convert.ToInt32(txtcodigo.Text);

                    string actualizar = CNCliente.ClienteActualizar(
                        id_cliente,
                        txtnombre.Text.Trim(),
                        txtapellido.Text.Trim(),
                        txttelefono.Text.Trim(),
                        txtemail.Text.Trim(),
                        txtdireccion.Text.Trim(),
                        txtcedula.Text.Trim(),
                        fechaRegistro
                    );

                    MessageBox.Show(actualizar, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BloquearControles(true);
                }
                // Si el ID de cliente está vacío, entonces estamos insertando
                else
                {
                    // Verificar si la cédula ya existe antes de insertar
                    CNCliente objClienteValidacion = new CNCliente();
                    DataTable dtExistente = objClienteValidacion.ClienteConsultar(cedula);

                    if (dtExistente.Rows.Count > 0)
                    {
                        MessageBox.Show("Ya existe un cliente con esta cédula", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcedula.Focus();
                        return;
                    }

                    int nuevo_id;
                    string mantenimiento = CNCliente.ClienteInsertar(
                        txtnombre.Text.Trim(),
                        txtapellido.Text.Trim(),
                        txttelefono.Text.Trim(),
                        txtemail.Text.Trim(),
                        txtdireccion.Text.Trim(),
                        txtcedula.Text.Trim(),
                        fechaRegistro,
                        out nuevo_id
                    );

                    txtcodigo.Text = Convert.ToString(nuevo_id);
                    MessageBox.Show(mantenimiento, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si venimos desde la factura (managersalida == true), configurar variables de retorno
                    if (Program.managersalida == true)
                    {
                        Program.vidcliente = nuevo_id;
                        Program.controlmov = 1;
                        Program.managersalida = false; // Indicar que el cliente fue creado exitosamente

                        MessageBox.Show("Cliente creado exitosamente. Regresando a la factura...",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                        return;
                    }

                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id_cliente = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_cliente))
                {
                    MessageBox.Show("Por favor, ingrese un ID de cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Preguntar al usuario si está seguro de eliminar el cliente
                if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente con ID " + id_cliente + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }

                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNCliente.ClienteEliminar(id_cliente);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Cliente eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El cliente no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimiento_Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == 1)
            {
                // Si el caso es 1 (viene de búsqueda), permitir cierre sin confirmación
                e.Cancel = false;
            }
            else
            {
                if (Program.managersalida == true)
                {
                    // Venimos desde factura, permitir cierre y retornar
                    e.Cancel = false;

                    // Solo mostrar mensaje si no se creó un cliente exitosamente
                    if (Program.controlmov != 1)
                    {
                        MessageBox.Show("Operación cancelada. Regresando a la factura...",
                                       "Información",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Comportamiento normal - confirmación para volver al menú principal
                    if (MessageBox.Show("Esto le hará volver al Menú Principal!\n¿Seguro que desea hacerlo?",
                        "Mensaje de Hotel Trivago",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}