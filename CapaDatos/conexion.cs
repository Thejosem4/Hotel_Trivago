using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class conexion
    {
            public static string miconexion = @"Data Source = (LocalDB)\MSSQLLocalDB;
 AttachDbFilename = C:\Hotel_Trivago\CapaDatos\DBTrivago.mdf;
Integrated Security = True;
";

        public SqlConnection dbconexion = new SqlConnection(miconexion);

            public object ExecuteScalar(string query, SqlParameter[] parameters)
            {
                object result;
                using (SqlConnection connection = new SqlConnection(miconexion))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    result = command.ExecuteScalar();
                }

                return result;
            }
    }
}
