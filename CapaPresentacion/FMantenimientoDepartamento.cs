using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FMantenimientoDepartamento : Form
    {
        int caso;
        public FMantenimientoDepartamento()
        {
            InitializeComponent();
        }

        private void FMantenimientoDepartamento_Load(object sender, EventArgs e)
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
                CNDepartamento objDepartamento = new CNDepartamento();
                DataTable dt = objDepartamento.DepartamentoConsultar(Program.parametro); // Método que devuelve todos los departamentos

                if (dt.Rows.Count > 0)
                {
                    // Obtener datos del primer departamento
                    DataRow fila = dt.Rows[0];

                    // Mostrar los datos en los controles
                    txtcoddepartamento.Text = fila["id_departamento"].ToString();
                    txtnombre_depart.Text = fila["nombre_depart"].ToString();
                    txtdescripcion_depart.Text = fila["descripcion_depart"].ToString();
                    dateTimePicker2.Value = Convert.ToDateTime(fila["fecha_creacion"]);

                    // Para el estado, seleccionamos el elemento correspondiente en checkedListBox1
                    string estado = fila["estado_depart"].ToString();
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, checkedListBox1.Items[i].ToString() == estado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtcoddepartamento.ReadOnly = bloquear;
            txtnombre_depart.ReadOnly = bloquear;
            txtdescripcion_depart.ReadOnly = bloquear;
            dateTimePicker2.Enabled = !bloquear;
            checkedListBox1.Enabled = !bloquear;

            button1.Enabled = bloquear; // Habilitar Nuevo cuando los controles están bloqueados
            button4.Enabled = !bloquear; // Habilitar Guardar cuando los controles están desbloqueados
            if (txtnombre_depart.Text == string.Empty)
            {
                button2.Enabled = !bloquear;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcoddepartamento.ReadOnly = true; // No permitir editar el ID de departamento
            txtcoddepartamento.Text = "";
            txtnombre_depart.Text = "";
            txtdescripcion_depart.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtcoddepartamento.ReadOnly = true; // No permitir editar el ID de departamento
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caso = 1;
            FBusquedaDepartamento fBusquedaDepartamento = new FBusquedaDepartamento();
            this.Close();
            fBusquedaDepartamento.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CNDepartamento objDepartamento = new CNDepartamento();

            DateTime fechaCreacion = dateTimePicker2.Value;

            // Obtener el estado seleccionado del checkedListBox1
            string elementoSeleccionado = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    elementoSeleccionado = checkedListBox1.Items[i].ToString();
                    break;
                }
            }

            // Si el ID de departamento no está vacío, entonces estamos actualizando
            if (!string.IsNullOrEmpty(txtcoddepartamento.Text))
            {
                int id_departamento = Convert.ToInt32(txtcoddepartamento.Text);

                string actualizar = CNDepartamento.DepartamentoActualizar(
                    id_departamento,
                    txtnombre_depart.Text,
                    txtdescripcion_depart.Text,
                    elementoSeleccionado,
                    fechaCreacion
                );

                // Mostrar resultado
                MessageBox.Show(actualizar);
            }
            // Si el ID de departamento está vacío, entonces estamos insertando
            else
            {
                int nuevo_id;
                string mantenimiento = CNDepartamento.DepartamentoInsertar(
                    txtnombre_depart.Text,
                    txtdescripcion_depart.Text,
                    elementoSeleccionado,
                    fechaCreacion,
                    out nuevo_id
                );
                txtcoddepartamento.Text = Convert.ToString(nuevo_id);
                // Mostrar resultado
                MessageBox.Show(mantenimiento);
            }

            BloquearControles(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id_departamento = txtcoddepartamento.Text.Trim();

                if (string.IsNullOrEmpty(id_departamento))
                {
                    MessageBox.Show("Por favor, ingrese un ID de departamento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Preguntar al usuario si está seguro de eliminar el departamento
                if (MessageBox.Show("¿Está seguro de que desea eliminar el departamento con ID " + id_departamento + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; // Si el usuario selecciona "No", salir del método
                }

                // Usar el nombre de la clase en lugar de la instancia
                int resultado = CNDepartamento.DepartamentoEliminar(id_departamento);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("Departamento eliminado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("El departamento no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -1:
                        MessageBox.Show("Error al eliminar el departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FMantenimientoDepartamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(caso == 1)
            {
                // Si el caso es 1, no se muestra el mensaje de advertencia
            }
            else {
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