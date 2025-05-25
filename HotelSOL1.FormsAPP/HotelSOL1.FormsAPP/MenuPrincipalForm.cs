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

            switch (usuarioAutenticado.Rol)
            {
                case "Administrador":
                    btnRegistrarCliente.Visible = true;
                    btnCrearReserva.Visible = true;
                    btnVerReservas.Visible = true;
                    btnGenerarFactura.Visible = true;
                    btnExportarOdoo.Visible = true;
                    btnRegistrarUsuario.Visible = true;
                    btnGestionHabitaciones.Visible = true;

                    break;

                case "Encargado":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = false;
                    btnVerReservas.Visible = true; // 🔹 Supervisa reservas
                    btnGenerarFactura.Visible = false;
                    btnExportarOdoo.Visible = true;
                    btnRegistrarUsuario.Visible = false;// 🔹 Acceso a gestión de proveedores y pedidos
                    btnGestionHabitaciones.Visible = false;
                    break;

                case "Recepcionista":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = true;
                    btnVerReservas.Visible = true;
                    btnGenerarFactura.Visible = true;
                    btnExportarOdoo.Visible = false;
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    break;

                case "Cliente":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = true;
                    btnVerReservas.Visible = true;
                    btnGenerarFactura.Visible = true;
                    btnExportarOdoo.Visible = false;
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    break;

                case "Contable":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = false;
                    btnVerReservas.Visible = false;
                    btnGenerarFactura.Visible = true; // 🔹 Solo consulta facturas y análisis financiero
                    btnExportarOdoo.Visible = true;
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    break;

                case "Personal Limpieza":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = false;
                    btnVerReservas.Visible = false;
                    btnGenerarFactura.Visible = false;
                    btnExportarOdoo.Visible = false;
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    MessageBox.Show("🔹 Acceso a habitaciones por limpiar.");
                    break;

                case "Personal Restauración":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = false;
                    btnVerReservas.Visible = false;
                    btnGenerarFactura.Visible = false;
                    btnExportarOdoo.Visible = false;
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    MessageBox.Show("🔹 Acceso a pedidos de clientes.");
                    break;

                case "Marketing y Publicidad":
                    btnRegistrarCliente.Visible = false;
                    btnCrearReserva.Visible = false;
                    btnVerReservas.Visible = false;
                    btnGenerarFactura.Visible = false;
                    btnExportarOdoo.Visible = true; // 🔹 Acceso a gestión de redes y descuentos VIP
                    btnRegistrarUsuario.Visible = false;
                    btnGestionHabitaciones.Visible = false;
                    break;

                default:
                    MessageBox.Show("❌ Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
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



        //Botones
        private void btnVerReservas_Click(object sender, EventArgs e)
        {
            var reservaService = new ReservaService(Program.DbContext);
            var form = new VerReservasForm(reservaService);
            form.ShowDialog();
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            var reservaService = new ReservaService(Program.DbContext);
            var facturaService = new FacturaService(Program.DbContext);
            var usuarioAutenticado = Program.UsuarioAutenticado; // 🔹 Asegura que el usuario está autenticado
            if (usuarioAutenticado == null)
            {
                MessageBox.Show("Error: No hay usuario autenticado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Abre el formulario de reservas para que el usuario elija una
            var formReservas = new VerReservasForm(reservaService);
            formReservas.ShowDialog();
            if (formReservas.ReservaSeleccionada != null)
            {
                var reserva = formReservas.ReservaSeleccionada;
                var formFactura = new GenerarFacturaForm(reserva, facturaService, usuarioAutenticado, Program.DbContext); // ✅ Agregar `Program.DbContext`
                formFactura.ShowDialog();
            }

            else
            {
                MessageBox.Show("Seleccione una reserva antes de generar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
