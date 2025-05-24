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
    public partial class FBusquedaCliente : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        private bool caso;
        private CNCliente objCliente = new CNCliente();

        public FBusquedaCliente()
        {
            InitializeComponent();
            this.AcceptButton = button3; //Se asigna el botón Aceptar como botón por defecto
        }

        //Botón primero
        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) //Si no estamos al inicio del DataGridView, vamos al inicio
            {
                indice = 0;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón último
        private void button4_Click(object sender, EventArgs e)
        {
            if (indice < this.dataGridView1.RowCount - 1) //Si no estamos al final del DataGridView
            {
                indice = dataGridView1.Rows.Count - 1; //vamos a la última fila del DataGridView
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón siguiente
        private void button6_Click(object sender, EventArgs e)
        {
            if (indice < this.dataGridView1.RowCount - 1) //Si no estamos al final del DataGridView, avanzamos 1 fila
            {
                indice++;
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
            }
        }

        //Botón anterior
        private void button7_Click(object sender, EventArgs e)
        {
            if (indice > 0) //Si no estamos al inicio del DataGridView, retrocedemos 1 fila
            {
                indice = indice - 1;
                dataGridView1.CurrentCell =
                dataGridView1.Rows[indice].Cells[dataGridView1.CurrentCell.ColumnIndex];
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

        //Evento Load
        private void FBusquedaCliente_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidcliente = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            textBox7.Focus(); //El TextBox Buscar recibe el cursor
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
                    Program.vidcliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Program.parametro = Program.vidcliente.ToString(); //Se asigna el valor a la variable global

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

        private void FBusquedaCliente_FormClosing(object sender, FormClosingEventArgs e)
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
                FMantenimiento_Cliente fcliente = new FMantenimiento_Cliente();
                fcliente.Show();
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
            DataTable ClienteConsultar;

            // Si no se ingresó ningún parámetro, cargar todos los datos
            if (string.IsNullOrWhiteSpace(valorparametro))
            {
                ClienteConsultar = objCliente.ClienteTodo(); // Llama al procedimiento que trae todos los registros
            }
            else
            {
                ClienteConsultar = objCliente.ClienteConsultar(valorparametro); // Llama al procedimiento filtrado
            }

            if (ClienteConsultar != null && ClienteConsultar.Rows.Count > 0)
            {
                dataGridView1.DataSource = ClienteConsultar;

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
