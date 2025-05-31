using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess.Services;

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

            // 📌 Ocultar todos los botones inicialmente
            btnRegistrarCliente.Visible = false;
            btnCrearReserva.Visible = false;
            btnExportarOdoo.Visible = false;
            btnRegistrarUsuario.Visible = false;
            btnGestionHabitaciones.Visible = false;
            btnReservas.Visible = false;
            btnContabilidad.Visible = false;
            btnStockProveedores.Visible = false;
            btnSalir.Visible = false;

            // 📌 Lista de botones que estarán visibles según el rol
            List<Button> botonesVisibles = new List<Button>();

            switch (usuarioAutenticado.Rol)
            {
                case "Administrador":
                    botonesVisibles.AddRange(new[] { btnRegistrarCliente, btnCrearReserva, btnExportarOdoo, btnRegistrarUsuario, btnGestionHabitaciones, btnReservas, btnContabilidad, btnStockProveedores, btnSalir });
                    break;

                case "Encargado":
                    botonesVisibles.Add(btnExportarOdoo);
                    botonesVisibles.Add(btnSalir);
                    break;

                case "Recepcionista":
                    botonesVisibles.Add(btnCrearReserva);
                    botonesVisibles.Add(btnSalir);
                    break;

                case "Cliente":
                    botonesVisibles.AddRange(new[] { btnCrearReserva, btnReservas, btnSalir });
                    break;

                case "Contable":
                    botonesVisibles.Add(btnExportarOdoo);
                    botonesVisibles.Add(btnSalir);
                    break;

                case "Marketing y Publicidad":
                    botonesVisibles.Add(btnExportarOdoo);
                    botonesVisibles.Add(btnSalir);
                    break;

                default:
                    MessageBox.Show("❌ Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            foreach (var boton in botonesVisibles)
            {
                boton.Visible = true; // 📌 Asegura que los botones activos son visibles
                pnlMenu.Controls.Add(boton); // 📌 Agrega cada botón al panel
            }
        }


        // 📌 Ajustar el tamaño de los botones si hay pocos visibles


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
            var options = Program.DbContext;
            var contService = new ContabilidadService(options);
            using var form = new ContabilidadForm(contService);
            form.ShowDialog();
        }

        private void btnStockProveedores_Click(object sender, EventArgs e)
        {

            var form = new StockProveedoresForm();
            form.ShowDialog();
        }


    }
}
