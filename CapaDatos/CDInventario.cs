using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CapaDatos
{
    public class CDInventario
    {
        private int did_suministro, dcantidad_suministro;
        private string dnombre_suministro, ddescripcion_suministro, destado_suministro;

        public CDInventario() { }

        public CDInventario(int pid_suministro, string pnombre_suministro, string pdescripcion_suministro, int pcantidad_suministro, string pestado_suministro)
        {
            did_suministro = pid_suministro;
            dnombre_suministro = pnombre_suministro;
            ddescripcion_suministro = pdescripcion_suministro;
            dcantidad_suministro = pcantidad_suministro;
            destado_suministro = pestado_suministro;
        }

        #region Métodos Get y Set
        public int id_suministro
        {
            get => did_suministro;
            set => did_suministro = value;
        }
        public string nombre_suministro
        {
            get => dnombre_suministro;
            set => dnombre_suministro = value;
        }
        public string descripcion_suministro
        {
            get => ddescripcion_suministro;
            set => ddescripcion_suministro = value;
        }
        public int cantidad_suministro
        {
            get => dcantidad_suministro;
            set => dcantidad_suministro = value;
        }
        public string estado_suministro
        {
            get => destado_suministro;
            set => destado_suministro = value;
        }
        #endregion

        public string InventarioInsertar(CDInventario objInventario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("InventarioInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_suministro", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pnombre_suministro", objInventario.nombre_suministro);
                micomando.Parameters.AddWithValue("@pdescripcion_suministro", objInventario.descripcion_suministro);
                micomando.Parameters.AddWithValue("@pcantidad_suministro", objInventario.cantidad_suministro);
                micomando.Parameters.AddWithValue("@pestado_suministro", objInventario.estado_suministro);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objInventario.id_suministro = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objInventario.id_suministro; // Formato especial para identificar éxito con ID
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

        public string InventarioActualizar(CDInventario objInventario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("InventarioActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_suministro", objInventario.id_suministro);
                micomando.Parameters.AddWithValue("@pnombre_suministro", objInventario.nombre_suministro);
                micomando.Parameters.AddWithValue("@pdescripcion_suministro", objInventario.descripcion_suministro);
                micomando.Parameters.AddWithValue("@pcantidad_suministro", objInventario.cantidad_suministro);
                micomando.Parameters.AddWithValue("@pestado_suministro", objInventario.estado_suministro);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Suministro insertado correctamente!" : "Error al insertar suministro.";
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

        public DataTable InventarioConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "InventarioConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_suministro", miparametro);
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

        public DataTable InventarioTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "InventarioTodo"; // Nombre del procedimiento almacenado
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

        public int InventarioEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("InventarioEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_suministro", miparametro);


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
