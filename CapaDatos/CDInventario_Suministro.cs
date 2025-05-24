using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDInventario_Suministro
    {
        private int did_movimiento, did_habitacion, did_suministro, dcantidad_movimiento;
        private string dtipo_movimiento;
        private DateTime dfecha_movimiento;

        public CDInventario_Suministro() { }
        
        public CDInventario_Suministro(int pid_movimiento, int pid_habitacion, int pid_suministro, string ptipo_movimiento, int pcantidad_movimiento, DateTime pfecha_movimiento)
        {
            did_movimiento = pid_movimiento;
            did_habitacion = pid_habitacion;
            did_suministro = pid_suministro;
            dtipo_movimiento = ptipo_movimiento;
            dcantidad_movimiento = pcantidad_movimiento;
            dfecha_movimiento = pfecha_movimiento;
        }

        #region Métodos Get y Set
        public int id_movimiento
        {
            get { return did_movimiento; }
            set { did_movimiento = value; }
        }
        public int id_habitacion
        {
            get { return did_habitacion; }
            set { did_habitacion = value; }
        }
        public int id_suministro
        {
            get { return did_suministro; }
            set { did_suministro = value; }
        }
        public string tipo_movimiento
        {
            get { return dtipo_movimiento; }
            set { dtipo_movimiento = value; }
        }
        public int cantidad_movimiento
        {
            get { return dcantidad_movimiento; }
            set { dcantidad_movimiento = value; }
        }
        public DateTime fecha_movimiento
        {
            get { return dfecha_movimiento; }
            set { dfecha_movimiento = value; }
        }
        #endregion
        public string Inventario_SuministroInsertar(CDInventario_Suministro objInventario_Suministro)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("Inventario_SuministroInsertar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_movimiento", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pid_habitacion", objInventario_Suministro.id_habitacion);
                micomando.Parameters.AddWithValue("@pid_suministro", objInventario_Suministro.id_suministro);
                micomando.Parameters.AddWithValue("@ptipo_movimiento", objInventario_Suministro.tipo_movimiento);
                micomando.Parameters.AddWithValue("@pcantidad_movimiento", objInventario_Suministro.cantidad_movimiento);
                micomando.Parameters.AddWithValue("@pfecha_movimiento", objInventario_Suministro.fecha_movimiento);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objInventario_Suministro.id_movimiento = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objInventario_Suministro.id_movimiento; // Formato especial para identificar éxito con ID
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

        public string Inventario_SuministroActualizar(CDInventario_Suministro objInventario_Suministro)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("Inventario_SuministroActualizar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_movimiento", objInventario_Suministro.id_movimiento);
                micomando.Parameters.AddWithValue("@pid_habitacion", objInventario_Suministro.id_habitacion);
                micomando.Parameters.AddWithValue("@pid_suministro", objInventario_Suministro.id_suministro);
                micomando.Parameters.AddWithValue("@ptipo_movimiento", objInventario_Suministro.tipo_movimiento);
                micomando.Parameters.AddWithValue("@pcantidad_movimiento", objInventario_Suministro.cantidad_movimiento);
                micomando.Parameters.AddWithValue("@pfecha_movimiento", objInventario_Suministro.fecha_movimiento);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Movimiento actualizada correctamente!" : "Error al actualizar el Movimiento.";
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

        public DataTable Inventario_SuministroConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Inventario_SuministroConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_movimiento", miparametro);
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

        public DataTable Inventario_SuministroTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "Inventario_SuministroTodo"; // Nombre del procedimiento almacenado
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

        public int Inventario_SuministroEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("Inventario_SuministroEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_movimiento", miparametro);


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