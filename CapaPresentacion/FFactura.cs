using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FFactura : Form
    {
        private CNFactura objFactura = new CNFactura();

        public bool caso = false;
        public bool limpiar = false;
        public bool manager = false;

        public int id_factura;
        public int id_empresa = 1002;
        public int id_cliente;
        public int id_habitacion;
        public int id_empleado;
        public int id_reserva;
        public int id_detalle;
        public string metodo_pago;
        public DateTime fecha_creacion;
        public int descuento;
        public decimal total;
        public decimal importe_total;

        public FFactura()
        {
            InitializeComponent();
            txtcedula.TextChanged += txtcedula_TextChanged;
            txtcedula.KeyPress += SoloNumeros_KeyPress;
        }

        private void FFactura_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            BloquearControles(true);
            combo.Enabled = false;
            if (Program.controlmov == 1)
            {
                CargarCliente();
                BloquearControles(false);
                BloquearCliente(true);
                combo.Enabled = true;
            }
            else if(Program.controlmov == 2)
            {
                CargarHabitacion();
                BloquearControles(false);
                BloquearHabitacion(true);
                combo.Enabled = true;
            }
            txtsubtotal.ReadOnly = true;
            txttotal.ReadOnly = true;
            txtdescuento.Text = "0";
            txtsubtotal.Text = importe_total.ToString("0.00");
            txttotal.Text = total.ToString("0.00");
           if(Program.controlmov == 3)
            {
                CargarFactura();
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

        // Cargar Datos
        private void CargarFactura()
        {
            try
            {
                string facturaId = Convert.ToString(Program.vidfactura);
                CNFactura objFactura = new CNFactura();

                // Cargar datos de la cabecera de factura
                DataTable dtFactura = objFactura.FacturaConsultar(facturaId);
                if (dtFactura.Rows.Count > 0)
                {
                    // Obtener los datos principales de la factura (cabecera)
                    DataRow fila = dtFactura.Rows[0];

                    // Mostrar los datos en los controles
                    txtfactura.Text = fila["id_factura"].ToString();
                    txtempleado.Text = fila["id_empleado"].ToString();
                    combo.Text = fila["metodo_pago"].ToString();
                    total = Convert.ToDecimal(fila["total"]);
                    txttotal.Text = total.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("No se encontró la factura especificada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cargar detalles de la factura
                DataTable dtDetalles = objFactura.FacturaDetConsultar(facturaId);

                if (dtDetalles.Rows.Count > 0)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(dtDetalles.Rows[0]["fecha_emision"]);
                    id_reserva = Convert.ToInt32(dtDetalles.Rows[0]["id_reserva"]);
                }
                txtprecio_noche.Text = dtDetalles.Rows[0]["importe_total"].ToString();

                string parametro = Convert.ToString(id_reserva);
                CNReserva objReserva = new CNReserva();
                DataTable dt = objReserva.ReservaConsultar(parametro);
                id_cliente = (int)dt.Rows[0]["id_cliente"];
                id_habitacion = (int)dt.Rows[0]["id_habitacion"];
                CargarReserva();
                dataGridView1.Rows.Clear();

                // Índice auxiliar para id_detalle si no viene en los datos
                int detailIndex = 1;

                foreach (DataRow row in dtDetalles.Rows)
                {
                    // Verificar si el DataTable contiene la columna id_detalle
                    object idDetalle = detailIndex;
                    if (dtDetalles.Columns.Contains("id_detalle"))
                    {
                        idDetalle = row["id_detalle"];
                    }

                    // Usar el nombre correcto de la columna "importe_total" según el procedimiento almacenado
                    dataGridView1.Rows.Add(
                        idDetalle,
                        row["id_reserva"],
                        row["fecha_emision"],
                        row["descuento"],
                        row["importe_total"]  // Nombre correcto según el procedimiento almacenado
                    );

                    detailIndex++;
                }

                // Recalcular el total basado en los detalles cargados
                CalcularTotal();

                // Bloquear controles después de cargar
                BloquearControles(true);
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotal()
        {
            total = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["importe_total"].Value != null)
                {
                    total += Convert.ToDecimal(fila.Cells["importe_total"].Value);
                }
            }
            txttotal.Text = total.ToString("0.00");
        }

        private void CargarReserva()
        {
            try
            {
                // Declaramos los parametros que utilizaremos para cargar los datos
                string cliente = Convert.ToString(id_cliente);
                string habitacion = Convert.ToString(id_habitacion);

                CNCliente objCliente = new CNCliente();
                DataTable dtCliente = objCliente.ClienteConsultar(cliente);
                if (dtCliente.Rows.Count > 0)
                {
                    // Obtener datos del primer cliente
                    DataRow filaCliente = dtCliente.Rows[0];
                    // Mostrar los datos en los controles
                    txtnombre.Text = filaCliente["nombre_cliente"].ToString();
                    txtapellido.Text = filaCliente["apellido_cliente"].ToString();
                    txtcedula.Text = filaCliente["cedula_cliente"].ToString();
                    BloquearCliente(true);
                }
                CNHabitacion objHabitacion = new CNHabitacion();
                DataTable dtHabitacion = objHabitacion.HabitacionConsultar(habitacion);
                if (dtHabitacion.Rows.Count > 0)
                {
                    // Obtener datos de la primera habitación
                    DataRow filaHabitacion = dtHabitacion.Rows[0];
                    // Mostrar los datos en los controles
                    txthabitacion.Text = filaHabitacion["id_habitacion"].ToString();
                    txttipo.Text = filaHabitacion["tipo_habitacion"].ToString();
                    BloquearHabitacion(true);
                }
                limpiar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCliente()
        {
            try
            {
                string cliente = Convert.ToString(Program.vidcliente);
                CNCliente objCliente = new CNCliente();
                DataTable dtCliente = objCliente.ClienteConsultar(cliente);
                if (dtCliente.Rows.Count > 0)
                {
                    // Obtener datos del primer cliente
                    DataRow filaCliente = dtCliente.Rows[0];
                    // Mostrar los datos en los controles
                    txtnombre.Text = filaCliente["nombre_cliente"].ToString();
                    txtapellido.Text = filaCliente["apellido_cliente"].ToString();
                    txtcedula.Text = filaCliente["cedula_cliente"].ToString();
                    BloquearCliente(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarHabitacion()
        {
            try
            {
                string habitacion = Convert.ToString(Program.vidhabitacion);
                CNHabitacion objHabitacion = new CNHabitacion();
                DataTable dtHabitacion = objHabitacion.HabitacionConsultar(habitacion);
                if (dtHabitacion.Rows.Count > 0)
                {
                    // Obtener datos de la primera habitación
                    DataRow filaHabitacion = dtHabitacion.Rows[0];
                    // Mostrar los datos en los controles
                    txthabitacion.Text = filaHabitacion["id_habitacion"].ToString();
                    txttipo.Text = filaHabitacion["tipo_habitacion"].ToString();
                    BloquearHabitacion(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la habitacion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodos Para Bloquear o Desbloquear Controles
        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtfactura.ReadOnly = bloquear;
            txtnombre.ReadOnly = bloquear;
            txtapellido.ReadOnly = bloquear;
            txtcedula.ReadOnly = bloquear;
            txthabitacion.ReadOnly = bloquear;
            txtprecio_noche.ReadOnly = bloquear;
            txttipo.ReadOnly = bloquear;
            txtempleado.ReadOnly = bloquear;
            txtreserva.ReadOnly = bloquear;
            txtdescuento.ReadOnly = bloquear;
            
            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados

            btncliente.Enabled = !bloquear;
            btnhabitacion.Enabled = !bloquear;
            btnempleado.Enabled = !bloquear;
            btnreserva.Enabled = !bloquear;
            btncliente2.Enabled = !bloquear;
            btnhabitacion2.Enabled = !bloquear;
            btnempleado2.Enabled = !bloquear;
            btnreserva2.Enabled = !bloquear;
            btnagregar.Enabled = !bloquear;
            btneliminar.Enabled = !bloquear;
      

            if (txtfactura.Text == string.Empty)
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
            if(limpiar == true)
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
            btnempleado.Enabled = !empleado;
            if (limpiar == true)
            {
                btnempleado2.Enabled = !empleado;
            }
        }

        private void BloquearReserva(bool reserva)
        {
            txtreserva.ReadOnly = reserva;
            btnreserva.Enabled = !reserva;
            if (limpiar == true)
            {
                btnreserva2.Enabled = !reserva;
            }
        }

        // Configuracion del DataGridView
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Add("id_detalle", "ID Detalle");
            dataGridView1.Columns.Add("id_reserva", "ID Reserva");
            dataGridView1.Columns.Add("fecha_creacion", "Fecha Creación");
            dataGridView1.Columns.Add("descuento", "Descuento");
            dataGridView1.Columns.Add("importe_total", "Importe");

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        // Botones del Busqueda de cliente
        private void btncliente_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtcedula.Text.Trim();
                if (txtnombre.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el nombre del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtapellido.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el apellido del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtcedula.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese la cédula del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataTable dt = objCliente.ClienteConsultar(txtcedula.Text);
                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer cliente
                    DataRow fila = dt.Rows[0];
                    // Mostrar los datos en los controles
                    id_cliente = (int)fila["id_cliente"];
                    txtnombre.Text = fila["nombre_cliente"].ToString();
                    txtapellido.Text = fila["apellido_cliente"].ToString();
                    txtcedula.Text = fila["cedula_cliente"].ToString();
                    // Llamamos el metodo de bloquear los controles del cliente
                    BloquearCliente(true);
                    // Cambiamos el valor del Program.managersalida
                    Program.managersalida = false;
                    // Mostramos que fue guardado con Exito
                    MessageBox.Show("Cliente Guardada con Éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Program.managersalida = true;
                    MessageBox.Show("Cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FMantenimientoCliente fCliente = new FMantenimientoCliente();
                    this.Hide();
                    fCliente.Show();
                }
            }
            catch
            {
                MessageBox.Show("Error inesperado al cargar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Botones del Busqueda de Habitacion
        private void btnhabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txthabitacion.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Codigo de la Habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtprecio_noche.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Precio de la Habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txttipo.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el Tipo de Habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CNHabitacion objHabitacion = new CNHabitacion();
                DataTable dt = objHabitacion.HabitacionConsultar(txthabitacion.Text);
                if (dt.Rows.Count > 0)
                {                    
                    DataRow fila = dt.Rows[0];
                    // Mostrar los datos en los controles
                    txthabitacion.Text = fila["id_habitacion"].ToString();
                    txtprecio_noche.Text = fila["precio"].ToString();
                    txttipo.Text = fila["tipo_habitacion"].ToString();
                    // Llamamos el metodo de bloquear los controles del Habitacion
                    BloquearHabitacion(true);
                    // Cambiamos el valor del Program.managersalida
                    Program.managersalida = false;
                    // Mostramos que fue guardado con Exito
                    MessageBox.Show("Habitación Guardada con Éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Program.managersalida = true;
                    MessageBox.Show("Habitación no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FMantenimientoHabitacion fHabitacion = new FMantenimientoHabitacion();
                    this.Hide();
                    fHabitacion.Show();
                }
            }
            catch
            {
                MessageBox.Show("Error inesperado al cargar la habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhabitacion2_Click(object sender, EventArgs e)
        {
            id_habitacion = 0;
            txthabitacion.Text = string.Empty;
            txtprecio_noche.Text = string.Empty;
            txttipo.Text = string.Empty;
            BloquearHabitacion(true);
        }

        // Botones del Empleado
        private void btnempleado_Click(object sender, EventArgs e)
        {
            try
            {
                id_empleado = int.Parse(txtempleado.Text.Trim());
                if (id_empleado == 0)
                {
                    MessageBox.Show("Ingrese el ID del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    BloquearEmpleado(true);
                    btnempleado2.Enabled = true;
                    MessageBox.Show("Empleado encontrado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BloquearEmpleado(false);
        }

        // Botones de la Reserva
        private void btnreserva_Click(object sender, EventArgs e)
        {
            try
            {
                id_reserva = int.Parse(txtreserva.Text.Trim());
                if (id_reserva == 0)
                {
                    MessageBox.Show("Ingrese el ID de la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string parametro = Convert.ToString(id_reserva);
                CNReserva objReserva = new CNReserva();
                DataTable dt = objReserva.ReservaConsultar(parametro);
                if (dt.Rows.Count > 0)
                {
                    id_reserva = (int)dt.Rows[0]["id_reserva"];
                    id_cliente = (int)dt.Rows[0]["id_cliente"];
                    id_habitacion = (int)dt.Rows[0]["id_habitacion"];
                    txtprecio_noche.Text = dt.Rows[0]["importe"].ToString();
                    limpiar = true;
                    CargarReserva();
                    BloquearCliente(true);
                    BloquearHabitacion(true);
                    BloquearReserva(true);
                    btnreserva2.Enabled = true;
                    MessageBox.Show("Reserva encontrada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reserva no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error inesperado al cargar los datos de la Reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnreserva2_Click(object sender, EventArgs e)
        {
            txtreserva.Text = string.Empty;
            Clean();
            BloquearCliente(false);
            BloquearHabitacion(false);
            BloquearReserva(false);
        }
        // Metodo Limpiar textbox
        private void Clean()
        {
            txtnombre.Text = string.Empty;
            txtapellido.Text = string.Empty;
            txtcedula.Text = string.Empty;
            txthabitacion.Text = string.Empty;
            txtprecio_noche.Text = string.Empty;
            txttipo.Text = string.Empty;
            txtreserva.Text = string.Empty;
        }

        // Boton para crear nueva factura
        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            combo.Enabled = true;
            txtfactura.ReadOnly = true ;
            txtfactura.Text = string.Empty;
            txtempleado.Text = string.Empty;
            txtdescuento.Text = string.Empty;
            txtsubtotal.Text = string.Empty;
            txttotal.Text = string.Empty;
            Clean();
            txtdescuento.Text = "0";
            txtsubtotal.Text = importe_total.ToString("0.00");
            txttotal.Text = total.ToString("0.00");
            dateTimePicker1.Value = DateTime.Now; // Establecer la fecha actual
        }

        //Boton para editar la factura
        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            if (Program.controlmov == 3)
            {
                combo.Enabled = true;
            }
            txtfactura.ReadOnly = true; // Hacer el campo de factura no editable
        }

        //Boton de busqueda
        private void button3_Click(object sender, EventArgs e)
        {
            caso = true;
            FBusquedaFactura fBusqueda = new FBusquedaFactura();
            this.Close();
            fBusqueda.ShowDialog();
        }

        //Boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {
            id_empleado = Convert.ToInt32(txtempleado.Text);

            // Obtener valores de los controles
            fecha_creacion = dateTimePicker1.Value;
            metodo_pago = combo.Text;

            try
            {
                if (!string.IsNullOrEmpty(txtfactura.Text))
                {
                    try
                    {
                        // We're updating an existing invoice
                        id_factura = Convert.ToInt32(txtfactura.Text);
                        string parametro = Convert.ToString(id_factura);

                        // First, delete existing details (to avoid duplication issues)
                        int eliminarDetalles = CNFactura.FacturaDetEliminar(parametro);

                        // Now create new details based on what's in the grid
                        List<(int id_reserva, DateTime fecha_emision, Decimal importe_total, int descuento)> detallesFactura =
                            new List<(int, DateTime, Decimal, int)>();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Ignorar la fila nueva vacía
                            if (!row.IsNewRow)
                            {
                                int reserva = Convert.ToInt32(row.Cells["id_reserva"].Value);
                                DateTime fecha = Convert.ToDateTime(row.Cells["fecha_creacion"].Value);
                                decimal importe = Convert.ToDecimal(row.Cells["importe_total"].Value);
                                int desc = Convert.ToInt32(row.Cells["descuento"].Value);

                                // Agregar detalle a la lista (without id_detalle, it will be auto-generated in DB)
                                detallesFactura.Add((reserva, fecha, importe, desc));
                            }
                        }

                        // Verificar que haya al menos un detalle
                        if (detallesFactura.Count == 0)
                        {
                            MessageBox.Show("Debe agregar al menos un detalle a la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Update the invoice header
                        string actualizarCabecera = CNFactura.FacturaActualizar(
                            id_factura,
                            id_empleado,
                            id_empresa,
                            metodo_pago,
                            total);

                        // Insert new details
                        string resultado = "";

                        // Insert each detail individually
                        foreach (var detalle in detallesFactura)
                        {
                            string insertarDetalle = CNFactura.FacturaDetInsertar(
                                id_factura,
                                detalle.id_reserva,
                                detalle.fecha_emision,
                                detalle.importe_total,
                                detalle.descuento);

                            resultado += insertarDetalle + "\n";
                        }

                        MessageBox.Show("Factura y detalles actualizados correctamente", "Factura Actualizada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Re-load the invoice to show the changes
                        CargarFactura();
                        BloquearControles(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar la factura: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    List<(int id_reserva, DateTime fecha_emision, Decimal importe_total, int descuento)> detallesFactura = new List<(int, DateTime, Decimal, int)>();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Ignorar la fila nueva vacía
                        if (!row.IsNewRow)
                        {
                            id_reserva = Convert.ToInt32(row.Cells["id_reserva"].Value);
                            fecha_creacion = Convert.ToDateTime(row.Cells["fecha_creacion"].Value);
                            importe_total = Convert.ToInt32(row.Cells["importe_total"].Value);
                            descuento = Convert.ToInt32(row.Cells["descuento"].Value);

                            // Agregar detalle a la lista
                            detallesFactura.Add((id_reserva, fecha_creacion, importe_total, descuento));
                        }
                    }

                    // Verificar que haya al menos un detalle
                    if (detallesFactura.Count == 0)
                    {
                        MessageBox.Show("Debe agregar al menos un detalle a la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int nuevo_id;

                    string insertar = CNFactura.FacturaCompleta(
                        id_empleado,
                        id_empresa,
                        metodo_pago,
                        total,
                        detallesFactura,
                        out nuevo_id
                        );
                    id_factura = nuevo_id; // Asignar el nuevo ID de factura
                    txtfactura.Text = Convert.ToString(nuevo_id);

                    DataTable FacturaConsultar = objFactura.FacturaConsultar(txtfactura.Text);
                    MessageBox.Show(insertar);
                }
            }
            catch
            {
                MessageBox.Show("Error inesperado al guardar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Make sure it's a valid row and not header
                {
                    // Get data from the selected row
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Populate form fields with data from the selected row
                    id_detalle = Convert.ToInt32(row.Cells["id_detalle"].Value);
                    id_reserva = Convert.ToInt32(row.Cells["id_reserva"].Value);
                    txtreserva.Text = id_reserva.ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["fecha_creacion"].Value);
                    txtdescuento.Text = row.Cells["descuento"].Value.ToString();

                    // Load the reservation data based on the id_reserva
                    string parametro = Convert.ToString(id_reserva);
                    CNReserva objReserva = new CNReserva();
                    DataTable dt = objReserva.ReservaConsultar(parametro);

                    if (dt.Rows.Count > 0)
                    {
                        id_cliente = (int)dt.Rows[0]["id_cliente"];
                        id_habitacion = (int)dt.Rows[0]["id_habitacion"];
                        txtprecio_noche.Text = dt.Rows[0]["importe"].ToString();

                        // Load client and room data
                        CargarReserva();

                        // Now the user can edit and update with the "Agregar" button
                        // Change btnagregar text temporarily to indicate it's for updating
                        btnagregar.Text = "Actualizar";
                        btnagregar.Tag = e.RowIndex; // Store row index for later update
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la información de la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataView(int rowIndex)
        {
            try
            {
                if (string.IsNullOrEmpty(txtempleado.Text))
                {
                    MessageBox.Show("Por favor ingrese un código de empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtempleado.Focus();
                    return;
                }

                // Get the current row we're updating
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // Get the current id_detalle from the row (to preserve it)
                int currentDetalle = Convert.ToInt32(row.Cells["id_detalle"].Value);

                // Get updated values from form
                id_reserva = Convert.ToInt32(txtreserva.Text);

                // Check if this reservation ID is already used in another row (excluding the current row)
                bool reservaExisteEnOtraFila = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i != rowIndex &&
                        dataGridView1.Rows[i].Cells["id_reserva"].Value != null &&
                        Convert.ToInt32(dataGridView1.Rows[i].Cells["id_reserva"].Value) == id_reserva)
                    {
                        reservaExisteEnOtraFila = true;
                        break;
                    }
                }

                if (reservaExisteEnOtraFila)
                {
                    MessageBox.Show("El ID de reserva " + id_reserva + " ya existe en la tabla actual. Debe ser único.",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                fecha_creacion = dateTimePicker1.Value;
                decimal precio = Convert.ToDecimal(txtprecio_noche.Text);
                descuento = Convert.ToInt32(txtdescuento.Text);
                importe_total = precio - (precio * descuento / 100);

                // Update the row with new values
                row.Cells["id_detalle"].Value = currentDetalle; // Keep the original id_detalle
                row.Cells["id_reserva"].Value = id_reserva;
                row.Cells["fecha_creacion"].Value = fecha_creacion;
                row.Cells["descuento"].Value = descuento;
                row.Cells["importe_total"].Value = importe_total;

                // Recalculate total
                total = 0;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells["importe_total"].Value != null)
                    {
                        total += Convert.ToDecimal(fila.Cells["importe_total"].Value);
                    }
                }

                // Reset form fields
                Clean();
                txtdescuento.Text = "0";
                txtsubtotal.Text = importe_total.ToString("0.00");
                txttotal.Text = total.ToString("0.00");

                BloquearCliente(false);
                BloquearHabitacion(false);
                BloquearReserva(false);

                MessageBox.Show("Detalle actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton de Agregar al DataGridView
        private void btnagregar_Click(object sender, EventArgs e)
        {
            // Check if we're in update mode
            if (btnagregar.Text == "Actualizar" && btnagregar.Tag != null)
            {
                // We're updating an existing row
                ActualizarDataView(Convert.ToInt32(btnagregar.Tag));

                // Reset button to normal state
                btnagregar.Text = "Agregar";
                btnagregar.Tag = null;
            }
            else
            {
                // We're adding a new row
                AgregarDataView();
            }
        }

        private void AgregarDataView()
        {
            try
            {
                if (string.IsNullOrEmpty(txtempleado.Text))
                {
                    MessageBox.Show("Por favor ingrese un código de empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtempleado.Focus(); // Coloca el foco en el campo de empleado
                    return;
                }

                // Variable que usaremos para el DataGridView
                id_detalle += 1;
                id_reserva = Convert.ToInt32(txtreserva.Text);

                // Verificar si el id_reserva ya existe en el grid
                if (ExisteReservaEnGrid(id_reserva))
                {
                    MessageBox.Show("El ID de reserva " + id_reserva + " ya existe en la tabla actual. Debe ser único.",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salimos del método sin agregar la fila
                }

                // Verificar si el id_reserva ya existe en la base de datos
                if (ExisteReservaEnBaseDatos(id_reserva))
                {
                    MessageBox.Show("El ID de reserva " + id_reserva + " ya está registrado en una factura existente.",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salimos del método sin agregar la fila
                }

                fecha_creacion = dateTimePicker1.Value;
                decimal precio = Convert.ToDecimal(txtprecio_noche.Text);
                descuento = Convert.ToInt32(txtdescuento.Text);
                importe_total = precio - (precio * descuento / 100);


                // Agregamos los valores al DataGridView
                dataGridView1.Rows.Add(id_detalle, id_reserva, fecha_creacion, descuento, importe_total);

                // Reiniciamos el total y lo calculamos correctamente
                total = 0;
                // Foreach para calcular el Total de la Factura
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells["importe_total"].Value != null)
                    {
                        total += Convert.ToDecimal(fila.Cells["importe_total"].Value);
                    }
                }
                Clean();

                // Reseteamos todo
                txtdescuento.Text = "0";
                txtsubtotal.Text = importe_total.ToString("0.00");
                txttotal.Text = total.ToString("0.00");

                BloquearCliente(false);
                BloquearHabitacion(false);
                BloquearReserva(false);
                limpiar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Verificamos si el ID de reserva ya existe en el DataGridView
        private bool ExisteReservaEnGrid(int id_reserva)
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["id_reserva"].Value != null &&
                    Convert.ToInt32(fila.Cells["id_reserva"].Value) == id_reserva)
                {
                    return true;
                }
            }
            return false;
        }

        // Verificamos si el ID de reserva ya existe en la base de datos
        private bool ExisteReservaEnBaseDatos(int id_reserva)
        {
            bool existe = false;

            try
            {
                // Usamos la clase de negocio correspondiente
                CNFactura objFactura = new CNFactura();
                // Consultamos todas las facturas (con NULL se devuelven todas según tu SP)
                DataTable dt = objFactura.FacturaConsultar(null);

                // Buscamos si el id_reserva existe en alguna factura
                foreach (DataRow row in dt.Rows)
                {
                    if (row["id_reserva"] != DBNull.Value &&
                        Convert.ToInt32(row["id_reserva"]) == id_reserva)
                    {
                        existe = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return existe;
        }

        // Boton Borrar Detalle
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // Elimina la última fila (el índice es el conteo total de filas - 1)
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
            else
            {
                MessageBox.Show("No hay filas para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Boton de eliminar
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string parametro = Convert.ToString(id_factura);

                if (string.IsNullOrEmpty(parametro))
                {
                    MessageBox.Show("Por favor, ingrese un ID de Factura", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Está seguro de que desea eliminar la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = CNFactura.FacturaEliminar(parametro);

                    switch (resultado)
                    {
                        case 1:
                            MessageBox.Show("Factura eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 0:
                            MessageBox.Show("La factura no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -1:
                            MessageBox.Show("Error al eliminar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        // Boton de Salir
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FFactura_FormClosing(object sender, FormClosingEventArgs e)
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
