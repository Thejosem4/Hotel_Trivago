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
    public partial class FBusquedaInv_Suministro : Form
    {      
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        private bool caso;
        private CNInventario_Suministro objInventario_Suministro = new CNInventario_Suministro();

        public FBusquedaInv_Suministro()
        {
            InitializeComponent();
            this.AcceptButton = button3; //Se asigna el botón Aceptar como botón por defecto
        }

        //Evento Load
        private void FBusquedaInv_Suministro_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidinv_suministro = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            textBox7.Focus(); //El TextBox Buscar recibe el cursor

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (indice < this.dataGridView1.RowCount - 1)
            {
                indice = dataGridView1.Rows.Count - 1;
                dataGridView1.CurrentCell =

                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                if (indice < this.dataGridView1.RowCount - 1)
                {
                    indice++;

                    dataGridView1.CurrentCell =

                    dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                if (indice > 0)
                {
                    indice = indice - 1;
                    dataGridView1.CurrentCell =
                    dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
                }
            }
        }

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
        //boton salir
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //boton aceptar
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada
                if (dataGridView1.CurrentRow != null)
                {
                    // Obtener el ID de la fila seleccionada
                    Program.vidinv_suministro = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Program.parametro = Program.vidinv_suministro.ToString(); //Se asigna el valor a la variable global

                    // Aquí puedes agregar el código para cargar los datos basados en el ID
                    MessageBox.Show("Cliente seleccionado: " + Program.parametro, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si este formulario es un diálogo, puedes cerrarlo con DialogResult.OK
                    this.DialogResult = DialogResult.OK;

                    // Cambiamos el vsalor de caso para que no mandarlo al menu principal
                    caso = true;

                    // Cerrar el formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un cliente de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) //Si no estamos al inicio del DataGridView, vamos al inicio
            {
                indice = 0;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        private void FBusquedaInv_Suministro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (caso == false)
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
            else
            {
                FMantenimientoHabitacion fhabitacion = new FMantenimientoHabitacion();
                fhabitacion.Show();
            }
        }

        //boton limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            MostrarDatos();
        }

        // Método MostrarDatos
        private void MostrarDatos()
        {
            DataTable Inventario_SuministroConsultar;

            // Si no se ingresó ningún parámetro, cargar todos los datos
            if (string.IsNullOrWhiteSpace(valorparametro))
            {
                Inventario_SuministroConsultar = objInventario_Suministro.Inventario_SuministroTodo(); // Llama al procedimiento que trae todos los registros
            }
            else
            {
                Inventario_SuministroConsultar = objInventario_Suministro.Inventario_SuministroConsultar(valorparametro); // Llama al procedimiento filtrado
            }


            if (Inventario_SuministroConsultar != null && Inventario_SuministroConsultar.Rows.Count > 0)
            {
                dataGridView1.DataSource = Inventario_SuministroConsultar;

                dataGridView1.Columns[0].Width = 60; // Ancho de la columna ID Cliente
                dataGridView1.Columns[1].Width = 150; // Ancho de la columna Nombre
                dataGridView1.Columns[2].Width = 150; // Ancho de la columna Apellido
                dataGridView1.Columns[3].Width = 100; // Ancho de la columna Cédula
                dataGridView1.Columns[4].Width = 150; // Ancho de la columna Dirección
                dataGridView1.Columns[5].Width = 100; // Ancho de la columna Teléfono
                dataGridView1.Columns[6].Width = 150; // Ancho de la columna Email
                dataGridView1.Columns[7].Width = 100; // Ancho de la columna Fecha Registro
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el parámetro especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataGridView1.Refresh(); // Se refresca el DataGridView 
        }
    }

}