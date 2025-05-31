using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class MenuPrincipalForm
    {
        private PictureBox pbLogo;
        private Panel pnlMenu;
        private Label lblUsuario;
        private Button btnRegistrarUsuario, btnRegistrarCliente, btnCrearReserva, btnReservas;
        private Button btnExportarOdoo, btnGestionHabitaciones, btnContabilidad, btnStockProveedores, btnSalir;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HotelSOL - Menú Principal";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado y más arriba
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 10);
            this.Controls.Add(pbLogo);

            // 📌 Panel para organizar los botones del menú
            pnlMenu = new Panel();
            pnlMenu.Size = new Size(750, 450);  // ✅ Panel más compacto
            pnlMenu.Location = new Point((this.ClientSize.Width - pnlMenu.Width) / 2, 140);
            pnlMenu.BackColor = Color.Transparent;
            pnlMenu.Padding = new Padding(20);

            // 📌 Etiqueta de bienvenida
            lblUsuario = new Label() { Text = "Bienvenido, Usuario", Font = new Font("Arial", 14F, FontStyle.Bold), ForeColor = Color.White, Location = new Point(20, 20), AutoSize = true };

            // 📌 Organización de los botones en tres columnas
            int col1 = 30;
            int col2 = 265;
            int col3 = 500;
            int fila = 60;

            btnRegistrarUsuario = new Button() { Text = "Registrar Usuario", Location = new Point(col1, fila), Size = new Size(200, 50) };
            btnRegistrarCliente = new Button() { Text = "Registrar Cliente", Location = new Point(col3, fila), Size = new Size(200, 50) };
            btnCrearReserva = new Button() { Text = "Crear Reserva", Location = new Point(col2, fila), Size = new Size(200, 50) };

            fila += 70;
            btnExportarOdoo = new Button() { Text = "Exportar a Odoo", Location = new Point(col3, fila), Size = new Size(200, 50) };
            btnReservas = new  Button() { Text = "Reservas", Location = new Point(col2, fila), Size = new Size(200, 50) };
            btnGestionHabitaciones = new Button() { Text = "Gestión de Habitaciones", Location = new Point(col1, fila), Size = new Size(200, 50) };
            fila += 70;

            btnContabilidad = new Button() { Text = "Contabilidad", Location = new Point(col3, fila), Size = new Size(200, 50) };
            btnStockProveedores = new Button() { Text = "Stock & Proveedores", Location = new Point(col1, fila), Size = new Size(200, 50) };

            fila += 70;
 

            // 📌 Botón de salir centrado
            btnSalir = new Button() { Text = "Salir", Location = new Point((pnlMenu.Width - 200) / 2, fila + 80), Size = new Size(200, 50), BackColor = Color.LightCoral };

            // 📌 Agregar controles al panel
            pnlMenu.Controls.AddRange(new Control[] {
                lblUsuario, btnRegistrarUsuario, btnRegistrarCliente, btnCrearReserva, btnExportarOdoo, btnGestionHabitaciones,
                btnReservas, btnContabilidad, btnStockProveedores, btnSalir
            });

            // 📌 Agregar controles al formulario
            this.Controls.Add(pnlMenu);
            pnlMenu.BringToFront();


            // 📌 Asignar funcionalidad a los botones
            btnRegistrarUsuario.Click += new EventHandler(this.btnRegistrarUsuario_Click);
            btnRegistrarCliente.Click += new EventHandler(this.btnRegistrarCliente_Click);
            btnCrearReserva.Click += new EventHandler(this.btnCrearReserva_Click);
            btnExportarOdoo.Click += new EventHandler(this.btnExportarOdoo_Click);
            btnGestionHabitaciones.Click += new EventHandler(this.btnGestionHabitaciones_Click);
            btnContabilidad.Click += new EventHandler(this.btnContabilidad_Click);
            btnStockProveedores.Click += new EventHandler(this.btnStockProveedores_Click);
            btnSalir.Click += new EventHandler(this.btnSalir_Click);
            btnReservas.Click += new EventHandler(this.btnReservas_Click);

            this.ResumeLayout(false);
        }
    }
}
