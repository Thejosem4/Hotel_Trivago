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
    public class CNEmpresa
    {
        public static string EmpresaInsertar(string nombre_empresa, string correo_empresa, string rnc, string direccion_empresa, string telefono_empresa, string slogan, string gerente, out int id_empresa)
        {
            id_empresa = 0;

            CDEmpresa objEmpresa = new CDEmpresa();
            objEmpresa.nombre_empresa = nombre_empresa;
            objEmpresa.correo_empresa = correo_empresa;
            objEmpresa.rnc = rnc;
            objEmpresa.direccion_empresa = direccion_empresa;
            objEmpresa.telefono_empresa = telefono_empresa;
            objEmpresa.slogan = slogan;
            objEmpresa.gerente = gerente;

            string resultado = objEmpresa.EmpresaInsertar(objEmpresa);

            // Verificar si el resultado contiene el ID
            if (resultado.StartsWith("OK:"))
            {
                // Extraer el ID del mensaje
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_empresa = nuevoId;
                    return "Empresa insertada correctamente!";
                }
            }

            // Si llegamos aquí, hubo un error o no se pudo extraer el ID
            return resultado;
        }

        public static string EmpresaActualizar(int id_empresa, string nombre_empresa, string correo_empresa, string rnc, string direccion_empresa, string telefono_empresa, string slogan, string gerente)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            objEmpresa.id_empresa = id_empresa;
            objEmpresa.nombre_empresa = nombre_empresa;
            objEmpresa.correo_empresa = correo_empresa;
            objEmpresa.rnc = rnc;
            objEmpresa.direccion_empresa = direccion_empresa;
            objEmpresa.telefono_empresa = telefono_empresa;
            objEmpresa.slogan = slogan;
            objEmpresa.gerente = gerente;
            return objEmpresa.EmpresaActualizar(objEmpresa);
        }

        public DataTable EmpresaConsultar(string parametro)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            return objEmpresa.EmpresaConsultar(parametro);
        }

        public DataTable EmpresaTodo()
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            return objEmpresa.EmpresaTodo();
        }

        public static int EmpresaEliminar(string parametro)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            return objEmpresa.EmpresaEliminar(parametro);
        }
    }
}