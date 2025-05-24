using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class CrearReservaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCliente, lblHabitaciones, lblPersonas, lblEntrada, lblSalida, lblTipoHabitacion;
        protected ComboBox cmbClientes, cmbTipo;
        protected CheckedListBox clbHabitaciones;
        protected NumericUpDown numPersonas;
        protected DateTimePicker dtpEntrada, dtpSalida;
        protected Button btnBuscarHabitaciones, btnSugerirCombinaciones, btnGuardarReserva, btnCancelar;
        private PictureBox pbLogo;
        private Panel pnlReserva;

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
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2);


            // 🔹 Panel transparente para el formulario
            pnlReserva = new Panel();
            pnlReserva.Size = new Size(550, 450);
            pnlReserva.Location = new Point(
                (this.ClientSize.Width - pnlReserva.Width) / 2,
                (this.ClientSize.Height - pnlReserva.Height) / 2 + 40
            );
            pnlReserva.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlReserva.Padding = new Padding(20, 40, 20, 20);

            this.Controls.Add(pnlReserva);
            this.Controls.Add(pbLogo);
            pnlReserva.BringToFront();

            // 💡 Configuración de campos dentro del panel
            lblCliente = new Label() { Text = "Cliente:", Location = new Point(20, 20), ForeColor = Color.Black, AutoSize = true };
            cmbClientes = new ComboBox() { Location = new Point(20, 50), Size = new Size(350, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            lblTipoHabitacion = new Label() { Text = "Tipo de Habitación:", Location = new Point(20, 90), ForeColor = Color.Black, AutoSize = true };
            cmbTipo = new ComboBox() { Location = new Point(20, 120), Size = new Size(350, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            lblPersonas = new Label() { Text = "Cantidad de Personas:", Location = new Point(20, 150), ForeColor = Color.Black, AutoSize = true };
            numPersonas = new NumericUpDown() { Location = new Point(20, 180), Size = new Size(100, 30), Minimum = 1, Maximum = 10 };

            lblEntrada = new Label() { Text = "Fecha de Entrada:", Location = new Point(20, 220), ForeColor = Color.Black, AutoSize = true };
            dtpEntrada = new DateTimePicker() { Location = new Point(20, 250), Size = new Size(170, 30), Format = DateTimePickerFormat.Short };

            lblSalida = new Label() { Text = "Fecha de Salida:", Location = new Point(220, 220), ForeColor = Color.Black, AutoSize = true };
            dtpSalida = new DateTimePicker() { Location = new Point(220, 250), Size = new Size(170, 30), Format = DateTimePickerFormat.Short };

            lblHabitaciones = new Label() { Text = "Habitaciones disponibles:", Location = new Point(20, 290), ForeColor = Color.Black, AutoSize = true };
            clbHabitaciones = new CheckedListBox() { Location = new Point(20, 320), Size = new Size(370, 70) };

            btnBuscarHabitaciones = new Button() { Text = "Buscar", Location = new Point(400, 120), Size = new Size(100, 30) };
            btnSugerirCombinaciones = new Button() { Text = "Sugerencias", Location = new Point(400, 160), Size = new Size(100, 30) };
            btnGuardarReserva = new Button() { Text = "Guardar", Location = new Point(20, 400), Size = new Size(150, 30) };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(200, 400), Size = new Size(150, 30) };

            pnlReserva.Controls.AddRange(new Control[] { lblCliente, cmbClientes, lblTipoHabitacion, cmbTipo, lblPersonas, numPersonas, lblEntrada, dtpEntrada, lblSalida, dtpSalida, lblHabitaciones, clbHabitaciones, btnBuscarHabitaciones, btnSugerirCombinaciones, btnGuardarReserva, btnCancelar });

            this.ResumeLayout(false);
        }
    }
}
