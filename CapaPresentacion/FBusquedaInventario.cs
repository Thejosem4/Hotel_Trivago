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
    public partial class FBusquedaInventario : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        private bool caso;
        private CNInventario objInventario = new CNInventario();

        public FBusquedaInventario()
        {
            InitializeComponent();
            this.AcceptButton = button3; //Se asigna el botón Aceptar como botón por defecto
        }

        //Evento Load
        private void FBusquedaInventario_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidinventario = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            textBox7.Focus();
        }

        //Boton primer registro
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) //Si no estamos al inicio del DataGridView, vamos al inicio
            {
                indice = 0;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Boton Ultimo
        private void button4_Click(object sender, EventArgs e)
        {
            if (indice < this.dataGridView1.RowCount - 1) //Si no estamos al final del DataGridView
            {
                indice = dataGridView1.Rows.Count - 1; //vamos a la última fila del DataGridView
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Boton siguiente
        private void button3_Click(object sender, EventArgs e)
        {
            if (indice < this.dataGridView1.RowCount - 1) //Si no estamos al final del DataGridView, avanzamos 1 fila
            {
                indice++;
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Boton Anterior
        private void button2_Click(object sender, EventArgs e)
        {
            if (indice > 0) //Si no estamos al inicio del DataGridView, retrocedemos 1 fila
            {
                indice = indice - 1;
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Boton Buscar
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != String.Empty) //Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; //se indica que se trabajará con parámetros

                //Se coloca el signo % para que el dato indicado se busque en cualquier parte del campo
                valorparametro = "%" + textBox7.Text.Trim() + "%";
            }
            else //si el textbox está vacío
            {
                vtieneparametro = 0; //se indica que no se trabajará con parámetros
                valorparametro = ""; //Se vuelve vacío la variable del parámetro.
            }
            MostrarDatos(); //Se llama al método MostrarDatos
        }

        //Boton salir
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close(); //Se cierra el formulario
        }

        //Botón aceptar
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada
                if (dataGridView1.CurrentRow != null)
                {
                    // Obtener el ID de la fila seleccionada
                    Program.vidinventario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Program.parametro = Program.vidinventario.ToString(); //Se asigna el valor a la variable global

                    // Aquí puedes agregar el código para cargar los datos basados en el ID
                    MessageBox.Show("Suministro seleccionado: " + Program.parametro, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si este formulario es un diálogo, puedes cerrarlo con DialogResult.OK
                    this.DialogResult = DialogResult.OK;

                    // Cambiamos el vsalor de caso para que no mandarlo al menu principal
                    caso = true;

                    // Cerrar el formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un suministro de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el suministro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento CurrentCellChanged
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            {
                if (dataGridView1.CurrentRow != null) //Si el DataGridView no está vacío
                    indice = dataGridView1.CurrentRow.Index; //El valor de índice será la fila actual
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

        private void FBusquedaInventario_FormClosing(object sender, FormClosingEventArgs e)
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
                FMantenimientoInventario finventario = new FMantenimientoInventario();
                finventario.Show();
            }
        }

        //boton limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            MostrarDatos(); 
        }

        private void MostrarDatos()
        {
            DataTable InventarioConsultar;

            // Si no se ingresó ningún parámetro, cargar todos los datos
            if (string.IsNullOrWhiteSpace(valorparametro))
            {
                InventarioConsultar = objInventario.InventarioTodo(); // Llama al procedimiento que trae todos los registros
            }
            else
            {
                InventarioConsultar = objInventario.InventarioConsultar(valorparametro); // Llama al procedimiento filtrado
            }

            if (InventarioConsultar != null && InventarioConsultar.Rows.Count > 0)
            {
                // Asigna el DataSource del DataGridView a los datos del método suministroConsultar
                dataGridView1.DataSource = InventarioConsultar; // Se ejecuta el método para mostrar los datos
                dataGridView1.Columns[0].Width = 100; // id_suministro
                dataGridView1.Columns[1].Width = 100; // nombre_depart
                dataGridView1.Columns[2].Width = 100; // descripcion_depart
                dataGridView1.Columns[3].Width = 150; //fecha_creacion
                dataGridView1.Columns[4].Width = 150; // estado_depart
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el parámetro especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataGridView1.Refresh(); // Se refresca el DataGridView
        }
    }
}
