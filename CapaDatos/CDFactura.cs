using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDFactura
    {
        private int did_factura, did_facturadet, did_reserva, did_empleado, did_empresa, ddescuento;
        private string dmetodo_pago;
        private DateTime dfecha_emision;
        private decimal dtotal, dimporte_total;

        public CDFactura() { }

        public CDFactura(int pid_factura, int pid_empleado, int pid_empresa, string pmetodo_pago, int pid_facturadet, int pid_reserva, DateTime pfecha_emision, int pdescuento, decimal ptotal, decimal pimporte_total)
        {
            did_factura = pid_factura;
            did_empleado = pid_empleado;
            did_empresa = pid_empresa;
            dtotal = ptotal;
            dmetodo_pago = pmetodo_pago;
            did_facturadet = pid_facturadet;
            did_reserva = pid_reserva;
            dfecha_emision = pfecha_emision;
            ddescuento = pdescuento;
            dimporte_total = pimporte_total;
        }

        #region Métodos Get y Set
        public int id_factura
        {
            get => did_factura;
            set => did_factura = value;
        }
        public int id_empleado
        {
            get => did_empleado;
            set => did_empleado = value;
        }
        public int id_empresa
        {
            get => did_empresa;
            set => did_empresa = value;
        }
        public decimal total
        {
            get => dtotal;
            set => dtotal = value;
        }
        public string metodo_pago
        {
            get => dmetodo_pago;
            set => dmetodo_pago = value;
        }
        public int id_facturadet
        {
            get => did_facturadet;
            set => did_facturadet = value;
        }
        public int id_reserva
        {
            get => did_reserva;
            set => did_reserva = value;
        }
        public DateTime fecha_emision
        {
            get => dfecha_emision;
            set => dfecha_emision = value;
        }
        public int descuento
        {
            get => ddescuento;
            set => ddescuento = value;
        }
        public decimal importe_total
        {
            get => dimporte_total;
            set => dimporte_total = value;
        }
        #endregion

        public string FacturaInsertar(CDFactura objFactura)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("FacturaInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_factura", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pid_empleado", objFactura.id_empleado);
                micomando.Parameters.AddWithValue("@pid_empresa", objFactura.id_empresa);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objFactura.metodo_pago);
                micomando.Parameters.AddWithValue("@ptotal", objFactura.total);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objFactura.id_factura = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objFactura.id_factura; // Formato especial para identificar éxito con ID
                }
                else
                {
                    mensaje = "Error: No se pudo obtener el ID de la Factura.";

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

        public string FacturaDetInsertar(CDFactura objFactura)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("FacturaDetInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramIdDet = new SqlParameter("@pid_facturadet", SqlDbType.Int);
                paramIdDet.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramIdDet);

                micomando.Parameters.AddWithValue("@pid_factura", id_factura);
                micomando.Parameters.AddWithValue("@pid_reserva", objFactura.id_reserva);
                micomando.Parameters.AddWithValue("@pfecha_emision", objFactura.fecha_emision);
                micomando.Parameters.AddWithValue("@pimporte_total", objFactura.importe_total);
                micomando.Parameters.AddWithValue("@pdescuento", objFactura.descuento);

                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramIdDet.Value != DBNull.Value)
                {
                    objFactura.id_facturadet = Convert.ToInt32(paramIdDet.Value);
                    mensaje = "OK:" + objFactura.id_facturadet; // Formato especial para identificar éxito con ID
                }
                else
                {
                    mensaje = "Error: No se pudo obtener el ID del Detalle.";

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


        // Método para actualizar cabecera de factura
        public string FacturaActualizar(CDFactura objFactura)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("FacturaActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_factura", objFactura.id_factura);
                micomando.Parameters.AddWithValue("@pid_empleado", objFactura.id_empleado);
                micomando.Parameters.AddWithValue("@pid_empresa", objFactura.id_empresa);
                micomando.Parameters.AddWithValue("@pmetodo_pago", objFactura.metodo_pago);
                micomando.Parameters.AddWithValue("@ptotal", objFactura.total);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Cabecera de factura actualizada correctamente!" : "Error al actualizar cabecera de factura.";
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

        // Método para actualizar detalle de factura
        public string FacturaDetActualizar(CDFactura objFactura)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("FacturaDetActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pid_facturadet", objFactura.id_facturadet);
                micomando.Parameters.AddWithValue("@pid_factura", objFactura.id_factura);
                micomando.Parameters.AddWithValue("@pid_reserva", objFactura.id_reserva);
                micomando.Parameters.AddWithValue("@pfecha_emision", objFactura.fecha_emision);
                micomando.Parameters.AddWithValue("@pdescuento", objFactura.descuento);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Detalle de factura actualizado correctamente!" : "Error al actualizar detalle de factura.";
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

        public DataTable FacturaConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "FacturaConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_factura", miparametro);
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

        public DataTable FacturaDetConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "FacturaDetConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_factura", miparametro);
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

        public DataTable FacturaTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "FacturaTodo";
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

        public int FacturaEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("FacturaEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_factura", miparametro);


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

        public int FacturaDetEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("FacturaDetEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_factura", miparametro);


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
