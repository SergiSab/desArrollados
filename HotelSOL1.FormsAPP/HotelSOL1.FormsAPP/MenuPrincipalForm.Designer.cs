namespace HotelSOL1.FormsAPP
{
    partial class MenuPrincipalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnRegistrarUsuario;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.Button btnCrearReserva;
        private System.Windows.Forms.Button btnVerReservas;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button btnExportarOdoo;
        private System.Windows.Forms.Button btnGestionHabitaciones; // 🔹 Nuevo botón
        private System.Windows.Forms.Button btnSalir, btnPagos; 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalForm));
            lblUsuario = new Label();
            btnRegistrarUsuario = new Button();
            btnRegistrarCliente = new Button();
            btnCrearReserva = new Button();
            btnVerReservas = new Button();
            btnGenerarFactura = new Button();
            btnExportarOdoo = new Button();
            btnGestionHabitaciones = new Button();
            btnSalir = new Button();
            btnPagos = new Button();
            btnContabilidad = new Button();
            btnStockProveedores = new Button();
            pbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblUsuario.Location = new Point(20, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(200, 24);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Bienvenido, Usuario";
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(72, 218);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(220, 50);
            btnRegistrarUsuario.TabIndex = 1;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.Location = new Point(412, 218);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(220, 50);
            btnRegistrarCliente.TabIndex = 2;
            btnRegistrarCliente.Text = "Registrar Cliente";
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnCrearReserva
            // 
            btnCrearReserva.Location = new Point(72, 348);
            btnCrearReserva.Name = "btnCrearReserva";
            btnCrearReserva.Size = new Size(220, 50);
            btnCrearReserva.TabIndex = 3;
            btnCrearReserva.Text = "Crear Reserva";
            btnCrearReserva.Click += btnCrearReserva_Click;
            // 
            // btnVerReservas
            // 
            btnVerReservas.Location = new Point(412, 348);
            btnVerReservas.Name = "btnVerReservas";
            btnVerReservas.Size = new Size(220, 50);
            btnVerReservas.TabIndex = 4;
            btnVerReservas.Text = "Ver Reservas";
            btnVerReservas.Click += btnVerReservas_Click;
            // 
            // btnGenerarFactura
            // 
            btnGenerarFactura.Location = new Point(756, 348);
            btnGenerarFactura.Name = "btnGenerarFactura";
            btnGenerarFactura.Size = new Size(220, 50);
            btnGenerarFactura.TabIndex = 5;
            btnGenerarFactura.Text = "Generar Factura";
            btnGenerarFactura.Click += btnGenerarFactura_Click;
            // 
            // btnExportarOdoo
            // 
            btnExportarOdoo.Location = new Point(756, 218);
            btnExportarOdoo.Name = "btnExportarOdoo";
            btnExportarOdoo.Size = new Size(220, 50);
            btnExportarOdoo.TabIndex = 6;
            btnExportarOdoo.Text = "Exportar datos a Odoo";
            btnExportarOdoo.Click += btnExportarOdoo_Click;
            // 
            // btnGestionHabitaciones
            // 
            btnGestionHabitaciones.Location = new Point(72, 471);
            btnGestionHabitaciones.Name = "btnGestionHabitaciones";
            btnGestionHabitaciones.Size = new Size(220, 50);
            btnGestionHabitaciones.TabIndex = 7;
            btnGestionHabitaciones.Text = "Gestión de Habitaciones";
            btnGestionHabitaciones.Click += btnGestionHabitaciones_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(255, 128, 128);
            btnSalir.ForeColor = Color.FromArgb(255, 255, 128);
            btnSalir.Location = new Point(412, 559);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(220, 50);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnPagos
            // 
            btnPagos.Location = new Point(0, 0);
            btnPagos.Name = "btnPagos";
            btnPagos.Size = new Size(75, 23);
            btnPagos.TabIndex = 0;
            // 
            // btnContabilidad
            // 
            btnContabilidad.Location = new Point(412, 471);
            btnContabilidad.Name = "btnContabilidad";
            btnContabilidad.Size = new Size(220, 50);
            btnContabilidad.TabIndex = 9;
            btnContabilidad.Text = "Contabilidad";
            btnContabilidad.Click += btnContabilidad_Click;
            // 
            // btnStockProveedores
            // 
            btnStockProveedores.Location = new Point(756, 471);
            btnStockProveedores.Name = "btnStockProveedores";
            btnStockProveedores.Size = new Size(220, 50);
            btnStockProveedores.TabIndex = 10;
            btnStockProveedores.Text = "Proveedores y stock";
            btnStockProveedores.Click += btnStockProveedores_Click;
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(461, 44);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(130, 130);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 11;
            pbLogo.TabStop = false;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1029, 645);
            Controls.Add(pbLogo);
            Controls.Add(btnStockProveedores);
            Controls.Add(btnContabilidad);
            Controls.Add(lblUsuario);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(btnCrearReserva);
            Controls.Add(btnVerReservas);
            Controls.Add(btnGenerarFactura);
            Controls.Add(btnExportarOdoo);
            Controls.Add(btnGestionHabitaciones);
            Controls.Add(btnSalir);
            Name = "MenuPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HotelSOL - Menú Principal";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnContabilidad;
        private Button btnStockProveedores;
        private PictureBox pbLogo;
    }
}
