namespace HotelSOL1.FormsAPP
{
    partial class GenerarFacturaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlFactura;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFacturaId;
        private System.Windows.Forms.Label lblClienteId;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblAlojamiento;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblDuracionEstadia;
        private System.Windows.Forms.Label lblTemporada;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.Label lblPrecioFinal;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new System.Drawing.Size(950, 700);  // ✅ Ajustamos tamaño
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Generar Factura";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 📌 Logo centrado
            pbLogo = new System.Windows.Forms.PictureBox();
            pbLogo.Image = System.Drawing.Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLogo.Size = new System.Drawing.Size(120, 120);
            pbLogo.BackColor = System.Drawing.Color.Transparent;
            pbLogo.Location = new System.Drawing.Point((this.ClientSize.Width - pbLogo.Width) / 2, 10);

            // 📌 Panel para la factura
            pnlFactura = new System.Windows.Forms.Panel();
            pnlFactura.Size = new System.Drawing.Size(750, 500);
            pnlFactura.Location = new System.Drawing.Point((this.ClientSize.Width - pnlFactura.Width) / 2, 140);
            pnlFactura.BackColor = System.Drawing.Color.FromArgb(220, 240, 240, 240);
            pnlFactura.Padding = new System.Windows.Forms.Padding(20);

            // 📌 Título
            lblTitulo = new System.Windows.Forms.Label()
            {
                Text = "Detalles de la Factura",
                Location = new System.Drawing.Point(290, 10),
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkBlue,
                AutoSize = true
            };

            // 📌 Detalles de la Factura
            lblFacturaId = new System.Windows.Forms.Label() { Text = "Factura ID: --", Location = new System.Drawing.Point(20, 50), AutoSize = true };
            lblClienteId = new System.Windows.Forms.Label() { Text = "Cliente ID: --", Location = new System.Drawing.Point(20, 80), AutoSize = true };
            lblMontoTotal = new System.Windows.Forms.Label() { Text = "Total: $0.00", Location = new System.Drawing.Point(20, 110), Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.DarkBlue, AutoSize = true };
            lblEstado = new System.Windows.Forms.Label() { Text = "Estado: --", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            lblFecha = new System.Windows.Forms.Label() { Text = "Fecha Emisión: --", Location = new System.Drawing.Point(20, 170), AutoSize = true };

            // 📌 Detalles de la Reserva
            lblFechaInicio = new System.Windows.Forms.Label() { Text = "Fecha Inicio: --", Location = new System.Drawing.Point(400, 50), AutoSize = true };
            lblFechaFin = new System.Windows.Forms.Label() { Text = "Fecha Fin: --", Location = new System.Drawing.Point(400, 80), AutoSize = true };
            lblDuracionEstadia = new System.Windows.Forms.Label() { Text = "Duración: -- días", Location = new System.Drawing.Point(400, 110), AutoSize = true };
            lblTemporada = new System.Windows.Forms.Label() { Text = "Temporada: --", Location = new System.Drawing.Point(400, 140), AutoSize = true };

            // 📌 Detalles de Alojamiento
            lblAlojamiento = new System.Windows.Forms.Label() { Text = "🏨 Tipo de alojamiento: --", Location = new System.Drawing.Point(20, 200), Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.DarkBlue, AutoSize = true };
            lblPrecioBase = new System.Windows.Forms.Label() { Text = "Precio Base: --", Location = new System.Drawing.Point(400, 200), AutoSize = true };
            lblPrecioFinal = new System.Windows.Forms.Label() { Text = "Precio Final: --", Location = new System.Drawing.Point(400, 230), AutoSize = true };

            // 📌 Tabla de Servicios
            dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            dgvDetalleFactura.Location = new System.Drawing.Point(20, 260);
            dgvDetalleFactura.Size = new System.Drawing.Size(700, 150);
            dgvDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Botones
            btnGenerarFactura = new System.Windows.Forms.Button() { Text = "Generar Factura", Location = new System.Drawing.Point(20, 430), Size = new System.Drawing.Size(180, 45), BackColor = System.Drawing.Color.LightGreen };
            btnCerrar = new System.Windows.Forms.Button() { Text = "Cerrar", Location = new System.Drawing.Point(540, 430), Size = new System.Drawing.Size(180, 45), BackColor = System.Drawing.Color.LightCoral };

            // 📌 Agregar controles al panel
            pnlFactura.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblFacturaId, lblClienteId, lblMontoTotal, lblEstado, lblFecha, lblFechaInicio, lblFechaFin, lblDuracionEstadia, lblTemporada, lblAlojamiento, lblPrecioBase, lblPrecioFinal, dgvDetalleFactura, btnGenerarFactura, btnCerrar });

            // 📌 Agregar elementos al formulario
            this.Controls.Add(pbLogo);
            this.Controls.Add(pnlFactura);
            pnlFactura.BringToFront();

            // 📌 Tabla de Facturas
            dgvFacturas = new System.Windows.Forms.DataGridView();
            dgvFacturas.Location = new System.Drawing.Point(20, 480);
            dgvFacturas.Size = new System.Drawing.Size(700, 120);
            dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Agregar `dgvFacturas` al panel
            pnlFactura.Controls.Add(dgvFacturas);
            btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            pnlFactura.Controls.Add(btnGenerarFactura);
            pnlFactura.Controls.Add(btnCerrar);


            this.ResumeLayout(false);
        }
    }
}
