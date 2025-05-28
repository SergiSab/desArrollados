using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class GenerarFacturaForm
    {
        private PictureBox pbLogo;
        private Panel pnlFactura;
        private DataGridView dgvFacturas, dgvDetalleFactura;
        private Label lblTitulo, lblFacturaId, lblClienteId, lblEstado, lblFecha;
        private Label lblAlojamiento, lblFechaInicio, lblFechaFin, lblDuracionEstadia, lblTemporada, lblPrecioBase;
        private Label lblServiciosTitulo, lblPrecioFinal;
        private Button btnGenerarFactura, btnCerrar;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new Size(900, 700); // ✅ Aumentamos altura para mejor distribución
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Generar Factura";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado arriba
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 10);
            this.Controls.Add(pbLogo);

            // 📌 Primero inicializamos `pnlFactura`
            pnlFactura = new Panel();
            pnlFactura.Size = new Size(750, 520);
            pnlFactura.Location = new Point((this.ClientSize.Width - pnlFactura.Width) / 2, 150);
            pnlFactura.BackColor = Color.FromArgb(220, 240, 240, 240); // ✅ Fondo suave
            pnlFactura.Padding = new Padding(20);
            this.Controls.Add(pnlFactura); // ✅ Agregarlo al formulario ANTES de usarlo

            // 📌 Ahora podemos agregar `dgvFacturas` sin errores
            dgvFacturas = new DataGridView();
            dgvFacturas.Location = new Point(20, 300);
            dgvFacturas.Size = new Size(700, 120);
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pnlFactura.Controls.Add(dgvFacturas); // ✅ Ahora `pnlFactura` ya existe, no habrá error

            // 📌 Título principal
            lblTitulo = new Label()
            {
                Text = "Detalles de la Factura",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point((pnlFactura.Width - 200) / 2, 10)
            };

            // 📌 Distribución en columnas
            int col1 = 30;
            int col2 = 380;
            int fila = 50;

            lblFacturaId = new Label() { Text = "Factura ID: --", Location = new Point(col1, fila), AutoSize = true };
            lblClienteId = new Label() { Text = "Cliente ID: --", Location = new Point(col2, fila), AutoSize = true };

            fila += 30;
            lblEstado = new Label() { Text = "Estado: --", Location = new Point(col1, fila), AutoSize = true };
            lblFecha = new Label() { Text = "Fecha Emisión: --", Location = new Point(col2, fila), AutoSize = true };

            fila += 40;
            lblFechaInicio = new Label() { Text = "Fecha Inicio: --", Location = new Point(col1, fila), AutoSize = true };
            lblFechaFin = new Label() { Text = "Fecha Fin: --", Location = new Point(col2, fila), AutoSize = true };

            fila += 30;
            lblDuracionEstadia = new Label() { Text = "Duración: -- días", Location = new Point(col1, fila), AutoSize = true };
            lblTemporada = new Label() { Text = "Temporada: --", Location = new Point(col2, fila), AutoSize = true };

            fila += 40;
            lblAlojamiento = new Label() { Text = "🏨 Tipo de alojamiento: --", Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue, Location = new Point(col1, fila), AutoSize = true };
            lblPrecioBase = new Label() { Text = "Precio Base: --", Location = new Point(col2, fila), AutoSize = true };

            // 📌 Título de Servicios Extra
            fila += 50;
            lblServiciosTitulo = new Label()
            {
                Text = "Servicios Extra",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                AutoSize = true,
                Location = new Point(20, fila)
            };

            // 📌 Tabla de Servicios
            fila += 30;
            dgvDetalleFactura = new DataGridView();
            dgvDetalleFactura.Location = new Point(20, fila);
            dgvDetalleFactura.Size = new Size(700, 120);
            dgvDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Precio Final en negrita y resaltado
            fila += 140;
            lblPrecioFinal = new Label()
            {
                Text = "TOTAL: $0.00",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true,
                Location = new Point(30, fila)
            };

            // 📌 Botones alineados en la parte inferior
            fila += 50;
            btnGenerarFactura = new Button() { Text = "Generar Factura", Location = new Point(20, fila), Size = new Size(200, 45), BackColor = Color.LightGreen };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(530, fila), Size = new Size(200, 45), BackColor = Color.LightCoral };

            // 📌 Agregar controles al panel
            pnlFactura.Controls.AddRange(new Control[] {
                lblTitulo, lblFacturaId, lblClienteId, lblEstado, lblFecha,
                lblFechaInicio, lblFechaFin, lblDuracionEstadia, lblTemporada, lblAlojamiento,
                lblPrecioBase, lblServiciosTitulo, dgvDetalleFactura, lblPrecioFinal,
                btnGenerarFactura, btnCerrar
            });

            btnGenerarFactura.Click += new EventHandler(this.btnGenerarFactura_Click);
            btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}
