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
    public partial class FMantenimientoHabitacion : Form
    {
        int caso;
        private CNHabitacion objHabitacion = new CNHabitacion();

        public FMantenimientoHabitacion()
        {
            InitializeComponent();
        }
        private void FMantenimientoHabitacion_Load(object sender, EventArgs e)
        {
            // Cargar la primera habitación
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }
        private void CargarDatos()
        {
            try
            {
                DataTable dt = objHabitacion.HabitacionConsultar(Program.parametro); // Método que devuelve todas las habitaciones

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos de la primera habitación
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text = fila["id_habitacion"].ToString();
                    txtcapacidad.Text = fila["capacidad"].ToString();
                    txttipo.Text = fila["tipo_habitacion"].ToString();
                    txtdescripcion.Text = fila["descripcion_hab"].ToString();
                    txtprecio.Text = fila["precio"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la habitación : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodigo.ReadOnly = bloquear;
            txtcapacidad.ReadOnly = bloquear;
            txttipo.ReadOnly = bloquear;
            txtdescripcion.ReadOnly = bloquear;
            txtprecio.ReadOnly = bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txttipo.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de habitación
            txtcodigo.Text = "";
            txtcapacidad.Text = "";
            txttipo.Text = "";
            txtdescripcion.Text = "";
            txtprecio.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de habitación
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaHabitacion FBusquedaHabitacion = new FBusquedaHabitacion();
            this.Close();
            FBusquedaHabitacion.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int capacidad = Convert.ToInt32(txtcapacidad.Text);
                decimal precio = Convert.ToDecimal(txtprecio.Text);

                // Si el ID de habitación no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    int id_habitacion = Convert.ToInt32(txtcodigo.Text);

                    string actualizar = CNHabitacion.HabitacionActualizar(
                     id_habitacion,
                     capacidad,
                     txttipo.Text,
                     txtdescripcion.Text,
                     precio
                     );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);

                }

                // Si el ID de habitación está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNHabitacion.HabitacionInsertar(
                     capacidad,
                     txttipo.Text,
                     txtdescripcion.Text,
                     precio,
                     out nuevo_id
                    );
                    txtcodigo.Text = Convert.ToString(nuevo_id);
                    // Mostrar resultado
                    MessageBox.Show(mantenimiento);
                    if (Program.managersalida == true)
                    {
                        Program.vidhabitacion = nuevo_id;
                        Program.controlmov = 2;
                        this.Close();
                    }
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
                string id_habitacion = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_habitacion))
                {
                    MessageBox.Show("Por favor, ingrese un ID de habitación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar la habitación
                if (MessageBox.Show("¿Está seguro de que desea eliminar el habitación con ID " + id_habitacion + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNHabitacion.HabitacionEliminar(id_habitacion);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Habitación eliminada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("La habitación no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar la habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoHabitacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == 1)
            {
                // Si el caso es 1, no se muestra el mensaje de advertencia
            }
            else
            {
                if (Program.managersalida == true)
                {
                    // Asegurarse de que el formulario se cierre (no cancelar el cierre)
                    e.Cancel = false;

                    // Mostrar mensaje informativo
                    MessageBox.Show("Volviendo a la Factura...",
                                   "Mensaje de Hotel Trivago",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    FFactura ffactura = new FFactura();
                    ffactura.Show();
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
}
