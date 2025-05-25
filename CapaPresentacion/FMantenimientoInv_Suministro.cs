using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FMantenimientoInv_Suministro : Form
    {
        int caso;
        CNInventario_Suministro objSuministro = new CNInventario_Suministro();
        public FMantenimientoInv_Suministro()
        {
            InitializeComponent();
        }

        private void FMantenimientoInv_Suministro_Load(object sender, EventArgs e)
        {
            // Cargar el primer suministro
            CargarDatos();
            // Bloquear controles inicialmente
            BloquearControles(true);
        }
        private void CargarDatos()
        {
            try
            {
                DataTable dt = objSuministro.Inventario_SuministroConsultar(Program.parametro); // Método que devuelve todos los Movimientos

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer Movimiento
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodmovimiento.Text = fila["id_movimiento"].ToString();
                    txtcodhabitacion.Text = fila["id_habitacion"].ToString();
                    txtsuministro.Text = fila["id_suministro"].ToString();
                    txtcantidad.Text = fila["cantidad_movimiento"].ToString();
                    txttipo.Text = fila["tipo_movimiento"].ToString();

                    // Para la fecha, asegúrate de convertirla correctamente
                    dateTimePicker1.Value = Convert.ToDateTime(fila["fecha_movimiento"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodmovimiento.Enabled = bloquear;
            txtcodhabitacion.ReadOnly = bloquear;
            txtsuministro.ReadOnly = bloquear;
            txtcantidad.ReadOnly = bloquear;
            txttipo.ReadOnly = bloquear;
            dateTimePicker1.Enabled = !bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtcantidad.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodmovimiento.Enabled = false; // No permitir editar el ID de Movimiento
            txtcodmovimiento.Text = "";
            txtcodhabitacion.Text = "";
            txtsuministro.Text = "";
            txtcantidad.Text = "";
            txttipo.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodmovimiento.ReadOnly = true; // No permitir editar el ID de Movimiento
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaInv_Suministro fBusquedaMovimiento = new FBusquedaInv_Suministro();
            this.Close();
            fBusquedaMovimiento.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id_habitacion = Convert.ToInt32(txtcodhabitacion.Text);
                int id_suministro = Convert.ToInt32(txtsuministro.Text);
                int cantidad_movimiento = Convert.ToInt32(txtcantidad.Text);

                DateTime fechaRegistro = dateTimePicker1.Value;

                // Si el ID de Movimiento no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodmovimiento.Text))
                {

                    int id_movimiento = Convert.ToInt32(txtcodmovimiento.Text);

                    string actualizar = CNInventario_Suministro.Inventario_SuministroActualizar(
                        id_movimiento,
                        id_habitacion,
                        id_suministro,
                        txttipo.Text,
                        cantidad_movimiento,
                        fechaRegistro
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);

                }

                // Si el ID de Movimiento está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNInventario_Suministro.Inventario_SuministroInsertar(
                        id_habitacion,
                        id_suministro,
                        txttipo.Text,
                        cantidad_movimiento,
                        fechaRegistro,
                        out nuevo_id
                    );
                    txtsuministro.Text = Convert.ToString(nuevo_id);
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
                string id_movimiento = txtcodmovimiento.Text.Trim();

                if (string.IsNullOrEmpty(id_movimiento))
                {
                    MessageBox.Show("Por favor, ingrese un ID de Movimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de que desea eliminar el movimiento
                if (MessageBox.Show("¿Está seguro de que desea eliminar el movimiento con ID " + id_movimiento + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNInventario_Suministro.Inventario_SuministroEliminar(id_movimiento);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Movimiento eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El Movimiento no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el Movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoInv_Suministro_FormClosing(object sender, FormClosingEventArgs e)
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
                }

                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
