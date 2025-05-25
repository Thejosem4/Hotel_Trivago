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
    public partial class FBusquedaRol : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        private bool caso;
        private CNRol objRol = new CNRol();

        public FBusquedaRol()
        {
            InitializeComponent();
            this.AcceptButton = button3; //Se asigna el botón Aceptar como botón por defecto
        }

        //Evento Load
        private void Rol_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidrol = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            textBox7.Focus(); //El TextBox Buscar recibe el cursor
        }

        //Botón primero
        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                indice = 0;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón último
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                indice = dataGridView1.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón siguiente
        private void button6_Click(object sender, EventArgs e)
        {
            if (indice < dataGridView1.RowCount - 1)
            {
                indice++;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón anterior
        private void button7_Click(object sender, EventArgs e)
        {
            if (indice > 0)
            {
                indice--;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón buscar
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != String.Empty) //Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; //se indica que se trabajará con parámetros

                //Se coloca el signo % para que el dato indicado se busque en cualquier parte del campo
                valorparametro = textBox7.Text.Trim();
            }
            else //si el textbox está vacío
            {
                vtieneparametro = 0; //se indica que no se trabajará con parámetros
                valorparametro = ""; //Se vuelve vacío la variable del parámetro.
            }
            MostrarDatos(); //Se llama al método MostrarDatos
        }

        //Botón salir
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Botón aceptar
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    Program.vidrol = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Program.parametro = Program.vidrol.ToString();
                    MessageBox.Show("Rol seleccionado: " + Program.parametro, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;

                    // Cambiamos el vsalor de caso para que no mandarlo al menu principal
                    caso = true;

                    // Cerrar el formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un rol de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento CurrentCellChanged
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                indice = dataGridView1.CurrentRow.Index;
        }

        //Evento CellDoubleClick
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si se pulsa en el encabezado, RowIndex será menor que cero y no se hará nada
            if (!(e.RowIndex > -1))
            {
                return;
            }
            button5_Click(sender, e); //Se ejecuta el método del botón Aceptar
        }

        private void FBusquedaRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == false)
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
            else
            {
                FMantenimientoRol frol = new FMantenimientoRol();
                frol.Show();
            }
        }

        //bton limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            MostrarDatos();
        }

        // Método MostrarDatos
        private void MostrarDatos()
        {
            DataTable RolConsultar;

            // Si no se ingresó ningún parámetro, cargar todos los datos
            if (string.IsNullOrWhiteSpace(valorparametro))
            {
                RolConsultar = objRol.RolTodo(); // Llama al procedimiento que trae todos los registros
            }
            else
            {
                RolConsultar = objRol.RolConsultar(valorparametro); // Llama al procedimiento filtrado
            }

            if (RolConsultar != null && RolConsultar.Rows.Count > 0)
            {
                dataGridView1.DataSource = RolConsultar;
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[0].HeaderText = "ID Rol";
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Descripción";
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el parámetro especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.DataSource = null;
            }
            dataGridView1.Refresh();
        }
    }
}
