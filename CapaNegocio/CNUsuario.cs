using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaNegocio.CNUsuario;
using System.Security.Claims;

namespace CapaNegocio
{
    public class CNUsuario
    {

        public static string UsuarioInsertar(int id_empleado, int id_rol, string nombre, string clave, DateTime fecha_registro, string estado_usuario, out int id_usuario)
        {
            id_usuario = 0;

            CDUsuario objUsuario = new CDUsuario();
            objUsuario.id_empleado = id_empleado;
            objUsuario.id_rol = id_rol;
            objUsuario.nombre = nombre;
            objUsuario.clave = clave;
            objUsuario.fecha_registro = fecha_registro;
            objUsuario.estado_usuario = estado_usuario;

            string resultado = objUsuario.UsuarioInsertar(objUsuario);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_usuario = nuevoId;
                    return "Usuario insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string UsuarioActualizar(int id_usuario, int id_empleado, int id_rol, string nombre, string clave, DateTime fecha_registro, string estado_usuario) { 
        
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.id_usuario = id_usuario;
            objUsuario.id_empleado = id_empleado;
            objUsuario.id_rol = id_rol;
            objUsuario.nombre = nombre;
            objUsuario.clave = clave;
            objUsuario.fecha_registro = fecha_registro;
            objUsuario.estado_usuario = estado_usuario;
            return objUsuario.UsuarioActualizar(objUsuario);
        }

        public DataTable UsuarioConsultar(string parametro)
        {
            CDUsuario objUsuario = new CDUsuario();
            return objUsuario.UsuarioConsultar(parametro);
        }

        public DataTable UsuarioTodo()
        {
            CDUsuario objUsuario = new CDUsuario();
            return objUsuario.UsuarioTodo();
        }

        public static int UsuarioEliminar(string parametro)
        {
            CDUsuario objUsuario = new CDUsuario();
            return objUsuario.UsuarioEliminar(parametro);
        }

        public int IniciarSesion(string usuario, string clave)
        {
            CDUsuario objUsuario = new CDUsuario();
            return objUsuario.ValidarUsuario(usuario, clave);
        }
    }
}
