using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class PagoForm
    {
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlPago;
        private System.Windows.Forms.Label lblMonto, lblMetodoPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Button btnRegistrarPago, btnCerrar;
        private System.Windows.Forms.DataGridView dgvPagos;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registrar Pago";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado dinámicamente
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 30);

            // 🔹 Crear un Panel transparente para el formulario de pago
            pnlPago = new Panel();
            pnlPago.Size = new Size(500, 300);
            pnlPago.Location = new Point(
                (this.ClientSize.Width - pnlPago.Width) / 2,
                (this.ClientSize.Height - pnlPago.Height) / 2 + 40
            );
            pnlPago.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlPago.Padding = new Padding(20, 40, 20, 20);

            this.Controls.Add(pnlPago);
            this.Controls.Add(pbLogo);
            pnlPago.BringToFront();

            // 📌 DATAGRIDVIEW - Historial de pagos
            dgvPagos = new DataGridView();
            dgvPagos.Location = new Point(20, 20);
            dgvPagos.Size = new Size(460, 150);
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.AllowUserToAddRows = false;
            pnlPago.Controls.Add(dgvPagos);

            // 💡 Campos dentro del panel
            lblMonto = new Label() { Text = "Monto:", Location = new Point(20, 180), ForeColor = Color.Black, AutoSize = true };
            txtMonto = new TextBox() { Location = new Point(120, 180), Size = new Size(150, 30), BackColor = Color.White, ForeColor = Color.Black };

            lblMetodoPago = new Label() { Text = "Método de Pago:", Location = new Point(20, 220), ForeColor = Color.Black, AutoSize = true };
            cmbMetodoPago = new ComboBox() { Location = new Point(150, 220), Size = new Size(200, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbMetodoPago.Items.AddRange(new string[] { "Tarjeta", "Efectivo", "Transferencia" });

            btnRegistrarPago = new Button() { Text = "Registrar Pago", Location = new Point(20, 260), Size = new Size(200, 40), BackColor = Color.LightGreen };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(280, 260), Size = new Size(200, 40), BackColor = Color.LightCoral };

            // 🔗 Agregar controles al panel
            pnlPago.Controls.Add(lblMonto);
            pnlPago.Controls.Add(txtMonto);
            pnlPago.Controls.Add(lblMetodoPago);
            pnlPago.Controls.Add(cmbMetodoPago);
            pnlPago.Controls.Add(btnRegistrarPago);
            pnlPago.Controls.Add(btnCerrar);

            // 🔗 Agregar funcionalidad a los botones
            btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}
