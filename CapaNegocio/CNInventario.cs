using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNInventario
    {

        public static string InventarioInsertar(string nombre_suministro, string descripcion_suministro, int cantidad_suministro, string estado_suministro, out int id_inventario)
        {
            id_inventario = 0;

            CDInventario objInventario = new CDInventario();
            objInventario.nombre_suministro = nombre_suministro;
            objInventario.descripcion_suministro = descripcion_suministro;
            objInventario.cantidad_suministro = cantidad_suministro;
            objInventario.estado_suministro = estado_suministro;

            string resultado = objInventario.InventarioInsertar(objInventario);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_inventario = nuevoId;
                    return "Suministro insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }
       
        public static string InventarioActualizar(int id_suministro, string nombre_suministro, string descripcion_suministro, int cantidad_suministro, string estado_suministro)
        {
            CDInventario objInventario = new CDInventario();
            objInventario.id_suministro = id_suministro;
            objInventario.nombre_suministro = nombre_suministro;
            objInventario.descripcion_suministro = descripcion_suministro;
            objInventario.cantidad_suministro = cantidad_suministro;
            objInventario.estado_suministro = estado_suministro;
            return objInventario.InventarioActualizar(objInventario);
        }
      
        public DataTable InventarioConsultar(string parametro)
        {
            CDInventario objInventario = new CDInventario();
            return objInventario.InventarioConsultar(parametro);
        }

        public DataTable InventarioTodo()
        {
            CDInventario objInventario = new CDInventario();
            return objInventario.InventarioTodo();
        }

        public static int InventarioEliminar(string parametro)
        {
            CDInventario objInventario = new CDInventario();
            return objInventario.InventarioEliminar(parametro);
        }
    }
}