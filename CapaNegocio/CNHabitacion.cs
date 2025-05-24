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
    public class CNHabitacion
    {
        public static string HabitacionInsertar(int capacidad, string tipo_habitacion, string descripcion_hab, decimal precio, out int id_habitacion)
        {
            id_habitacion = 0;

            CDHabitacion objHabitacion = new CDHabitacion();
            objHabitacion.capacidad = capacidad;
            objHabitacion.tipo_habitacion = tipo_habitacion;
            objHabitacion.descripcion_hab = descripcion_hab;
            objHabitacion.precio = precio;

            string resultado = objHabitacion.HabitacionInsertar(objHabitacion);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_habitacion = nuevoId;
                    return "Habitación insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string HabitacionActualizar(int id_habitacion, int capacidad, string tipo_habitacion, string descripcion_hab, decimal precio)
        {
            CDHabitacion objHabitacion = new CDHabitacion();
            objHabitacion.id_habitacion = id_habitacion;
            objHabitacion.capacidad = capacidad;
            objHabitacion.tipo_habitacion = tipo_habitacion;
            objHabitacion.descripcion_hab = descripcion_hab;
            objHabitacion.precio = precio;
            return objHabitacion.HabitacionActualizar(objHabitacion);
        }

        public DataTable HabitacionConsultar(string parametro)
        {
            CDHabitacion objHabitacion = new CDHabitacion();
            return objHabitacion.HabitacionConsultar(parametro);
        }

        public DataTable HabitacionTodo()
        {
            CDHabitacion objHabitacion = new CDHabitacion();
            return objHabitacion.HabitacionTodo();
        }

        public static int HabitacionEliminar(string parametro)
        {
            CDHabitacion objHabitacion = new CDHabitacion();
            return objHabitacion.HabitacionEliminar(parametro);
        }
    }
}