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
        // Variables globales para el control de la aplicación
        public static bool managerinfo = false;
        public static bool managersalida = false;
        public static int controlmov = 0;
        public static bool YaInicializado = false;
        public static string cedulaCliente = string.Empty;

        // Variables para almacenar IDs de diferentes entidades
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

            // Configurar manejo de excepciones no controladas
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            // Inicializar con el formulario de login
            Form nextForm = new FLogin();

            // Bucle principal de la aplicación
            while (nextForm != null)
            {
                nextForm = RunForm(nextForm);
            }
        }

        /// <summary>
        /// Ejecuta un formulario y determina qué formulario debe ejecutarse después
        /// </summary>
        /// <param name="currentForm">El formulario actual a ejecutar</param>
        /// <returns>El próximo formulario a ejecutar, o null para finalizar</returns>
        private static Form RunForm(Form currentForm)
        {
            if (currentForm is FLogin)
            {
                // Usar using para garantizar la disposición correcta del formulario de login
                using (var loginForm = new FLogin())
                {
                    loginForm.ShowDialog();

                    // Si el login fue exitoso, mostrar el menú principal
                    if (loginForm.LoginExitoso)
                    {
                        // Usar using también para el menú principal
                        using (var formPrincipal = new FMenuMantenimiento())
                        {
                            if (!YaInicializado)
                            {
                                // Primera vez que se ejecuta la aplicación
                                YaInicializado = true;
                                Application.Run(formPrincipal);
                            }
                            else
                            {
                                // Ejecuciones subsecuentes
                                formPrincipal.ShowDialog();
                            }
                        }

                        // Después de cerrar el menú principal, volver al login
                        return new FLogin();
                    }
                }
            }

            // Si llegamos aquí, significa que el login no fue exitoso o se cerró la aplicación
            return null;
        }

        /// <summary>
        /// Maneja las excepciones no controladas de la aplicación
        /// </summary>
        /// <param name="sender">El objeto que generó la excepción</param>
        /// <param name="e">Los argumentos de la excepción</param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Error inesperado en la aplicación: " + e.Exception.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
