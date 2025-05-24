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
    public class CNReserva
    {

        public static string ReservaInsertar(int id_cliente, int id_habitacion, DateTime fecha_reserva,
            DateTime fecha_entrada, DateTime fecha_salida, string estado_reserva, out int id_reserva)
        {
            id_reserva = 0;

            CDReserva objReserva = new CDReserva();
            objReserva.id_cliente = id_cliente;
            objReserva.id_habitacion = id_habitacion;
            objReserva.fecha_reserva = fecha_reserva;
            objReserva.fecha_ingreso = fecha_entrada;
            objReserva.fecha_salida = fecha_salida;
            objReserva.estado_reserva = estado_reserva;

            string resultado = objReserva.ReservaInsertar(objReserva);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_reserva = nuevoId;
                    return "Reserva registrada correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string ReservaActualizar(int id_reserva, int id_cliente, int id_habitacion, DateTime fecha_reserva,
            DateTime fecha_entrada, DateTime fecha_salida, string estado_reserva)
        {
            CDReserva objReserva = new CDReserva();
            objReserva.id_reserva = id_reserva;
            objReserva.id_cliente = id_cliente;
            objReserva.id_habitacion = id_habitacion;
            objReserva.fecha_reserva = fecha_reserva;
            objReserva.fecha_ingreso = fecha_entrada;
            objReserva.fecha_salida = fecha_salida;
            objReserva.estado_reserva = estado_reserva;

            return objReserva.ReservaActualizar(objReserva);
        }

        public DataTable ReservaConsultar(string parametro)
        {
            CDReserva objReserva = new CDReserva();
            return objReserva.ReservaConsultar(parametro);
        }

        public DataTable ReservaTodo()
        {
            CDReserva objReserva = new CDReserva();
            return objReserva.ReservaTodo();
        }

        public static int ReservaEliminar(string id_reserva)
        {
            CDReserva objReserva = new CDReserva();
            return objReserva.ReservaEliminar(id_reserva);
        }
    }
}
