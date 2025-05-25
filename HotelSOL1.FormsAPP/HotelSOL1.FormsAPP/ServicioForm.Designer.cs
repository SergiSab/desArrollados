using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class ServicioForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo, lblServicio, lblDescripcion, lblPrecio, lblDescuento;
        private ComboBox cmbServicios;
        private TextBox txtDescripcion, txtPrecio;
        private CheckBox chkDescuento;
        private Button btnAgregarServicio, btnCerrar;
        private PictureBox pbLogo;
        private Panel pnlServicio;
        private DataGridView dgvServicios;

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
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Agregar Servicios Extras";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado dinámicamente
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(120, 120);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 10);

            // 🔹 Panel transparente para el formulario
            pnlServicio = new Panel();
            pnlServicio.Size = new Size(600, 400);
            pnlServicio.Location = new Point(
                (this.ClientSize.Width - pnlServicio.Width) / 2,
                (this.ClientSize.Height - pnlServicio.Height) / 2 + 40
            );
            pnlServicio.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlServicio.Padding = new Padding(20, 40, 20, 20);

            this.Controls.Add(pnlServicio);
            this.Controls.Add(pbLogo);
            pnlServicio.BringToFront();

            // 💡 Configuración de campos dentro del panel
            lblTitulo = new Label() { Text = "Selecciona un servicio extra:", Location = new Point(20, 20), ForeColor = Color.Black, Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true };
            cmbServicios = new ComboBox() { Location = new Point(20, 50), Size = new Size(300, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            lblDescripcion = new Label() { Text = "Descripción:", Location = new Point(20, 90), ForeColor = Color.Black, AutoSize = true };
            txtDescripcion = new TextBox() { Location = new Point(20, 120), Size = new Size(300, 30) };

            lblPrecio = new Label() { Text = "Precio:", Location = new Point(20, 160), ForeColor = Color.Black, AutoSize = true };
            txtPrecio = new TextBox() { Location = new Point(20, 190), Size = new Size(100, 30) };

            lblDescuento = new Label() { Text = "Aplicar Descuento VIP:", Location = new Point(20, 230), ForeColor = Color.Black, AutoSize = true };
            chkDescuento = new CheckBox() { Location = new Point(180, 230) };

            btnAgregarServicio = new Button() { Text = "Agregar Servicio", Location = new Point(20, 270), Size = new Size(200, 40), BackColor = Color.LightBlue };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(300, 270), Size = new Size(200, 40), BackColor = Color.LightCoral };

            dgvServicios = new DataGridView() { Location = new Point(20, 320), Size = new Size(550, 150), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            pnlServicio.Controls.AddRange(new Control[] { lblTitulo, cmbServicios, lblDescripcion, txtDescripcion, lblPrecio, txtPrecio, lblDescuento, chkDescuento, btnAgregarServicio, btnCerrar, dgvServicios });

            btnAgregarServicio.Click += new EventHandler(btnAgregarServicio_Click);
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}
