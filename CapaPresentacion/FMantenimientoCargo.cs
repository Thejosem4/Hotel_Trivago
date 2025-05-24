using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FMantenimientoCargo : Form
    {
        private CNCargo objCargo = new CNCargo();
        int caso;
        public FMantenimientoCargo()
        {
            InitializeComponent();
        }

        private void FMantenimientoCargo_Load(object sender, EventArgs e)
        {
            // Cargar el primer cargo
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = objCargo.CargoConsultar(Program.parametro); // Método que devuelve todos los cargos

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer cargo
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text = fila["id_cargo"].ToString();
                    txtnombre.Text = fila["nombre_cargo"].ToString();
                    txtdescripcion.Text = fila["descripcion_cargo"].ToString();

                    // Para el CheckedListBox, selecciona el estado correspondiente
                    string estado = fila["estado_cargo"].ToString();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, checkedListBox1.Items[i].ToString() == estado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtdescripcion.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de cargo
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            checkedListBox1.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de cargo
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaCargo FBusquedaCargo = new FBusquedaCargo();
            this.Close();
            FBusquedaCargo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
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

                // Si el ID de cargo no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    int id_cargo = Convert.ToInt32(txtcodigo.Text);

                    string actualizar = CNCargo.CargoActualizar(
                        id_cargo,
                        txtnombre.Text,
                        txtdescripcion.Text,
                        elementoSeleccionado
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);
                }
                // Si el ID de cargo está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNCargo.CargoInsertar(
                        txtnombre.Text,
                        txtdescripcion.Text,
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
                string id_cargo = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_cargo))
                {
                    MessageBox.Show("Por favor, ingrese un ID de cargo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Está seguro de que desea eliminar el cargo con ID " + id_cargo + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }

                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNCargo.CargoEliminar(id_cargo);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Cargo eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El cargo no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoCargo_FormClosing(object sender, FormClosingEventArgs e)
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
