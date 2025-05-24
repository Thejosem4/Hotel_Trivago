using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDEmpleado
    {
        private int did_empleado, did_cargo, did_departamento;
        private string dnombre_empleado, dapellido_empleado, dcedula_empleado, dtelefono_empleado, dcorreo_empleado, destado_empleado;
        private DateTime dfecha_contratacion, dfecha_nac;
        private decimal dsalario;

        public CDEmpleado() { }

        public CDEmpleado(int pid_empleado, int pid_cargo, int pid_departamento, string pnombre_empleado, string papellido_empleado, string pcedula_empleado, string ptelefono_empleado,
            string pcorreo_empleado, DateTime pfecha_contratacion, DateTime pfecha_nac, decimal psalario, string pestado_empleado)
        {
            did_empleado = pid_empleado;
            did_cargo = pid_cargo;
            did_departamento = pid_departamento;
            dnombre_empleado = pnombre_empleado;
            dapellido_empleado = papellido_empleado;
            dcedula_empleado = pcedula_empleado;
            dtelefono_empleado = ptelefono_empleado;
            dcorreo_empleado = pcorreo_empleado;
            dfecha_contratacion = pfecha_contratacion;
            dfecha_nac = pfecha_nac;
            dsalario = psalario;
            destado_empleado = pestado_empleado;
        }

        #region Métodos Get y Set 
        public int id_empleado
        {
            get { return did_empleado; }
            set { did_empleado = value; }
        }
        public int id_cargo
        {
            get { return did_cargo; }
            set { did_cargo = value; }
        }
        public int id_departamento
        {
            get { return did_departamento; }
            set { did_departamento = value; }
        }
        public string nombre_empleado
        {
            get { return dnombre_empleado; }
            set { dnombre_empleado = value; }
        }
        public string apellido_empleado
        {
            get { return dapellido_empleado; }
            set { dapellido_empleado = value; }
        }
        public string cedula_empleado
        {
            get { return dcedula_empleado; }
            set { dcedula_empleado = value; }
        }
        public string telefono_empleado
        {
            get { return dtelefono_empleado; }
            set { dtelefono_empleado = value; }
        }
        public string correo_empleado
        {
            get { return dcorreo_empleado; }
            set { dcorreo_empleado = value; }
        }
        public DateTime fecha_contratacion
        {
            get { return dfecha_contratacion; }
            set { dfecha_contratacion = value; }
        }
        public DateTime fecha_nac
        {
            get { return dfecha_nac; }
            set { dfecha_nac = value; }
        }
        public decimal salario
        {
            get { return dsalario; }
            set { dsalario = value; }
        }
        public string estado_empleado
        {
            get { return destado_empleado; }
            set { destado_empleado = value; }
        }
        #endregion

        public string EmpleadoInsertar(CDEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_empleado", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);
                
                micomando.Parameters.AddWithValue("@pid_cargo", objEmpleado.id_cargo);
                micomando.Parameters.AddWithValue("@pid_departamento", objEmpleado.id_departamento);
                micomando.Parameters.AddWithValue("@pnombre_empleado", objEmpleado.nombre_empleado);
                micomando.Parameters.AddWithValue("@papellido_empleado", objEmpleado.apellido_empleado);
                micomando.Parameters.AddWithValue("@pcedula_empleado", objEmpleado.cedula_empleado);
                micomando.Parameters.AddWithValue("@ptelefono_empleado", objEmpleado.telefono_empleado);
                micomando.Parameters.AddWithValue("@pcorreo_empleado", objEmpleado.correo_empleado);
                micomando.Parameters.AddWithValue("@pfecha_contratacion", objEmpleado.fecha_contratacion);
                micomando.Parameters.AddWithValue("@pfecha_nac", objEmpleado.fecha_nac);
                micomando.Parameters.AddWithValue("@psalario", objEmpleado.salario);
                micomando.Parameters.AddWithValue("@pestado_empleado", objEmpleado.estado_empleado);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objEmpleado.id_empleado = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objEmpleado.id_empleado; // Formato especial para identificar éxito con ID
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

        public string EmpleadoActualizar(CDEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_empleado", objEmpleado.id_empleado);
                micomando.Parameters.AddWithValue("@pid_cargo", objEmpleado.id_cargo);
                micomando.Parameters.AddWithValue("@pid_departamento", objEmpleado.id_departamento);
                micomando.Parameters.AddWithValue("@pnombre_empleado", objEmpleado.nombre_empleado);
                micomando.Parameters.AddWithValue("@papellido_empleado", objEmpleado.apellido_empleado);
                micomando.Parameters.AddWithValue("@pcedula_empleado", objEmpleado.cedula_empleado);
                micomando.Parameters.AddWithValue("@ptelefono_empleado", objEmpleado.telefono_empleado);
                micomando.Parameters.AddWithValue("@pcorreo_empleado", objEmpleado.correo_empleado);
                micomando.Parameters.AddWithValue("@pfecha_contratacion", objEmpleado.fecha_contratacion);
                micomando.Parameters.AddWithValue("@pfecha_nac", objEmpleado.fecha_nac);
                micomando.Parameters.AddWithValue("@psalario", objEmpleado.salario);
                micomando.Parameters.AddWithValue("@pestado_empleado", objEmpleado.estado_empleado);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Empleado actualizado correctamente!" : "Error al actualizar empleado.";
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
        public DataTable EmpleadoConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "EmpleadoConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_empleado", miparametro);
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

        public DataTable EmpleadoTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "EmpleadoTodo"; // Nombre del procedimiento almacenado
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

        public int EmpleadoEliminar (string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("EmpleadoEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_empleado", miparametro);

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
