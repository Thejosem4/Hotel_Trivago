using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNCliente
    {
  
        public static string ClienteInsertar(string nombre_cliente, string apellido_cliente, string telefono_cliente, string email_cliente, string direccion_cliente, string cedula_cliente, DateTime fecha_registro, out int id_cliente)
        {
            id_cliente = 0;

            CDCliente objCliente = new CDCliente();
            objCliente.nombre_cliente = nombre_cliente;
            objCliente.apellido_cliente = apellido_cliente;
            objCliente.telefono_cliente = telefono_cliente;
            objCliente.email_cliente = email_cliente;
            objCliente.direccion_cliente = direccion_cliente;
            objCliente.cedula_cliente = cedula_cliente;
            objCliente.fecha_registro = fecha_registro;

            string resultado = objCliente.ClienteInsertar(objCliente);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_cliente = nuevoId;
                    return "Cliente insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string ClienteActualizar(int id_cliente, string nombre_cliente, string apellido_cliente, string telefono_cliente, string email_cliente, string direccion_cliente, string cedula_cliente, DateTime fecha_registro)
        {
            CDCliente objCliente = new CDCliente();
            objCliente.id_cliente = id_cliente;
            objCliente.nombre_cliente = nombre_cliente;
            objCliente.apellido_cliente = apellido_cliente;
            objCliente.telefono_cliente = telefono_cliente;
            objCliente.email_cliente = email_cliente;
            objCliente.direccion_cliente = direccion_cliente;
            objCliente.cedula_cliente = cedula_cliente;
            objCliente.fecha_registro = fecha_registro;

            return objCliente.ClienteActualizar(objCliente); 
        }

        public DataTable ClienteConsultar(string parametro)
        {
           CDCliente objCliente = new CDCliente();
            return objCliente.ClienteConsultar(parametro); 
        }

        public DataTable ClienteTodo()
        {
            CDCliente objCliente = new CDCliente();
            return objCliente.ClienteTodo();
        }

        public static int ClienteEliminar(string parametro)
        {
            CDCliente objCliente = new CDCliente();
            return objCliente.ClienteEliminar(parametro);
        }
    }
}
