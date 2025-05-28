using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class CheckInCheckOutForm
    {
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.Label lblTitulo, lblReservaId, lblEstadoActual;
        private System.Windows.Forms.Button btnCheckIn, btnCheckOut, btnCerrar;
        private System.Windows.Forms.PictureBox pbIcono;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registro de Check-In / Check-Out";
            this.BackColor = Color.White;

            // 🎨 Icono superior
            pbIcono = new PictureBox();
            pbIcono.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pbIcono.Size = new Size(100, 100);
            pbIcono.BackColor = Color.Transparent;
            pbIcono.Location = new Point((this.ClientSize.Width - pbIcono.Width) / 2, 20);

            // 🔹 Crear un panel central para el formulario de Check-In/Out
            pnlRegistro = new Panel();
            pnlRegistro.Size = new Size(500, 230);
            pnlRegistro.Location = new Point((this.ClientSize.Width - pnlRegistro.Width) / 2, 140);
            pnlRegistro.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlRegistro.Padding = new Padding(20, 30, 20, 20);

            this.Controls.Add(pnlRegistro);
            this.Controls.Add(pbIcono);
            pnlRegistro.BringToFront();

            // 📌 Etiquetas y texto dentro del panel
            lblTitulo = new Label() { Text = "Gestión de Check-In / Check-Out", Font = new Font("Arial", 14, FontStyle.Bold), Location = new Point(20, 10), ForeColor = Color.Black, AutoSize = true };
            lblReservaId = new Label() { Text = "Reserva ID: --", Location = new Point(20, 50), ForeColor = Color.Black, AutoSize = true };
            lblEstadoActual = new Label() { Text = "Estado: Pendiente", Location = new Point(20, 80), ForeColor = Color.Black, AutoSize = true };

            btnCheckIn = new Button() { Text = "Registrar Check-In", Location = new Point(20, 130), Size = new Size(200, 40), BackColor = Color.LightGreen };
            btnCheckOut = new Button() { Text = "Registrar Check-Out", Location = new Point(260, 130), Size = new Size(200, 40), BackColor = Color.LightSalmon };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(150, 180), Size = new Size(200, 40), BackColor = Color.LightGray };

            // 🔗 Agregar controles al panel
            pnlRegistro.Controls.Add(lblTitulo);
            pnlRegistro.Controls.Add(lblReservaId);
            pnlRegistro.Controls.Add(lblEstadoActual);
            pnlRegistro.Controls.Add(btnCheckIn);
            pnlRegistro.Controls.Add(btnCheckOut);
            pnlRegistro.Controls.Add(btnCerrar);

            // 🔗 Agregar eventos de botones
            btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}

