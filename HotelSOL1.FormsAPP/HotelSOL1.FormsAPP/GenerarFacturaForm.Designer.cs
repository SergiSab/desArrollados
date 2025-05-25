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
            this.ClientSize = new System.Drawing.Size(900, 600);  // 🔹 Tamaño correcto
            this.StartPosition = FormStartPosition.CenterScreen;  // 🔹 Centrar el formulario
            this.Text = "Generar Factura";  // 🔹 Título de la ventana
            this.BackColor = Color.White;  // 🔹 Fondo blanco para que la imagen se vea bien

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
            pnlFactura.Size = new System.Drawing.Size(700, 450);
            pnlFactura.Location = new System.Drawing.Point((this.ClientSize.Width - pnlFactura.Width) / 2, 150);
            pnlFactura.BackColor = System.Drawing.Color.FromArgb(220, 240, 240, 240);
            pnlFactura.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);

            // 📌 Título
            lblTitulo = new System.Windows.Forms.Label()
            {
                Text = "Detalles de la Factura",
                Location = new System.Drawing.Point(250, 10),
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkBlue,
                AutoSize = true
            };

            // 📌 Etiquetas para mostrar detalles de la factura
            lblFacturaId = new System.Windows.Forms.Label() { Text = "Factura ID: --", Location = new System.Drawing.Point(20, 50), AutoSize = true };
            lblClienteId = new System.Windows.Forms.Label() { Text = "Cliente ID: --", Location = new System.Drawing.Point(20, 80), AutoSize = true };
            lblMontoTotal = new System.Windows.Forms.Label() { Text = "Total: $0.00", Location = new System.Drawing.Point(20, 110), Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.DarkBlue, AutoSize = true };
            lblEstado = new System.Windows.Forms.Label() { Text = "Estado: --", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            lblFecha = new System.Windows.Forms.Label() { Text = "Fecha: --", Location = new System.Drawing.Point(20, 170), AutoSize = true };

            // 📌 DATAGRIDVIEW - Tabla de Facturas
            dgvFacturas = new System.Windows.Forms.DataGridView();
            dgvFacturas.Location = new System.Drawing.Point(20, 210);
            dgvFacturas.Size = new System.Drawing.Size(650, 150);
            dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 BOTÓN - Generar Factura
            btnGenerarFactura = new System.Windows.Forms.Button() { Text = "Generar Factura", Location = new System.Drawing.Point(20, 380), Size = new System.Drawing.Size(150, 40), BackColor = System.Drawing.Color.LightGreen };
            btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);

            // 📌 BOTÓN - Cerrar
            btnCerrar = new System.Windows.Forms.Button() { Text = "Cerrar", Location = new System.Drawing.Point(520, 380), Size = new System.Drawing.Size(150, 40), BackColor = System.Drawing.Color.LightCoral };
            btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // 📌 Agregar controles al panel
            pnlFactura.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitulo, lblFacturaId, lblClienteId, lblMontoTotal, lblEstado, lblFecha, dgvFacturas, btnGenerarFactura, btnCerrar });

            // 📌 Agregar elementos al formulario
            this.Controls.Add(pbLogo);
            this.Controls.Add(pnlFactura);
            pnlFactura.BringToFront();

            this.ClientSize = new System.Drawing.Size(950, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Factura";

            lblAlojamiento = new System.Windows.Forms.Label()
            {
                Text = "🏨 Tipo de alojamiento: --",
                Location = new System.Drawing.Point(20, 200),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkBlue,
                AutoSize = true
            };

            dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            dgvDetalleFactura.Location = new System.Drawing.Point(20, 240);
            dgvDetalleFactura.Size = new System.Drawing.Size(650, 150);
            dgvDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Agregar controles al formulario
            pnlFactura.Controls.Add(lblAlojamiento);
            pnlFactura.Controls.Add(dgvDetalleFactura);

            this.ResumeLayout(false);


        }
    }
}
