using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HotelSOL.DataAccess;
using HotelSOL.DataAccess.Models;

namespace HotelSOL1.FormsAPP
{
    internal static class Program
    {
        public static HotelSolContext DbContext { get; private set; } = null!;


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializar la configuración
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtener la cadena de conexión y configurar DbContext
            string? connectionString = config.GetConnectionString("HotelDb");
            if (connectionString == null)
            {
                throw new InvalidOperationException("La cadena de conexión no puede ser nula.");
            }

            var options = new DbContextOptionsBuilder<HotelSolContext>()
                .UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                .Options;

            DbContext = new HotelSolContext(options);

            // Iniciar la aplicación Windows Forms con autenticación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new LoginForm())  // 🔹 Mostrar pantalla de login primero
            {
                if (loginForm.ShowDialog() == DialogResult.OK)  // 🔹 Si el login es exitoso
                {
                    Usuario usuarioAutenticado = loginForm.UsuarioAutenticado;
                    Application.Run(new MenuPrincipalForm(usuarioAutenticado));  // 🔹 Pasar usuario al menú
                }
            }
        }

    }
}
