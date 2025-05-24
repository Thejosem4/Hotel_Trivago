using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class CDCargo
    {
        private int did_cargo;
        private string dnombre_cargo, ddescripcion_cargo, destado_cargo;

        public CDCargo() { }

        public CDCargo(int pid_cargo, string pnombre_cargo, string pdescripcion_cargo, string pestado_cargo)
        {
            did_cargo = pid_cargo;
            dnombre_cargo = pnombre_cargo;
            ddescripcion_cargo = pdescripcion_cargo;
            destado_cargo = pestado_cargo;
        }

        #region Métodos Get y Set 
        public int id_cargo
        {
            get { return did_cargo; }
            set { did_cargo = value; }
        }
        public string nombre_cargo
        {
            get { return dnombre_cargo; }
            set { dnombre_cargo = value; }
        }
        public string descripcion_cargo
        {
            get { return ddescripcion_cargo; }
            set { ddescripcion_cargo = value; }
        }
        public string estado_cargo
        {
            get { return destado_cargo; }
            set { destado_cargo = value; }
        }
        #endregion

        public string CargoInsertar(CDCargo objCargo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter("@pid_cargo", SqlDbType.Int);
                paramId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(paramId);

                micomando.Parameters.AddWithValue("@pnombre_cargo", objCargo.nombre_cargo);
                micomando.Parameters.AddWithValue("@pdescripcion_cargo", objCargo.descripcion_cargo);
                micomando.Parameters.AddWithValue("@pestado_cargo", objCargo.estado_cargo);
                micomando.ExecuteNonQuery();

                // Obtener el ID generado y asignarlo al objeto
                if (paramId.Value != DBNull.Value)
                {
                    objCargo.id_cargo = Convert.ToInt32(paramId.Value);
                    mensaje = "OK:" + objCargo.id_cargo; // Formato especial para identificar éxito con ID
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

        public string CargoActualizar(CDCargo objCargo)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion.miconexion;
                SqlCommand micomando = new SqlCommand("CargoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pid_cargo", objCargo.id_cargo);
                micomando.Parameters.AddWithValue("@pnombre_cargo", objCargo.nombre_cargo);
                micomando.Parameters.AddWithValue("@pdescripcion_cargo", objCargo.descripcion_cargo);
                micomando.Parameters.AddWithValue("@pestado_cargo", objCargo.estado_cargo);

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

        public DataTable CargoConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CargoConsultar";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pid_cargo", miparametro);
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

        public DataTable CargoTodo()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new conexion().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "CargoTodo"; // Nombre del procedimiento almacenado
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

        public int CargoEliminar(string miparametro)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = new conexion().dbconexion)
                {
                    conexion.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("CargoEliminar", conexion))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@pid_cargo", miparametro);


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

