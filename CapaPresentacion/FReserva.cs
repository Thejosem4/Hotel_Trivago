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
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class FReserva : Form
    {
        private CNReserva objReserva = new CNReserva();

        // Variables Manager


        // Variables auxiliares
        public bool limpiar = false;
        public bool caso = false;

        // Variables Locales
        public Decimal importe = 0;
        public int id_reserva = 0;
        public int id_cliente = 0;
        public int id_habitacion = 0;
        public int id_empleado = 0;
        public string metodo_pago;

        public FReserva()
        {
            InitializeComponent();
            txtcedula.TextChanged += txtcedula_TextChanged;
            txtcedula.KeyPress += SoloNumeros_KeyPress;
        }

        private void FReserva_Load(object sender, EventArgs e)
        {
            //// Cargar el primer cliente
            CargarDatos();
            //// Bloquear controles inicialmente
            BloquearControles(true);
            //// Bloquear combobox
            combo.Enabled = false;
        }

        // Metodos Cargar Datos
        private void CargarDatos()
        {
            try
            {
                DataTable dt = objReserva.ReservaConsultar(Program.parametro); // Método que devuelve todos los usuarios

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer usuario
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    id_cliente = (int)fila["id_cliente"];
                    id_habitacion = (int)fila["id_habitacion"];
                    importe = (decimal)fila["importe"];

                    // Para la fecha, asegúrate de convertirla correctamente
                    dateTimePicker1.Value = Convert.ToDateTime(fila["fecha_reserva"]);
                    dateTimePicker2.Value = Convert.ToDateTime(fila["fecha_ingreso"]);
                    dateTimePicker3.Value = Convert.ToDateTime(fila["fecha_salida"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Meotodos de Bloquear
        private void BloquearControles(bool bloquear) 
        {
            // Bloquear o desbloquear los controles según el parámetro
            txtreserva.ReadOnly = !bloquear;
            txthabitacion.ReadOnly = !bloquear;
            txtempleado.ReadOnly = !bloquear;
            txtnombre.ReadOnly = !bloquear;
            txtapellido.ReadOnly = !bloquear;
            txtcedula.ReadOnly = !bloquear;
            txtprecio_noche.ReadOnly = !bloquear;
            txttipo.ReadOnly = !bloquear;
            txtimporte.ReadOnly = !bloquear;
            txtnombre_empleado.ReadOnly = !bloquear;
            txtapellido_empleado.ReadOnly = !bloquear;
            dateTimePicker1.Enabled = !bloquear;
            dateTimePicker2.Enabled = !bloquear;
            dateTimePicker3.Enabled = !bloquear;
            // Botones
            button1.Enabled = bloquear;
            button2.Enabled = !bloquear;
            // Botones Auxiliares
            btncliente.Enabled = bloquear;
            btnhabitacion.Enabled = bloquear;
            if (txtreserva.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void BloquearCliente(bool cliente)
        {
            txtnombre.ReadOnly = cliente;
            txtapellido.ReadOnly = cliente;
            txtcedula.ReadOnly = cliente;
            btncliente.Enabled = !cliente;
            if (limpiar == true)
            {
                btncliente2.Enabled = !cliente;
            }
        }

        private void BloquearHabitacion(bool habitacion)
        {
            txthabitacion.ReadOnly = habitacion;
            txtprecio_noche.ReadOnly = habitacion;
            txttipo.ReadOnly = habitacion;
            btnhabitacion.Enabled = !habitacion;
            if (limpiar == true)
            {
                btnhabitacion2.Enabled = !habitacion;
            }
        }

        private void BloquearEmpleado(bool empleado)
        {
            txtempleado.ReadOnly = empleado;
            txtnombre_empleado.ReadOnly = empleado;
            txtapellido_empleado.ReadOnly = empleado;
            btnempleado.Enabled = !empleado;
            if (limpiar == true)
            {
                btnempleado2.Enabled = !empleado;
            }
        }

        // Metodos Auxiliares

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

        // Evento KeyPress compartido para restringir a solo números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, tecla de retroceso y tecla de suprimir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Cancelar la entrada del carácter
            }
        }

        // Botones Auxiliares
        private void btncliente_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtcedula.Text.Trim();

                if (string.IsNullOrEmpty(cedula))
                {
                    MessageBox.Show("Ingrese la cédula del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcedula.Focus();
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

                CNCliente objCliente = new CNCliente();
                DataTable dt = objCliente.ClienteConsultar(cedula);

                if (dt.Rows.Count > 0)
                {
                    // Cliente encontrado - cargar datos
                    DataRow fila = dt.Rows[0];
                    id_cliente = (int)fila["id_cliente"];
                    txtnombre.Text = fila["nombre_cliente"].ToString();
                    txtapellido.Text = fila["apellido_cliente"].ToString();
                    txtcedula.Text = fila["cedula_cliente"].ToString();

                    BloquearCliente(true);
                    MessageBox.Show("Cliente encontrado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cliente no encontrado - ofrecer crear nuevo
                    DialogResult resultado = MessageBox.Show(
                        "Cliente no encontrado. ¿Desea crear un nuevo cliente con esta cédula?",
                        "Cliente no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Configurar variables para el formulario de mantenimiento
                        Program.managersalida = true;
                        Program.cedulaCliente = cedula;
                        Program.controlmov = 0;

                        FMantenimientoCliente fCliente = new FMantenimientoCliente();

                        this.Hide();
                        fCliente.ShowDialog();
                        this.Show();

                        // Verificar si se creó el cliente exitosamente
                        if (Program.managersalida == false && Program.controlmov == 1)
                        {
                            // Cliente fue creado exitosamente, usar el ID retornado
                            if (Program.vidcliente > 0)
                            {
                                string vid_cliente = Convert.ToString(Program.vidcliente);

                                // Cargar el cliente recién creado usando su ID
                                DataTable dtNuevo = objCliente.ClienteConsultar(vid_cliente);

                                if (dtNuevo.Rows.Count > 0)
                                {
                                    DataRow filaNueva = dtNuevo.Rows[0];
                                    id_cliente = (int)filaNueva["id_cliente"];
                                    txtnombre.Text = filaNueva["nombre_cliente"].ToString();
                                    txtapellido.Text = filaNueva["apellido_cliente"].ToString();
                                    txtcedula.Text = filaNueva["cedula_cliente"].ToString();

                                    BloquearCliente(true);
                                    MessageBox.Show("Cliente creado y cargado con éxito", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                // Fallback: intentar cargar por cédula
                                DataTable dtFallback = objCliente.ClienteConsultar(cedula);
                                if (dtFallback.Rows.Count > 0)
                                {
                                    DataRow filaFallback = dtFallback.Rows[0];
                                    id_cliente = (int)filaFallback["id_cliente"];
                                    txtnombre.Text = filaFallback["nombre_cliente"].ToString();
                                    txtapellido.Text = filaFallback["apellido_cliente"].ToString();
                                    txtcedula.Text = filaFallback["cedula_cliente"].ToString();

                                    BloquearCliente(true);
                                    MessageBox.Show("Cliente creado y cargado con éxito", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                        // Resetear variables globales
                        Program.managersalida = false;
                        Program.controlmov = 0;
                        Program.vidcliente = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al buscar el cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncliente2_Click(object sender, EventArgs e)
        {
            id_cliente = 0;
            txtnombre.Text = string.Empty;
            txtapellido.Text = string.Empty;
            txtcedula.Text = string.Empty;
            BloquearCliente(false);
        }

        // Botones Habitacion
        private void btnhabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txthabitacion.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el ID de la habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txthabitacion.Focus();
                    return;
                }

                CNHabitacion objHabitacion = new CNHabitacion();
                DataTable dt = objHabitacion.HabitacionConsultar(txthabitacion.Text);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    id_habitacion = Convert.ToInt32(fila["id_habitacion"]);
                    txthabitacion.Text = fila["id_habitacion"].ToString();
                    txtprecio_noche.Text = fila["precio"].ToString();
                    txttipo.Text = fila["tipo_habitacion"].ToString();

                    BloquearHabitacion(true);
                    MessageBox.Show("Habitación encontrada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Habitación no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txthabitacion.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al buscar la habitación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhabitacion2_Click(object sender, EventArgs e)
        {
            id_habitacion = 0;
            txthabitacion.Text = string.Empty;
            txtprecio_noche.Text = string.Empty;
            txttipo.Text = string.Empty;
            BloquearHabitacion(false);
        }

        // Botones del Empleado
        private void btnempleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtempleado.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Codigo del Empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CNEmpleado objEmpleado = new CNEmpleado();
                DataTable dt = objEmpleado.EmpleadoConsultar(txtempleado.Text);
                if (dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    // Mostrar los datos en los controles
                    id_empleado = (int)fila["id_empleado"];
                    txtempleado.Text = fila["id_empleado"].ToString();
                    txtnombre_empleado.Text = fila["nombre_empleado"].ToString();
                    txtapellido_empleado.Text = fila["apellido_empleado"].ToString();
                    // Llamamos el metodo de bloquear los controles del Habitacion
                    BloquearEmpleado(true);
                    // Mostramos que fue guardado con Exito
                    MessageBox.Show("Empleado Guardada con Éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empleado no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error ingrese valores correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnempleado2_Click(object sender, EventArgs e)
        {
            txtempleado.Text = string.Empty;
            txtnombre_empleado.Text = string.Empty;
            txtapellido_empleado.Text = string.Empty;
            BloquearEmpleado(false);
        }

        // Botones Principales
        private void button1_Click(object sender, EventArgs e)
        {
            // Control Bloqueo
            BloquearControles(false);
            txtreserva.Enabled = false;
            txtimporte.Enabled = false;
            combo.Enabled = true;

            // Limpiar los campos
            txtreserva.Text = string.Empty;
            txthabitacion.Text = string.Empty;
            txtempleado.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtapellido.Text = string.Empty;
            txtcedula.Text = string.Empty;
            txtprecio_noche.Text = string.Empty;
            txttipo.Text = string.Empty;
            txtimporte.Text = string.Empty;
            txtnombre_empleado.Text = string.Empty;
            txtapellido_empleado.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtreserva.ReadOnly = true;
            txtimporte.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = true;
            FBusquedaReserva freserva = new FBusquedaReserva();
            this.Close();
            freserva.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los datos necesarios para guardar la reserva
                if (id_cliente == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (id_habitacion == 0)
                {
                    MessageBox.Show("Debe seleccionar una habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (id_empleado == 0)
                {
                    MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar fechas
                DateTime fechaReserva = dateTimePicker1.Value;
                DateTime fechaIngreso = dateTimePicker2.Value;
                DateTime fechaSalida = dateTimePicker3.Value;

                if (fechaIngreso > fechaSalida)
                {
                    MessageBox.Show("La fecha de ingreso no puede ser posterior a la fecha de salida",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (fechaReserva > fechaIngreso)
                {
                    MessageBox.Show("La fecha de reserva no puede ser posterior a la fecha de ingreso",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                metodo_pago = combo.Text;

                // Si hay un ID de reserva, estamos actualizando
                if (!string.IsNullOrEmpty(txtreserva.Text))
                {
                    int id_reserva = Convert.ToInt32(txtreserva.Text);
                    string resultado = CNReserva.ReservaActualizar(
                        id_reserva,
                        id_cliente,
                        id_habitacion,
                        fechaReserva,
                        fechaIngreso,
                        fechaSalida,
                        metodo_pago
                    );
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Si no hay ID de reserva, estamos insertando
                else
                {
                    int nuevo_id;
                    string resultado = CNReserva.ReservaInsertar(
                        id_cliente,
                        id_habitacion,
                        fechaReserva,
                        fechaIngreso,
                        fechaSalida,
                        metodo_pago,
                        out nuevo_id
                    );
                    txtreserva.Text = nuevo_id.ToString();
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bloquear los controles después de guardar
                BloquearControles(true);
                combo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id_reserva = txtreserva.Text.Trim();

                if (string.IsNullOrEmpty(id_reserva))
                {
                    MessageBox.Show("Por favor, ingrese un ID de reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Preguntar al usuario si está seguro de eliminar la reserva
                if (MessageBox.Show("¿Está seguro de que desea eliminar el reserva con ID " + id_reserva + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }

                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNReserva.ReservaEliminar(id_reserva);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Reserva eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El reserva no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == true)
            {
                // Si el caso es 1, no se muestra el mensaje de advertencia
            }
            else
            {
                if (MessageBox.Show("Esto le hará volver al Menu Principal!\n¿Seguro que desea hacerlo ? ",
                    "Mensaje de Hotel Trivago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
