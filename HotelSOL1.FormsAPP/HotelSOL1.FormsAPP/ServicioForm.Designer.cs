 using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class ServicioForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pbLogo;
        private Panel pnlServicios;
        private Label lblTitulo;
        private ListView listViewServicios;
        private CheckBox chkDescuento;
        private Button btnAgregarServicio, btnCerrar;
        private DataGridView dgvServicios;

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

            // 🎨 Logo centrado
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 30);

            // 📌 Panel para los servicios
            pnlServicios = new Panel();
            pnlServicios.Size = new Size(600, 400);
            pnlServicios.Location = new Point((this.ClientSize.Width - pnlServicios.Width) / 2, 170);
            pnlServicios.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlServicios.Padding = new Padding(20);

            // 📌 Título
            lblTitulo = new Label()
            {
                Text = "Selecciona un servicio:",
                Location = new Point(20, 10),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true
            };

            // 📌 Lista de Servicios
            listViewServicios = new ListView();
            listViewServicios.Location = new Point(20, 40);
            listViewServicios.Size = new Size(550, 150);
            listViewServicios.View = View.Details;
            listViewServicios.Columns.Add("Servicio", 350);
            listViewServicios.Columns.Add("Precio", 150);
            listViewServicios.FullRowSelect = true;

            // 📌 Checkbox de descuento
            chkDescuento = new CheckBox()
            {
                Text = "Aplicar Descuento VIP",
                Location = new Point(20, 200),
                AutoSize = true
            };

            // 📌 Botones
            btnAgregarServicio = new Button() { Text = "Agregar", Location = new Point(20, 230), Size = new Size(120, 40), BackColor = Color.LightGreen };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(160, 230), Size = new Size(120, 40), BackColor = Color.LightCoral };

            // 📌 Tabla de Servicios
            dgvServicios = new DataGridView();
            dgvServicios.Location = new Point(20, 280);
            dgvServicios.Size = new Size(550, 100);
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // 📌 Agregar controles al panel
            pnlServicios.Controls.AddRange(new Control[] { lblTitulo, listViewServicios, chkDescuento, btnAgregarServicio, btnCerrar, dgvServicios });

            // 📌 Agregar controles al formulario
            this.Controls.Add(pbLogo);
            this.Controls.Add(pnlServicios);
            pnlServicios.BringToFront();

            // 📌 Asignar eventos a los botones
            btnAgregarServicio.Click += new EventHandler(btnAgregarServicio_Click);
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}
