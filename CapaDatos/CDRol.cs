using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDRol
    {
        private int did_rol;
        private string dnombre_rol, ddescripcion_rol;

        public CDRol() { }

        public CDRol(int pid_rol, string pnombre_rol, string pdescripcion_rol)
        {
            did_rol = pid_rol;
            dnombre_rol = pnombre_rol;
            ddescripcion_rol = pdescripcion_rol;
        }

        #region Métodos Get y Set 
        public int id_rol
        {
            get { return did_rol; }
            set { did_rol = value; }
        }
        public string  nombre_rol
        {
            get { return dnombre_rol; }
            set { dnombre_rol = value; }
        }
        public string descripcion_rol
        {
            get { return ddescripcion_rol; }
            set { ddescripcion_rol = value; }
        }
        #endregion

        public string RolInsertar(CDRol objRol)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("RolInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_rol", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pnombre_rol", objRol.nombre_rol);
                micomando.Parameters.AddWithValue("@pdescripcion_rol", objRol.descripcion_rol);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objRol.id_rol = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objRol.id_rol; // Formato especial para identificar éxito con ID
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

        public string RolActualizar(CDRol objRol)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("RolActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_rol", objRol.id_rol);
                micomando.Parameters.AddWithValue("@pnombre_rol", objRol.nombre_rol);
                micomando.Parameters.AddWithValue("@pdescripcion_rol", objRol.descripcion_rol);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Rol actualizado correctamente!" : "Error al actualizar rol.";
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

        public DataTable RolConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "RolConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_rol", miparametro);
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

        public DataTable RolTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "RolTodo"; // Nombre del procedimiento almacenado
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

        public int RolEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("RolEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_rol", miparametro);


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
