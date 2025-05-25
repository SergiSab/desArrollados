using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class VerReservasForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pbLogo;
        private Panel pnlReservas;
        private DataGridView dgvReservas;
        private Button btnVerDetalles;

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
            this.Text = "Ver Reservas";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 📌 Logo centrado
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 20);

            // 📌 Panel para las reservas
            pnlReservas = new Panel();
            pnlReservas.Size = new Size(700, 400);
            pnlReservas.Location = new Point((this.ClientSize.Width - pnlReservas.Width) / 2, 160);
            pnlReservas.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlReservas.Padding = new Padding(20);

            // 📌 DataGridView - Tabla de Reservas
            dgvReservas = new DataGridView();
            dgvReservas.Location = new Point(20, 60);
            dgvReservas.Size = new Size(650, 250);
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Botón - Ver Detalles
            btnVerDetalles = new Button()
            {
                Text = "Ver Detalles",
                Location = new Point(270, 330),
                Size = new Size(150, 40),
                BackColor = Color.LightBlue
            };
            btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);

            // 📌 Agregar controles al panel
            pnlReservas.Controls.Add(dgvReservas);
            pnlReservas.Controls.Add(btnVerDetalles);

            // 📌 Agregar elementos al formulario
            this.Controls.Add(pbLogo);
            this.Controls.Add(pnlReservas);
            pnlReservas.BringToFront();

            // 📌 Botón - Generar Factura
            Button btnGenerarFactura = new Button()
            {
                Text = "Generar Factura",
                Location = new Point(450, 330),
                Size = new Size(150, 40),
                BackColor = Color.LightGreen
            };

            // 📌 Agregar evento al botón
            btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);

            // 📌 Agregar botones al panel
            pnlReservas.Controls.Add(btnVerDetalles);
            pnlReservas.Controls.Add(btnGenerarFactura);


            this.ResumeLayout(false);
        }
    }
}
