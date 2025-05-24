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
    public class CNRol
    {
    
        public static string RolInsertar(string nombre_rol, string descripcion_rol, out int id_rol)
        {
            id_rol = 0;

            CDRol objRol = new CDRol();
            objRol.nombre_rol = nombre_rol;
            objRol.descripcion_rol = descripcion_rol;

            string resultado = objRol.RolInsertar(objRol);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_rol = nuevoId;
                    return "Rol insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }
        
        public static string RolActualizar(int id_rol, string nombre_rol, string descripcion_rol)
        {
            CDRol objRol = new CDRol();
            objRol.id_rol = id_rol;
            objRol.nombre_rol = nombre_rol;
            objRol.descripcion_rol = descripcion_rol;
            return objRol.RolActualizar(objRol);
        }
      
        public DataTable RolConsultar(string parametro)
        {
            CDRol objRol = new CDRol();
            return objRol.RolConsultar(parametro);
        }

        public DataTable RolTodo()
        {
            CDRol objRol = new CDRol();
            return objRol.RolTodo();
        }

        public static int RolEliminar(string id_rol)
        {
            CDRol objRol = new CDRol();
            return objRol.RolEliminar(id_rol);
        }

    }
}