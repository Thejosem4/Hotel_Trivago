  using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDEmpresa
    {
        private int did_empresa;
        private string dnombre_empresa, dcorreo_empresa, drnc, ddireccion_empresa, dtelefono_empresa, dslogan, dgerente;
        public CDEmpresa() { }

        public CDEmpresa(int pid_empresa, string pnombre_empresa, string pcorreo_empresa, string prnc, string pdireccion_empresa, string ptelefono_empresa, string pslogan, string pgerente)
        {
            did_empresa = pid_empresa;
            dnombre_empresa = pnombre_empresa;
            dcorreo_empresa = pcorreo_empresa;
            drnc = prnc;
            ddireccion_empresa = pdireccion_empresa;
            dtelefono_empresa = ptelefono_empresa;
            dslogan = pslogan;
            dgerente = pgerente;
        }

        #region Métodos Get y Set
        public int id_empresa
        {
            get { return did_empresa; }
            set { did_empresa = value; }
        }
        public string nombre_empresa
        {
            get { return dnombre_empresa; }
            set { dnombre_empresa = value; }
        }
        public string correo_empresa
        {
            get { return dcorreo_empresa; }
            set { dcorreo_empresa = value; }
        }
        public string rnc
        {
            get { return drnc; }
            set { drnc = value; }
        }
        public string direccion_empresa
        {
            get { return ddireccion_empresa; }
            set { ddireccion_empresa = value; }
        }
        public string telefono_empresa
        {
            get { return dtelefono_empresa; }
            set { dtelefono_empresa = value; }
        }
        public string slogan
        {
            get { return dslogan; }
            set { dslogan = value; }
        }
        public string gerente
        {
            get { return dgerente; }
            set { dgerente = value; }
        }
        #endregion

        public string EmpresaInsertar(CDEmpresa objEmpresa)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpresaInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_empresa", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pnombre_empresa", objEmpresa.nombre_empresa);
                micomando.Parameters.AddWithValue("@pcorreo_empresa", objEmpresa.correo_empresa);
                micomando.Parameters.AddWithValue("@prnc", objEmpresa.rnc);
                micomando.Parameters.AddWithValue("@pdireccion_empresa", objEmpresa.direccion_empresa);
                micomando.Parameters.AddWithValue("@ptelefono_empresa", objEmpresa.telefono_empresa);
                micomando.Parameters.AddWithValue("@pslogan", objEmpresa.slogan);
                micomando.Parameters.AddWithValue("@pgerente", objEmpresa.gerente);
                micomando.ExecuteNonQuery();

                // Ahora el parámetro de salida debería tener el valor asignado
                if (paramId.Value != DBNull.Value)
                {
                    objEmpresa.id_empresa = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objEmpresa.id_empresa; // Formato especial para identificar éxito con ID
                }
                else
                {
                    mensaje = "Error: No se pudo obtener el ID de la empresa.";
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return mensaje;
        }

        public string EmpresaActualizar(CDEmpresa objEmpresa)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpresaActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_empresa", objEmpresa.id_empresa);
                micomando.Parameters.AddWithValue("@pnombre_empresa", objEmpresa.nombre_empresa);
                micomando.Parameters.AddWithValue("@pcorreo_empresa", objEmpresa.correo_empresa);
                micomando.Parameters.AddWithValue("@prnc", objEmpresa.rnc);
                micomando.Parameters.AddWithValue("@pdireccion_empresa", objEmpresa.direccion_empresa);
                micomando.Parameters.AddWithValue("@ptelefono_empresa", objEmpresa.telefono_empresa);
                micomando.Parameters.AddWithValue("@pslogan", objEmpresa.slogan);
                micomando.Parameters.AddWithValue("@pgerente", objEmpresa.gerente);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Empresa actualizada" : "Error al actualizar la empresa";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return mensaje;
        }

        public DataTable EmpresaConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "EmpresaConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_empresa", miparametro);
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

        public DataTable EmpresaTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "EmpresaTodo"; // Nombre del procedimiento almacenado
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

        public int EmpresaEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("EmpresaEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_empresa", miparametro);


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
    
