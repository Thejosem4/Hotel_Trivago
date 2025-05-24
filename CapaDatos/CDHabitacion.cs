using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDHabitacion
    {
        private int did_habitacion, dcapacidad;
        private string dtipo_habitacion, ddescripcion_hab;
        private decimal dprecio;

        public CDHabitacion() { }

        public CDHabitacion(int pid_habitacion, int pcapacidad, string ptipo_habitacion, string pdescripcion_hab, decimal pprecio)
        {
            did_habitacion = pid_habitacion;
            dcapacidad = pcapacidad;
            dtipo_habitacion = ptipo_habitacion;
            ddescripcion_hab = pdescripcion_hab;
            dprecio = pprecio;
        }

        #region Métodos Get y Set
        public int id_habitacion
        {
            get { return did_habitacion; }
            set { did_habitacion = value; }
        }
        public int capacidad
        {
            get { return dcapacidad; }
            set { dcapacidad = value; }
        }
        public string tipo_habitacion
        {
            get { return dtipo_habitacion; }
            set { dtipo_habitacion = value; }
        }
        public string descripcion_hab
        {
            get { return ddescripcion_hab; }
            set { ddescripcion_hab = value; }
        }
        public decimal precio
        {
            get { return dprecio; }
            set { dprecio = value; }
        }

        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public string NombreHabitacion { get; set; }
        #endregion

        public string HabitacionInsertar(CDHabitacion objHabitacion)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("HabitacionInsertar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_habitacion", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pcapacidad", objHabitacion.capacidad);
                micomando.Parameters.AddWithValue("@ptipo_habitacion", objHabitacion.tipo_habitacion);
                micomando.Parameters.AddWithValue("@pdescripcion_hab", objHabitacion.descripcion_hab);
                micomando.Parameters.AddWithValue("@pprecio", objHabitacion.precio);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objHabitacion.id_habitacion = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objHabitacion.id_habitacion; // Formato especial para identificar éxito con ID
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

        public string HabitacionActualizar(CDHabitacion objHabitacion)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("HabitacionActualizar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_habitacion", objHabitacion.id_habitacion);
                micomando.Parameters.AddWithValue("@pcapacidad", objHabitacion.capacidad);
                micomando.Parameters.AddWithValue("@ptipo_habitacion", objHabitacion.tipo_habitacion);
                micomando.Parameters.AddWithValue("@pdescripcion_hab", objHabitacion.descripcion_hab);
                micomando.Parameters.AddWithValue("@pprecio", objHabitacion.precio);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Habitación actualizada correctamente!" : "Error al actualizar habitación.";
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

        public DataTable HabitacionConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "HabitacionConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_habitacion", miparametro);
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

        public DataTable HabitacionTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "HabitacionTodo"; // Nombre del procedimiento almacenado
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

        public int HabitacionEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("HabitacionEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_habitacion", miparametro);


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
