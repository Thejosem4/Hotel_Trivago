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
    public class CNCargo
    {
        public static string CargoInsertar(string nombre_cargo, string descripcion_cargo, string estado_cargo, out int id_cargo)
        {
            id_cargo = 0;

            CDCargo objCargo = new CDCargo();
            objCargo.nombre_cargo = nombre_cargo;
            objCargo.descripcion_cargo = descripcion_cargo;
            objCargo.estado_cargo = estado_cargo;

            string resultado = objCargo.CargoInsertar(objCargo);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_cargo = nuevoId;
                    return "Cargo insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string CargoActualizar(int id_cargo, string nombre_cargo, string descripcion_cargo, string estado_cargo)
        {
            CDCargo objCargo = new CDCargo();
            objCargo.id_cargo = id_cargo;
            objCargo.nombre_cargo = nombre_cargo;
            objCargo.descripcion_cargo = descripcion_cargo;
            objCargo.estado_cargo = estado_cargo;

            return objCargo.CargoActualizar(objCargo); 
        }
        
        public DataTable CargoConsultar(string parametro)
        {
            CDCargo objCargo = new CDCargo();
            return objCargo.CargoConsultar(parametro); 
        }

        public DataTable CargoTodo()
        {
            CDCargo objCargo = new CDCargo();
            return objCargo.CargoTodo();
        }

        public static int CargoEliminar(string id_cargo)
        {
            CDCargo objCargo = new CDCargo();
            return objCargo.CargoEliminar(id_cargo);
        }
    }
}