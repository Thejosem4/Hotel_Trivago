using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDUsuario
    {
        private int did_usuario, did_empleado, did_rol;
        private string dnombre, dclave, destado_usuario;
        private DateTime dfecha_registro;
        public CDUsuario() { }

        public CDUsuario(int pid_usuario, int pid_empleado, int pid_rol, string pnombre, string pclave, DateTime pfecha_registro, string pestado_usuario)
        {
            did_usuario = pid_usuario;
            did_empleado = pid_empleado;
            did_rol = pid_rol;
            dnombre = pnombre;
            dclave = pclave;
            dfecha_registro = pfecha_registro;
            destado_usuario = pestado_usuario;
        }

        #region Métodos Get y Set 
        public int id_usuario
        {
            get { return did_usuario; }
            set { did_usuario = value; }
        }
        public int id_empleado
        {
            get { return did_empleado; }
            set { did_empleado = value; }
        }
        public int id_rol
        {
            get { return did_rol; }
            set { did_rol = value; }
        }

        public string nombre
        {
            get { return dnombre; }
            set { dnombre = value; }
        }
        public string clave
        {
            get { return dclave; }
            set { dclave = value; }
        }

        public DateTime fecha_registro
        {
            get { return dfecha_registro; }
            set { dfecha_registro = value; }
        }
        public string estado_usuario
        {
            get { return destado_usuario; }
            set { destado_usuario = value; }
        }
        #endregion

        public string UsuarioInsertar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_usuario", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pid_empleado", objUsuario.id_empleado);
                micomando.Parameters.AddWithValue("@pid_rol", objUsuario.id_rol);
                micomando.Parameters.AddWithValue("@pnombre", objUsuario.nombre);
                micomando.Parameters.AddWithValue("@pclave", objUsuario.clave);
                micomando.Parameters.AddWithValue("@pfecha_registro", objUsuario.fecha_registro);
                micomando.Parameters.AddWithValue("@pestado_usuario", objUsuario.estado_usuario);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objUsuario.id_usuario = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objUsuario.id_usuario; // Formato especial para identificar éxito con ID
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

        public string UsuarioActualizar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioActualizar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_usuario", objUsuario.id_usuario);
                micomando.Parameters.AddWithValue("@pid_empleado", objUsuario.id_empleado);
                micomando.Parameters.AddWithValue("@pid_rol", objUsuario.id_rol);
                micomando.Parameters.AddWithValue("@pnombre", objUsuario.nombre);
                micomando.Parameters.AddWithValue("@pclave", objUsuario.clave);
                micomando.Parameters.AddWithValue("@pfecha_registro", objUsuario.fecha_registro);
                micomando.Parameters.AddWithValue("@pestado_usuario", objUsuario.estado_usuario);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Usuario actualizado correctamente!" : "Error al actualizar usuario.";
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

        public DataTable UsuarioConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "UsuarioConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_usuario", miparametro);
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

        public DataTable UsuarioTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "UsuarioTodo"; // Nombre del procedimiento almacenado
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

        public int UsuarioEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("UsuarioEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_usuaio", miparametro);

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
        public string UsuarioEliminar()
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioEliminar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_usuario", id_usuario);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Usuario eliminado correctamente!" : "Error al eliminar usuario.";
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
        public int ValidarUsuario(string usuario, string clave)
        {
            int esValido = -1;
            try
            {
                using (SqlConnection con = new conexion().dbconexion)
                {
                    SqlCommand sqlCmd = new SqlCommand("UsuarioValidar", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.Parameters.AddWithValue("@Usuario", usuario);
                    sqlCmd.Parameters.AddWithValue("@Clave", clave);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    sqlCmd.Parameters.Add(returnValue);

                    con.Open();
                    sqlCmd.ExecuteNonQuery();
                    esValido = (int)returnValue.Value;
                }
            }
            catch (Exception)
            {
                esValido = -1;
            }
            return esValido;
        }
    }
}