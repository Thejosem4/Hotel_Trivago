using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNEmpleado
    {
        
        public static string EmpleadoInsertar(int id_cargo, int id_departamento, string nombre_empleado, string apellido_empleado, string cedula_empleado, string telefono_empleado,
            string correo_empleado, DateTime fecha_contratacion, DateTime fecha_nac, decimal salario, string estado_empleado, out int id_empleado)
        {
            id_empleado = 0;

            CDEmpleado objEmpleado = new CDEmpleado();
            objEmpleado.id_cargo = id_cargo;
            objEmpleado.id_departamento = id_departamento;
            objEmpleado.nombre_empleado = nombre_empleado;
            objEmpleado.apellido_empleado = apellido_empleado;
            objEmpleado.cedula_empleado = cedula_empleado;
            objEmpleado.telefono_empleado = telefono_empleado;
            objEmpleado.correo_empleado = correo_empleado;
            objEmpleado.fecha_contratacion = fecha_contratacion;
            objEmpleado.fecha_nac = fecha_nac;
            objEmpleado.salario = salario;
            objEmpleado.estado_empleado = estado_empleado;

            string resultado = objEmpleado.EmpleadoInsertar(objEmpleado);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_empleado = nuevoId;
                    return "Empleado insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }
     
        public static string EmpleadoActualizar(int id_empleado, int id_cargo, int id_departamento, string nombre_empleado, string apellido_empleado,string cedula_empleado, string telefono_empleado,
            string correo_empleado, DateTime fecha_contratacion, DateTime fecha_nac, decimal salario, string estado_empleado)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            objEmpleado.id_empleado = id_empleado;
            objEmpleado.id_cargo = id_cargo;
            objEmpleado.id_departamento = id_departamento;
            objEmpleado.nombre_empleado = nombre_empleado;
            objEmpleado.apellido_empleado = apellido_empleado;
            objEmpleado.cedula_empleado = cedula_empleado;
            objEmpleado.telefono_empleado = telefono_empleado;
            objEmpleado.correo_empleado = correo_empleado;
            objEmpleado.fecha_contratacion = fecha_contratacion;
            objEmpleado.fecha_nac = fecha_nac;
            objEmpleado.salario = salario;
            objEmpleado.estado_empleado = estado_empleado;

            return objEmpleado.EmpleadoActualizar(objEmpleado); 
        }
       
        public DataTable EmpleadoConsultar(string parametro)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            return objEmpleado.EmpleadoConsultar(parametro);
        }
        public DataTable EmpleadoTodo()
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            return objEmpleado.EmpleadoTodo();
        }

        public static int EmpleadoEliminar(string parametro)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            return objEmpleado.EmpleadoEliminar(parametro);
        }
    }
}



