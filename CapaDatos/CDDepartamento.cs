using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDDepartamento
    {
        private int did_departamento;
        private string dnombre_depart, ddescripcion_depart, destado_depart;
        private DateTime dfecha_creacion;
        public CDDepartamento() { }

        public CDDepartamento(int pid_departamento, string pnombre_depart, string pdescripcion_depart, string pestado_depart, DateTime pfecha_creacion)
        {
            did_departamento = pid_departamento;
            dnombre_depart = pnombre_depart;
            ddescripcion_depart = pdescripcion_depart;
            destado_depart = pestado_depart;
            dfecha_creacion = pfecha_creacion;
        }

        #region Métodos Get y Set 
        public int id_departamento
        {
            get { return did_departamento; }
            set { did_departamento = value; }
        }
        public string nombre_depart
        {
            get { return dnombre_depart; }
            set { dnombre_depart = value; }
        }
        public string descripcion_depart
        {
            get { return ddescripcion_depart; }
            set { ddescripcion_depart = value; }
        }
        public string estado_depart
        {
            get { return destado_depart; }
            set { destado_depart = value; }
        }
        public DateTime fecha_creacion
        {
            get { return dfecha_creacion; }
            set { dfecha_creacion = value; }
        }
        #endregion

        public string DepartamentoInsertar(CDDepartamento objDepartamento)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("DepartamentoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_departamento", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);
                
                micomando.Parameters.AddWithValue("@pnombre_depart", objDepartamento.nombre_depart);
                micomando.Parameters.AddWithValue("@pdescripcion_depart", objDepartamento.descripcion_depart);
                micomando.Parameters.AddWithValue("@pestado_depart", objDepartamento.estado_depart);
                micomando.Parameters.AddWithValue("@fecha_creacion", objDepartamento.fecha_creacion);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objDepartamento.id_departamento = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objDepartamento.id_departamento; // Formato especial para identificar éxito con ID
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

        public string DepartamentoActualizar(CDDepartamento objDepartamento)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("DepartamentoActualizar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_departamento", objDepartamento.id_departamento);
                micomando.Parameters.AddWithValue("@pnombre_depart", objDepartamento.nombre_depart);
                micomando.Parameters.AddWithValue("@pdescripcion_depart", objDepartamento.descripcion_depart);
                micomando.Parameters.AddWithValue("@pestado_depart", objDepartamento.estado_depart);
                micomando.Parameters.AddWithValue("@fecha_creacion", objDepartamento.fecha_creacion);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Departamento actualizado correctamente!" : "Error al actualizar Departamento.";
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

        public DataTable DepartamentoConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "DepartamentoConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_departamento", miparametro);
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

        public DataTable DepartamentoTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "DepartamentoTodo"; // Nombre del procedimiento almacenado
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

        public int DepartamentoEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("DepartamentoEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_departamento", miparametro);


                        SqlParameter returnParameter = sqlCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        sqlCmd.ExecuteNonQuery();


                        resultado = (int)returnParameter.Value;
                    }
                }
            }
            catch (Exception)
            {
                resultado = -1;
            }
            return resultado;
        }
    }
}