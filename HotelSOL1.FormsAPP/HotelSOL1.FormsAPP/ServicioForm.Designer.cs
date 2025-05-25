using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class ServicioForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private ListView listViewServicios;
        private CheckBox chkDescuento;
        private Button btnAgregarServicio, btnCerrar;
        private DataGridView dgvServicios;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(900, 600);
            this.Text = "Agregar Servicios Extras";
            this.BackColor = Color.White;

            lblTitulo = new Label() { Text = "Selecciona un servicio:", Location = new Point(20, 20), Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true };

            listViewServicios = new ListView() { Location = new Point(20, 50), Size = new Size(500, 200), View = View.Details };
            listViewServicios.Columns.Add("Servicio", 250);
            listViewServicios.Columns.Add("Precio", 150);
            listViewServicios.FullRowSelect = true;

            chkDescuento = new CheckBox() { Text = "Aplicar Descuento VIP", Location = new Point(20, 270), AutoSize = true };

            btnAgregarServicio = new Button() { Text = "Agregar", Location = new Point(20, 300), Size = new Size(100, 40) };
            btnCerrar = new Button() { Text = "Cerrar", Location = new Point(140, 300), Size = new Size(100, 40) };

            dgvServicios = new DataGridView() { Location = new Point(20, 350), Size = new Size(550, 200), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            this.Controls.AddRange(new Control[] { lblTitulo, listViewServicios, chkDescuento, btnAgregarServicio, btnCerrar, dgvServicios });

            btnAgregarServicio.Click += new EventHandler(btnAgregarServicio_Click);
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            this.ResumeLayout(false);
        }
    }
}
