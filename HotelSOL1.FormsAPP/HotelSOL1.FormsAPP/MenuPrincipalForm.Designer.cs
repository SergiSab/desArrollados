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
        private System.Windows.Forms.Button btnSalir;

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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnRegistrarUsuario = new System.Windows.Forms.Button();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.btnCrearReserva = new System.Windows.Forms.Button();
            this.btnVerReservas = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.btnExportarOdoo = new System.Windows.Forms.Button();
            this.btnGestionHabitaciones = new System.Windows.Forms.Button(); // 🔹 Botón nuevo
            this.btnSalir = new System.Windows.Forms.Button();

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(20, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(250, 25);
            this.lblUsuario.Text = "Bienvenido, Usuario";
            this.Controls.Add(this.lblUsuario);

            // Espaciado entre botones
            int espaciado = 70;
            System.Drawing.Size botonSize = new System.Drawing.Size(220, 50);

            // Botones existentes...
            this.btnRegistrarUsuario.Location = new System.Drawing.Point(114, 60);
            this.btnRegistrarUsuario.Size = botonSize;
            this.btnRegistrarUsuario.Text = "Registrar Usuario";
            this.btnRegistrarUsuario.Click += new System.EventHandler(this.btnRegistrarUsuario_Click);
            this.Controls.Add(this.btnRegistrarUsuario);

            this.btnRegistrarCliente.Location = new System.Drawing.Point(114, 60 + espaciado);
            this.btnRegistrarCliente.Size = botonSize;
            this.btnRegistrarCliente.Text = "Registrar Cliente";
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            this.Controls.Add(this.btnRegistrarCliente);

            this.btnCrearReserva.Location = new System.Drawing.Point(114, 60 + 2 * espaciado);
            this.btnCrearReserva.Size = botonSize;
            this.btnCrearReserva.Text = "Crear Reserva";
            this.btnCrearReserva.Click += new System.EventHandler(this.btnCrearReserva_Click);
            this.Controls.Add(this.btnCrearReserva);

            this.btnVerReservas.Location = new System.Drawing.Point(114, 60 + 3 * espaciado);
            this.btnVerReservas.Size = botonSize;
            this.btnVerReservas.Text = "Ver Reservas";
            this.btnVerReservas.Click += new System.EventHandler(this.btnVerReservas_Click);
            this.Controls.Add(this.btnVerReservas);

            this.btnGenerarFactura.Location = new System.Drawing.Point(114, 60 + 4 * espaciado);
            this.btnGenerarFactura.Size = botonSize;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            this.Controls.Add(this.btnGenerarFactura);

            this.btnExportarOdoo.Location = new System.Drawing.Point(114, 60 + 5 * espaciado);
            this.btnExportarOdoo.Size = botonSize;
            this.btnExportarOdoo.Text = "Exportar datos a Odoo";
            this.btnExportarOdoo.Click += new System.EventHandler(this.btnExportarOdoo_Click);
            this.Controls.Add(this.btnExportarOdoo);

            // **Nuevo botón: btnGestionHabitaciones**
            this.btnGestionHabitaciones.Location = new System.Drawing.Point(114, 60 + 6 * espaciado);
            this.btnGestionHabitaciones.Size = botonSize;
            this.btnGestionHabitaciones.Text = "Gestión de Habitaciones";
            this.btnGestionHabitaciones.Click += new System.EventHandler(this.btnGestionHabitaciones_Click);
            this.Controls.Add(this.btnGestionHabitaciones); // 🔹 Agregado al formulario

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(114, 60 + 7 * espaciado);
            this.btnSalir.Size = botonSize;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.Controls.Add(this.btnSalir);

            // Configuración del formulario
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 700); // 🔹 Ajustar tamaño para incluir el nuevo botón
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotelSOL - Menú Principal";

            this.ResumeLayout(false);
        }
    }
}
