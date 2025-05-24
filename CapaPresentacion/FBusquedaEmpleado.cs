using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FBusquedaEmpleado : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public bool caso;
        private CNEmpleado cNEmpleado = new CNEmpleado();

        public FBusquedaEmpleado()
        {
            InitializeComponent();
            this.AcceptButton = button3; //Se asigna el botón Aceptar como botón por defecto
        }
        //Evento Load
        private void FBusquedaEmpleado_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidempleado = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            textBox1.Focus(); //El TextBox Buscar recibe el cursor
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
            if (textBox1.Text != String.Empty) //Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; //se indica que se trabajará con parámetros

                //Se coloca el signo % para que el dato indicado se busque en cualquier parte del campo
                valorparametro = "%" + textBox1.Text.Trim() + "%";
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
                    Program.vidempleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    Program.parametro = Program.vidempleado.ToString(); //Se asigna el valor a la variable global

                    // Aquí puedes agregar el código para cargar los datos basados en el ID
                    MessageBox.Show("Empleado seleccionado: " + Program.parametro, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si este formulario es un diálogo, puedes cerrarlo con DialogResult.OK
                    this.DialogResult = DialogResult.OK;

                    // Cambiamos el vsalor de caso para que no mandarlo al menu principal
                    caso = true;

                    // Cerrar el formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un empleado de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FBusquedaEmpleado_FormClosing(object sender, FormClosingEventArgs e)
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
                FMantenimientoEmpleado fempleado = new FMantenimientoEmpleado();
                fempleado.Show();
            }
        }
        
        //boton limpiar
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            MostrarDatos();
        }

        // Método MostrarDatos
        private void MostrarDatos()
        {
            DataTable EmpleadoConsultar;

            // Si no se ingresó ningún parámetro, cargar todos los datos
            if (string.IsNullOrWhiteSpace(valorparametro))
            {
                EmpleadoConsultar = cNEmpleado.EmpleadoTodo(); // Llama al procedimiento que trae todos los registros
            }
            else
            {
                EmpleadoConsultar = cNEmpleado.EmpleadoConsultar(valorparametro); // Llama al procedimiento filtrado
            }

            if (EmpleadoConsultar != null && EmpleadoConsultar.Rows.Count > 0)
            {
                // Asigna el DataSource del DataGridView a los datos del método EmpleadoConsultar
                dataGridView1.DataSource = EmpleadoConsultar; // Se ejecuta el método para mostrar los datos

                // Opcional: Configurar ancho de columnas si lo necesitas
                dataGridView1.Columns[0].Width = 100; // id_empleado
                dataGridView1.Columns[1].Width = 100; // id_cargo
                dataGridView1.Columns[2].Width = 100; // id_departamento
                dataGridView1.Columns[3].Width = 150; // nombre_empleado
                dataGridView1.Columns[4].Width = 150; // apellido_empleado
                dataGridView1.Columns[5].Width = 150; // cedula_empleado
                dataGridView1.Columns[6].Width = 150; // telefono_empleado
                dataGridView1.Columns[7].Width = 150; // correo_empleado
                dataGridView1.Columns[8].Width = 150; // fecha_contratacion
                dataGridView1.Columns[9].Width = 150; // fecha_nac
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el parámetro especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataGridView1.Refresh(); // Se refresca el DataGridView
        }
    }
}
