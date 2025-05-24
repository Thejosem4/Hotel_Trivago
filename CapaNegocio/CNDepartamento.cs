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
    public class CNDepartamento
    {
        public static string DepartamentoInsertar(string nombre_depart, string descripcion_depart, string estado_depart, DateTime fecha_creacion, out int id_departamento)
        {
            id_departamento = 0;

            CDDepartamento objDepartamento = new CDDepartamento();
            objDepartamento.nombre_depart = nombre_depart;
            objDepartamento.descripcion_depart = descripcion_depart;
            objDepartamento.estado_depart = estado_depart;
            objDepartamento.fecha_creacion = fecha_creacion;
            string resultado = objDepartamento.DepartamentoInsertar(objDepartamento);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_departamento = nuevoId;
                    return "Departamento insertado correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }
        public static string DepartamentoActualizar(int id_departamento, string nombre_depart, string descripcion_depart, string estado_depart, DateTime fecha_creacion)
        {
            CDDepartamento objDepartamento = new CDDepartamento();
            objDepartamento.id_departamento = id_departamento;
            objDepartamento.nombre_depart = nombre_depart;
            objDepartamento.descripcion_depart = descripcion_depart;
            objDepartamento.estado_depart = estado_depart;
            objDepartamento.fecha_creacion = fecha_creacion;
            return objDepartamento.DepartamentoActualizar(objDepartamento);
        }
        public DataTable DepartamentoConsultar(string parametro)
        {
            CDDepartamento objDepartamento = new CDDepartamento();
            return objDepartamento.DepartamentoConsultar(parametro);
        }

        public DataTable DepartamentoTodo()
        {
            CDDepartamento objDepartamento = new CDDepartamento();
            return objDepartamento.DepartamentoTodo();
        }

        public static int DepartamentoEliminar(string miparametro)
        {
            CDDepartamento objDepartamento = new CDDepartamento();
            return objDepartamento.DepartamentoEliminar(miparametro);
        }
    }
}
