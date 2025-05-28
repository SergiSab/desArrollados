using HotelSOL.DataAccess.Services;
using HotelSOL.DataAccess.Models;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess;

namespace HotelSOL1.FormsAPP
{
    public partial class MenuPrincipalForm : Form
    {
        private Usuario usuarioAutenticado; // 🔹 Guardamos el usuario autenticado

        public MenuPrincipalForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioAutenticado = usuario;

            if (usuarioAutenticado != null)
            {
                lblUsuario.Text = $"Bienvenido, {usuarioAutenticado.Nombre} ({usuarioAutenticado.Rol})";
                ConfigurarMenuSegunRol();
            }
            else
            {
                lblUsuario.Text = "Bienvenido, Usuario desconocido";
            }
        }


        private void ConfigurarMenuSegunRol()
        {
            lblUsuario.Text = $"Bienvenido, {usuarioAutenticado.Nombre} ({usuarioAutenticado.Rol})";

            // 📌 Desactivar todos los botones por defecto
            btnRegistrarCliente.Visible = false;
            btnCrearReserva.Visible = false;
            btnReservas.Visible = false;
            btnExportarOdoo.Visible = false;
            btnRegistrarUsuario.Visible = false;
            btnGestionHabitaciones.Visible = false;

            switch (usuarioAutenticado.Rol)
            {
                case "Administrador":
                    ActivarBotones(btnRegistrarCliente, btnCrearReserva, btnExportarOdoo, btnRegistrarUsuario, btnGestionHabitaciones, btnReservas);
                    break;

                case "Encargado":
                    ActivarBotones(btnExportarOdoo);
                    break;

                case "Recepcionista":
                    ActivarBotones(btnCrearReserva);
                    break;

                case "Cliente":
                    ActivarBotones(btnCrearReserva, btnReservas);
                    break;

                case "Contable":
                    ActivarBotones( btnExportarOdoo);
                    break;

                case "Marketing y Publicidad":
                    ActivarBotones(btnExportarOdoo);
                    break;

                default:
                    MessageBox.Show("❌ Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ActivarBotones(params Button[] botones)
        {
            foreach (var boton in botones)
            {
                boton.Visible = true;
            }
        }



        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            var usuarioService = new UsuarioService(Program.DbContext);
            var form = new RegistrarUsuarioForm(usuarioService);
            form.ShowDialog();
        }


        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            var clienteService = new ClienteService(Program.DbContext);
            var form = new RegistrarClienteForm(clienteService);
            form.ShowDialog();
        }

        private void btnCrearReserva_Click(object sender, EventArgs e)
        {
            var context = Program.DbContext; // 🔹 Obtén la instancia del contexto de base de datos
            var servicioService = new ServicioService(context); // ✅ Agregar esta línea
            var clienteService = new ClienteService(context);
            var habitacionService = new HabitacionService(context);
            var reservaService = new ReservaService(context);
            var facturaService = new FacturaService(context);

            var usuarioAutenticado = Program.UsuarioAutenticado; // 🔹 Asegura que el usuario está autenticado
            if (usuarioAutenticado == null)
            {
                MessageBox.Show("Error: No hay usuario autenticado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new CrearReservaForm(context, usuarioAutenticado, clienteService, habitacionService, reservaService, facturaService, servicioService);
            form.ShowDialog();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            if (Program.UsuarioAutenticado == null)
            {
                MessageBox.Show("❌ No hay usuario autenticado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reservaService = new ReservaService(Program.DbContext);
            var formReservas = new ReservasForm(reservaService);
            formReservas.ShowDialog();
        }




        private void btnGestionHabitaciones_Click(object sender, EventArgs e)
        {
            var habitacionService = new HabitacionService(Program.DbContext);
            var form = new HabitacionForm(habitacionService);
            form.ShowDialog();
        }

        private void btnExportarOdoo_Click(object sender, EventArgs e)
        {
            var form = new ExportarOdooForm();
            form.ShowDialog();
        }
   

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            var form = new ContabilidadForm();
            form.ShowDialog();
        }

        private void btnStockProveedores_Click(object sender, EventArgs e)
        {

            var form = new StockProveedoresForm();
            form.ShowDialog();
        }

       
    }
}
