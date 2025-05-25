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
    public partial class FMantenimientoInventario : Form
    {
        int caso;
        private CNInventario objInventario = new CNInventario();
        public FMantenimientoInventario()
        {
            InitializeComponent();
        }

        private void FMantenimientoInventario_Load(object sender, EventArgs e)
        {
            // Cargar el primer departamento
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }
        private void CargarDatos()
        {
            try
            {
                DataTable dt = objInventario.InventarioConsultar(Program.parametro); // Método que devuelve todos los usuarios

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer usuario
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text = fila["id_suministro"].ToString();
                    txtnombre.Text = fila["nombre_suministro"].ToString();
                    txtcantidad.Text = fila["cantidad_suministro"].ToString();
                    txtdescripcion.Text = fila["descripcion_suministro"].ToString();

                    // Para el CheckedListBox, selecciona el estado correspondiente
                    string estado = fila["estado_suministro"].ToString();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, checkedListBox1.Items[i].ToString() == estado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Desmarcamos todos los otros ítems
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index && checkedListBox1.GetItemChecked(i))
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodigo.ReadOnly = bloquear;
            txtnombre.ReadOnly = bloquear;
            txtdescripcion.ReadOnly = bloquear;
            txtcantidad.ReadOnly = bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtnombre.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de usuario
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtcantidad.Text = "";
            txtdescripcion.Text = "";
            checkedListBox1.ClearSelected();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de emepleado
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaInventario fbusquedainventario = new FBusquedaInventario();
            this.Close();
            fbusquedainventario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id_suministro = Convert.ToInt32(txtcodigo.Text);
                int cantidad = Convert.ToInt32(txtcantidad.Text);

                // Obtener el elemento seleccionado del CheckedListBox
                string elementoSeleccionado = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        elementoSeleccionado = checkedListBox1.Items[i].ToString();
                        break;
                    }
                }

                // Si el ID de usuario no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {

                    string actualizar = CNInventario.InventarioActualizar(
                        id_suministro,
                        txtnombre.Text,
                        txtdescripcion.Text,
                        cantidad,
                        elementoSeleccionado
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);
                }

                // Si el ID de usuario está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNInventario.InventarioInsertar(
                        txtnombre.Text,
                        txtdescripcion.Text,
                        cantidad,
                        elementoSeleccionado,
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
                string id_suministro = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_suministro))
                {
                    MessageBox.Show("Por favor, ingrese un ID de Suministro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar el suministro
                if (MessageBox.Show("¿Está seguro de que desea eliminar el suministro con ID " + id_suministro + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNInventario.InventarioEliminar(id_suministro);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Suministro eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El Suministro no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el Suministro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoInventario_FormClosing(object sender, FormClosingEventArgs e)
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
