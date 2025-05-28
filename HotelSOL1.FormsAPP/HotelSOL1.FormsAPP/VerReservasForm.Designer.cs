using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class ReservasForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pbLogo;
        private Panel pnlReservas, pnlHeader;
        private Label lblTitulo;
        private DataGridView dgvReservas;
        private TextBox txtBuscarCliente;
        private FlowLayoutPanel pnlBotones;
        private Button btnVerDetalles, btnGenerarFactura, btnServicios, btnCheckIn, btnCheckOut, btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Reservas";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 📌 Panel superior (Encabezado)
            pnlHeader = new Panel();
            pnlHeader.Size = new Size(this.ClientSize.Width, 80);
            pnlHeader.BackColor = Color.FromArgb(50, 100, 150); // Azul oscuro elegante
            pnlHeader.Location = new Point(0, 0);

            // 📌 Logo centrado en el encabezado
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(80, 80);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point(20, 0); 

            // 📌 Título de la sección dentro del encabezado
            lblTitulo = new Label();
            lblTitulo.Text = "Gestión de Reservas";
            lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(120, 25);
            lblTitulo.AutoSize = true;

            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(lblTitulo);

            // 📌 Barra de búsqueda (solo para administradores)
            txtBuscarCliente = new TextBox();
            txtBuscarCliente.Location = new Point(20, 100);
            txtBuscarCliente.Size = new Size(250, 30);
            txtBuscarCliente.PlaceholderText = "Buscar cliente...";
            txtBuscarCliente.TextChanged += new EventHandler(this.txtBuscarCliente_TextChanged);

            // 📌 Panel principal para la lista de reservas
            pnlReservas = new Panel();
            pnlReservas.Size = new Size(700, 300);
            pnlReservas.Location = new Point((this.ClientSize.Width - pnlReservas.Width) / 2, 140);
            pnlReservas.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlReservas.Padding = new Padding(20);

            // 📌 Tabla de Reservas
            dgvReservas = new DataGridView();
            dgvReservas.Size = new Size(650, 230);
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(20, 20);

            // 📌 Panel de Botones (alineado)
            pnlBotones = new FlowLayoutPanel();
            pnlBotones.Size = new Size(700, 50);
            pnlBotones.Location = new Point((this.ClientSize.Width - pnlBotones.Width) / 2, 460);
            pnlBotones.FlowDirection = FlowDirection.LeftToRight;

            // 📌 Botones estilizados
            btnVerDetalles = new Button() { Text = "Ver Detalles", Size = new Size(120, 40), BackColor = Color.White };
            btnGenerarFactura = new Button() { Text = "Generar Factura", Size = new Size(120, 40), BackColor = Color.White };
            btnServicios = new Button() { Text = "Servicios", Size = new Size(120, 40), BackColor = Color.White };
            btnCheckIn = new Button() { Text = "Check-In", Size = new Size(120, 40), BackColor = Color.White };
            btnCheckOut = new Button() { Text = "Check-Out", Size = new Size(120, 40), BackColor = Color.White };
            btnSalir = new Button() { Text = "Salir", Size = new Size(120, 40), BackColor = Color.LightGray };

            // 📌 Asignar eventos
            btnVerDetalles.Click += new EventHandler(this.btnVerDetalles_Click);
            btnGenerarFactura.Click += new EventHandler(this.btnGenerarFactura_Click);
            btnServicios.Click += new EventHandler(this.btnServicios_Click);
            btnCheckIn.Click += new EventHandler(this.btnCheckIn_Click);
            btnCheckOut.Click += new EventHandler(this.btnCheckOut_Click);
            btnSalir.Click += new EventHandler(this.btnSalir_Click);

            // 📌 Agregar controles
            pnlBotones.Controls.AddRange(new Control[] { btnVerDetalles, btnGenerarFactura, btnServicios, btnCheckIn, btnCheckOut, btnSalir });
            pnlReservas.Controls.Add(dgvReservas);

            this.Controls.Add(pnlHeader);
            this.Controls.Add(txtBuscarCliente);
            this.Controls.Add(pnlReservas);
            this.Controls.Add(pnlBotones);

            pnlReservas.BringToFront();
            this.ResumeLayout(false);
        }
    }
}
