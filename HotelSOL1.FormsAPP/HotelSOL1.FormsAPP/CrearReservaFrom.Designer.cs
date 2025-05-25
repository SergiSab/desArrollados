using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class CrearReservaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCliente, lblHabitaciones, lblPersonas, lblEntrada, lblSalida, lblTipoHabitacion, lblPrecioBase;
        protected ComboBox cmbClientes, cmbTipo;
        protected CheckedListBox clbHabitaciones;
        protected NumericUpDown numPersonas;
        protected DateTimePicker dtpEntrada, dtpSalida;
        protected Button btnBuscarHabitaciones, btnGuardarReserva, btnCancelar;
        private PictureBox pbLogo, picHabitacion;
        private Panel pnlReserva;
        protected TextBox txtPrecio;
        private Button btnServiciosExtra; // 🔹 Declaramos el botón como variable de la clase

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
            this.ClientSize = new Size(950, 650); // 🔹 Un poco más grande para mejor distribución
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Reservar Habitación";
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
            pnlReserva = new Panel();
            pnlReserva.Size = new Size(650, 500); // 🔹 Más ancho para mejor distribución
            pnlReserva.Location = new Point(
                (this.ClientSize.Width - pnlReserva.Width) / 2,
                (this.ClientSize.Height - pnlReserva.Height) / 2 + 40
            );
            pnlReserva.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlReserva.Padding = new Padding(20, 40, 20, 20);
            btnServiciosExtra = new Button() { Text = "Seleccionar Servicios Extra", Location = new Point(380, 450), Size = new Size(200, 30), BackColor = Color.LightBlue };
            pnlReserva.Controls.Add(btnServiciosExtra);

            btnServiciosExtra.Click += new EventHandler(btnServiciosExtra_Click);
            btnServiciosExtra = new Button() { Text = "Seleccionar Servicios Extra", Location = new Point(380, 450), Size = new Size(200, 30), BackColor = Color.LightBlue };
            pnlReserva.Controls.Add(btnServiciosExtra);
            btnServiciosExtra.Click += new EventHandler(btnServiciosExtra_Click);


            this.Controls.Add(pnlReserva);
            this.Controls.Add(pbLogo);
            pnlReserva.BringToFront();

            // 💡 Configuración de campos dentro del panel
            lblCliente = new Label() { Text = "Cliente:", Location = new Point(20, 20), ForeColor = Color.Black, AutoSize = true };
            cmbClientes = new ComboBox() { Location = new Point(120, 20), Size = new Size(350, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            lblTipoHabitacion = new Label() { Text = "Tipo de Habitación:", Location = new Point(20, 60), ForeColor = Color.Black, AutoSize = true };
            cmbTipo = new ComboBox() { Location = new Point(150, 60), Size = new Size(320, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += new EventHandler(CmbTipo_SelectedIndexChanged);

            lblPersonas = new Label() { Text = "Cantidad de Personas:", Location = new Point(20, 100), ForeColor = Color.Black, AutoSize = true };
            numPersonas = new NumericUpDown() { Location = new Point(180, 100), Size = new Size(100, 30), Minimum = 1, Maximum = 10 };

            lblEntrada = new Label() { Text = "Fecha de Entrada:", Location = new Point(20, 140), ForeColor = Color.Black, AutoSize = true };
            dtpEntrada = new DateTimePicker() { Location = new Point(150, 140), Size = new Size(170, 30), Format = DateTimePickerFormat.Short };

            lblSalida = new Label() { Text = "Fecha de Salida:", Location = new Point(20, 180), ForeColor = Color.Black, AutoSize = true };
            dtpSalida = new DateTimePicker() { Location = new Point(150, 180), Size = new Size(170, 30), Format = DateTimePickerFormat.Short };

            lblPrecioBase = new Label() { Text = "Precio Base:", Location = new Point(20, 330), ForeColor = Color.Black, AutoSize = true };
            txtPrecio = new TextBox() { Location = new Point(120, 330), Size = new Size(150, 30), ReadOnly = true };

            picHabitacion = new PictureBox() { Location = new Point(320, 220), Size = new Size(280, 180), BackColor = Color.LightGray };
            picHabitacion.SizeMode = PictureBoxSizeMode.StretchImage; // 🔹 Ajusta al tamaño del `PictureBox`

            btnBuscarHabitaciones = new Button() { Text = "Buscar", Location = new Point(480, 60), Size = new Size(120, 30) };
            btnGuardarReserva = new Button() { Text = "Guardar", Location = new Point(20, 450), Size = new Size(150, 30) };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(200, 450), Size = new Size(150, 30) };

            pnlReserva.Controls.AddRange(new Control[] { lblCliente, cmbClientes, lblTipoHabitacion, cmbTipo, lblPersonas, numPersonas, lblEntrada, dtpEntrada, lblSalida, dtpSalida,  lblPrecioBase, txtPrecio, picHabitacion, btnBuscarHabitaciones, btnGuardarReserva, btnCancelar });

            btnBuscarHabitaciones.Click += new EventHandler(btnBuscarHabitaciones_Click);
            btnGuardarReserva.Click += new EventHandler(btnGuardarReserva_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);

            this.ResumeLayout(false);
        }
    }
}

