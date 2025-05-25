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
    public partial class FMantenimientoRol : Form
    {
        int caso;
        private CNRol objRol = new CNRol();
        public FMantenimientoRol()
        {
            InitializeComponent();
        }
        private void FMantenimientoRol_Load(object sender, EventArgs e)
        {
            // Cargar el primer rol
            CargarDatos();

            // Bloquear controles inicialmente
            BloquearControles(true);
        }

        private void CargarDatos()
        {
            try
            {
                DataTable dt = objRol.RolConsultar(Program.parametro); // Método que devuelve todos los roles

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer rol
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcodigo.Text = fila["id_rol"].ToString();
                    txtnombre.Text = fila["nombre_rol"].ToString();
                    txtdescripcion.Text = fila["descripcion_rol"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtnombre.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de rol
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcodigo.ReadOnly = true; // No permitir editar el ID de rol
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaRol FBusquedaRol = new FBusquedaRol();
            FBusquedaRol.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Si el ID de rol no está vacío, entonces estamos actualizando
                if (!string.IsNullOrEmpty(txtcodigo.Text))
                {
                    int id_rol = Convert.ToInt32(txtcodigo.Text);

                    string actualizar = CNRol.RolActualizar(
                        id_rol,
                        txtnombre.Text,
                        txtdescripcion.Text
                    );

                    // Mostrar resultado
                    MessageBox.Show(actualizar);
                }
                // Si el ID de rol está vacío, entonces estamos insertando
                else
                {
                    int nuevo_id;

                    string mantenimiento = CNRol.RolInsertar(
                        txtnombre.Text,
                        txtdescripcion.Text,
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
                string id_rol = txtcodigo.Text.Trim();

                if (string.IsNullOrEmpty(id_rol))
                {
                    MessageBox.Show("Por favor, ingrese un ID de rol", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar el rol
                if (MessageBox.Show("¿Está seguro de que desea eliminar el rol con ID " + id_rol + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }
                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNRol.RolEliminar(id_rol);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Rol eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El rol no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Crear y mostrar el formulario principal
            FMenuMantenimiento formPrincipal = new FMenuMantenimiento();

            // Cierra este formulario de login en lugar de cerrarlo
            this.Close();
            formPrincipal.Show();
        }

        private void FMantenimientoRol_FormClosing(object sender, FormClosingEventArgs e)
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
