using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDReserva
    {
        private int didreserva,didcliente,didhabitacion;
        private DateTime dfecha_reserva, dfecha_ingreso, dfecha_salida;
        private string destado_reserva;

        public CDReserva() { }

        public CDReserva(int pid_reserva, int pid_cliente, int pid_habitacion, DateTime pfecha_reserva, 
            DateTime pfecha_entrada, DateTime pfecha_salida, string pestado_reserva)
        {
            didreserva = pid_reserva;
            didcliente = pid_cliente;
            didhabitacion = pid_habitacion;
            dfecha_reserva = pfecha_reserva;
            dfecha_ingreso = pfecha_entrada;
            dfecha_salida = pfecha_salida;
            destado_reserva = pestado_reserva;
        }

        #region Métodos Get y Set 
        public int id_reserva
        {
            get { return didreserva; }
            set { didreserva = value; }
        }
        public int id_cliente
        {
            get { return didcliente; }
            set { didcliente = value; }
        }

        public int id_habitacion
        {
            get { return didhabitacion; }
            set { didhabitacion = value; }
        }
        public DateTime fecha_reserva
        {
            get { return dfecha_reserva; }
            set { dfecha_reserva = value; }
        }
        public DateTime fecha_ingreso
        {
            get { return dfecha_ingreso; }
            set { dfecha_ingreso = value; }
        }
        public DateTime fecha_salida
        {
            get { return dfecha_salida; }
            set { dfecha_salida = value; }
        }
        public string estado_reserva
        {
            get { return destado_reserva; }
            set { destado_reserva = value; }
        }
        #endregion

        public string ReservaInsertar(CDReserva objReserva)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_reserva", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pid_cliente", objReserva.id_cliente);
                micomando.Parameters.AddWithValue("@pid_habitacion", objReserva.id_habitacion);
                micomando.Parameters.AddWithValue("@pfecha_reserva", objReserva.fecha_reserva);
                micomando.Parameters.AddWithValue("@pfecha_ingreso", objReserva.fecha_ingreso);
                micomando.Parameters.AddWithValue("@pfecha_salida", objReserva.fecha_salida);
                micomando.Parameters.AddWithValue("@pestado_reserva", objReserva.estado_reserva);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objReserva.id_reserva = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objReserva.id_reserva; // Formato especial para identificar éxito con ID
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

        public string ReservaActualizar(CDReserva objReserva)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_reserva", objReserva.id_reserva);
                micomando.Parameters.AddWithValue("@pid_cliente", objReserva.id_cliente);
                micomando.Parameters.AddWithValue("@pid_habitacion", objReserva.id_habitacion);
                micomando.Parameters.AddWithValue("@pfecha_reserva", objReserva.fecha_reserva);
                micomando.Parameters.AddWithValue("@pfecha_ingreso", objReserva.fecha_ingreso);
                micomando.Parameters.AddWithValue("@pfecha_salida", objReserva.fecha_salida);
                micomando.Parameters.AddWithValue("@pestado_reserva", objReserva.estado_reserva);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Cargo actualizado correctamente!" : "Error al actualizar cargo.";
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

        public DataTable ReservaTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "ReservaTodo"; // Nombre del procedimiento almacenado
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

        public int ReservaEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("ReservaEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_reserva", miparametro);


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

        public DataTable ReservaConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "ReservaConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_reserva", miparametro);
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
    }
}
