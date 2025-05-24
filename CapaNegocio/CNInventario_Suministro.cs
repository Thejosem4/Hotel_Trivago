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
    public class CNInventario_Suministro
    {
        public static string Inventario_SuministroInsertar(int id_habitacion, int id_suministro, string tipo_movimiento, int cantidad_movimiento, DateTime fecha_movimiento, out int id_movimiento)
        {
            id_movimiento = 0;

            CDInventario_Suministro objInventario_Suministro = new CDInventario_Suministro();
            objInventario_Suministro.id_habitacion = id_habitacion;
            objInventario_Suministro.id_suministro = id_suministro;
            objInventario_Suministro.tipo_movimiento = tipo_movimiento;
            objInventario_Suministro.cantidad_movimiento = cantidad_movimiento;
            objInventario_Suministro.fecha_movimiento = fecha_movimiento;

            string resultado = objInventario_Suministro.Inventario_SuministroInsertar(objInventario_Suministro);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_movimiento = nuevoId;
                    return "Movimiento registrado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string Inventario_SuministroActualizar(int id_movimiento, int id_habitacion, int id_suministro, string tipo_movimiento, int cantidad_movimiento, DateTime fecha_movimiento)
        {
            CDInventario_Suministro objInventario_Suministro = new CDInventario_Suministro();
            objInventario_Suministro.id_movimiento = id_movimiento;
            objInventario_Suministro.id_habitacion = id_habitacion;
            objInventario_Suministro.id_suministro = id_suministro;
            objInventario_Suministro.tipo_movimiento = tipo_movimiento;
            objInventario_Suministro.cantidad_movimiento = cantidad_movimiento;
            objInventario_Suministro.fecha_movimiento = fecha_movimiento;
            return objInventario_Suministro.Inventario_SuministroActualizar(objInventario_Suministro);
        }

        public DataTable Inventario_SuministroConsultar(string parametro)
        {
            CDInventario_Suministro objInventario_Suministro = new CDInventario_Suministro();
            return objInventario_Suministro.Inventario_SuministroConsultar(parametro);
        }

        public DataTable Inventario_SuministroTodo()
        {
            CDInventario_Suministro objInventario_Suministro = new CDInventario_Suministro();
            return objInventario_Suministro.Inventario_SuministroTodo();
        }

        public static int Inventario_SuministroEliminar(string parametro)
        {
            CDInventario_Suministro objInventario_Suministro = new CDInventario_Suministro();
            return objInventario_Suministro.Inventario_SuministroEliminar(parametro);
        }
    }
}