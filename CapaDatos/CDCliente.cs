using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCliente
    {
        private int did_cliente;
        private string dnombre_cliente, dapellido_cliente, dtelefono_cliente, demail_cliente, ddireccion_cliente, dcedula_cliente;
        private DateTime dfecha_registro;

        public CDCliente() { }

        public CDCliente(int pid_cliente, string pnombre_cliente, string papellido_cliente, string ptelefono_cliente,
            string pemail_cliente, string pdireccion_cliente, string pcedula_cliente, DateTime pfecha_registro)
        {
            did_cliente = pid_cliente;
            dnombre_cliente = pnombre_cliente;
            dapellido_cliente = papellido_cliente;
            dtelefono_cliente = ptelefono_cliente;
            demail_cliente = pemail_cliente;
            ddireccion_cliente = pdireccion_cliente;
            dcedula_cliente = pcedula_cliente;
            dfecha_registro = pfecha_registro;
        }

        #region Métodos Get y Set
        public int id_cliente { 
          get => did_cliente; 
          set => did_cliente = value; 
        }
        public string nombre_cliente { 
          get => dnombre_cliente; 
          set => dnombre_cliente = value; 
        }
        public string apellido_cliente { 
          get => dapellido_cliente; 
          set => dapellido_cliente = value; 
        }
        public string telefono_cliente {
          get => dtelefono_cliente;
          set => dtelefono_cliente = value; 
        }
        public string email_cliente { 
          get => demail_cliente; 
          set => demail_cliente = value; 
        }
        public string direccion_cliente {
          get => ddireccion_cliente; 
          set => ddireccion_cliente = value;
        }
        public string cedula_cliente { 
          get => dcedula_cliente; 
          set => dcedula_cliente = value;
        }
        public DateTime fecha_registro { 
          get => dfecha_registro; 
          set => dfecha_registro = value; 
        }
        #endregion

        public string ClienteInsertar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("ClienteInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_cliente", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pnombre_cliente", objCliente.nombre_cliente);
                micomando.Parameters.AddWithValue("@papellido_cliente", objCliente.apellido_cliente);
                micomando.Parameters.AddWithValue("@ptelefono_cliente", objCliente.telefono_cliente);
                micomando.Parameters.AddWithValue("@pemail_cliente", objCliente.email_cliente);
                micomando.Parameters.AddWithValue("@pdireccion_cliente", objCliente.direccion_cliente);
                micomando.Parameters.AddWithValue("@pcedula_cliente", objCliente.cedula_cliente);
                micomando.Parameters.AddWithValue("@pfecha_registro", objCliente.fecha_registro);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objCliente.id_cliente = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objCliente.id_cliente; // Formato especial para identificar éxito con ID
                }
                else
                {
                    mensaje = "Error: No se pudo obtener el ID del cliente.";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        public string ClienteActualizar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("ClienteActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_cliente", objCliente.id_cliente);
                micomando.Parameters.AddWithValue("@pnombre_cliente", objCliente.nombre_cliente);
                micomando.Parameters.AddWithValue("@papellido_cliente", objCliente.apellido_cliente);
                micomando.Parameters.AddWithValue("@ptelefono_cliente", objCliente.telefono_cliente);
                micomando.Parameters.AddWithValue("@pemail_cliente", objCliente.email_cliente);
                micomando.Parameters.AddWithValue("@pdireccion_cliente", objCliente.direccion_cliente);
                micomando.Parameters.AddWithValue("@pcedula_cliente", objCliente.cedula_cliente);
                micomando.Parameters.AddWithValue("@pfecha_registro", objCliente.fecha_registro);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Cliente actualizado correctamente!" : "Error al actualizar cliente.";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        public DataTable ClienteConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "ClienteConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_cliente", miparametro);
                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable ClienteTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "ClienteTodo"; // Nombre del procedimiento almacenado
                sqlCmd.CommandType = CommandType.StoredProcedure;

                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public int ClienteEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("ClienteEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_cliente", miparametro);

                        // Capturar el valor de retorno
                        SqlParameter returnParameter = sqlCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        sqlCmd.ExecuteNonQuery();

                        // Obtener el valor de retorno
                        resultado = (int)returnParameter.Value;
                    }
                }
            }
            catch (Exception)
            {
                resultado = -1; // Error en la operación
            }
            return resultado;
        }
    }
}
