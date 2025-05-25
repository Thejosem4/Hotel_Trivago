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
    public partial class FMantenimientoUsuario : Form
    {
        int caso;
        private CNUsuario objUsuario = new CNUsuario();
        public FMantenimientoUsuario()
        {
            InitializeComponent();
        }

        private void FMantenimientoUsuario_Load(object sender, EventArgs e)
        {
            // Cargar el primer usuario
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }
        private void CargarDatos()
        {
            try
            {
                DataTable dt = objUsuario.UsuarioConsultar(Program.parametro); // Método que devuelve todos los usuarios

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer usuario
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodusuario.Text = fila["id_usuario"].ToString();
                    txtcodempleado.Text = fila["id_empleado"].ToString();
                    txtcodrol.Text = fila["id_rol"].ToString();
                    txtnombre.Text = fila["nombre"].ToString();
                    txtclave.Text = fila["clave"].ToString();

                    // Para la fecha, asegúrate de convertirla correctamente
                    dateTimePicker1.Value = Convert.ToDateTime(fila["fecha_registro"]);

                    // Para el CheckedListBox, selecciona el estado correspondiente
                    string estado = fila["estado_usuario"].ToString();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, checkedListBox1.Items[i].ToString() == estado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles(bool bloquear)
        {
            // Bloquear o desbloquear controles según el parámetro
            txtcodusuario.ReadOnly = bloquear;
            txtcodempleado.ReadOnly = bloquear;
            txtcodrol.ReadOnly = bloquear;
            txtnombre.ReadOnly = bloquear;
            txtclave.ReadOnly = bloquear;
            dateTimePicker1.Enabled = !bloquear;
            checkedListBox1.Enabled = !bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtcodempleado.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id_emmpleado = Convert.ToInt32(txtcodempleado.Text);
                int id_rol = Convert.ToInt32(txtcodrol.Text);

                DateTime fechaRegistro = dateTimePicker1.Value;

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
                if (!string.IsNullOrEmpty(txtcodusuario.Text))
                {

                    int id_usuario = Convert.ToInt32(txtcodusuario.Text);

                    string actualizar = CNUsuario.UsuarioActualizar(
                        id_usuario,
                        id_emmpleado,
                        id_rol,
                        txtnombre.Text,
                        txtclave.Text,
                        fechaRegistro,
                        elementoSeleccionado
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);

                }

                // Si el ID de usuario está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;
                    string mantenimiento = CNUsuario.UsuarioInsertar(
                        id_emmpleado,
                        id_rol,
                        txtnombre.Text,
                        txtclave.Text,
                        fechaRegistro,
                        elementoSeleccionado,
                        out nuevo_id
                    );
                    txtcodusuario.Text = Convert.ToString(nuevo_id);
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


        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaUsuario fBusquedaUsuario = new FBusquedaUsuario();
            this.Close();
            fBusquedaUsuario.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodusuario.Enabled = false; // No permitir editar el ID de usuario
            txtcodusuario.Text = "";
            txtcodempleado.Text = "";
            txtcodrol.Text = "";
            txtnombre.Text = "";
            txtclave.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            checkedListBox1.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodusuario.ReadOnly = true; // No permitir editar el ID de usuario
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id_usuario = txtcodusuario.Text.Trim();

                if (string.IsNullOrEmpty(id_usuario))
                {
                    MessageBox.Show("Por favor, ingrese un ID de usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar el usuario
                if (MessageBox.Show("¿Está seguro de que desea eliminar el usuario con ID " + id_usuario + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNUsuario.UsuarioEliminar(id_usuario);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Usuario eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El usuario no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoUsuario_FormClosing(object sender, FormClosingEventArgs e)
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