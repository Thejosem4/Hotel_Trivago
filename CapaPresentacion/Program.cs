using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CapaPresentacion
{
    internal static class Program
    {
        public static bool managerinfo = false;
        public static bool managersalida = false;
        public static int controlmov = 0;
        public static bool YaInicializado = false;

        public static string parametro = "1";
        public static int vidcliente = 0;
        public static int vidempleado = 0;
        public static int vidhabitacion = 0;
        public static int vidcargo = 0;
        public static int vidusuario = 0;
        public static int vidinventario = 0;
        public static int vidrol = 0;
        public static int vidinv_suministro = 0;
        public static int vidempresa = 0;
        public static int viddepartamento = 0;
        public static int vidreserva = 0;
        public static int vidfactura = 0;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form nextForm = new FLogin();

            while (nextForm != null)
            {
                nextForm = RunForm(nextForm);
            }
        }

        private static Form RunForm(Form currentForm)
        {
            if (currentForm is FLogin)
            {
                var loginForm = new FLogin();
                loginForm.ShowDialog();

                if (loginForm.LoginExitoso)
                {
                    FMenuMantenimiento formPrincipal = new FMenuMantenimiento();

                    if (!YaInicializado)
                    {
                        YaInicializado = true;
                        Application.Run(formPrincipal);
                    }
                    else
                    {
                        formPrincipal.ShowDialog();
                    }

                    return new FLogin(); // Volver al login después de cerrar el principal
                }
            }

            return null; // Finaliza si el login no fue exitoso
        }
    }
}
