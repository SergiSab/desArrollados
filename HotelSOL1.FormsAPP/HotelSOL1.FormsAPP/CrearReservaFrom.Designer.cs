using System.Windows.Forms;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Definición de etiquetas
            this.lblCliente = new Label() { Text = "Seleccione Cliente:", Location = new System.Drawing.Point(20, 20) };
            this.lblTipoHabitacion = new Label() { Text = "Tipo de Habitación:", Location = new System.Drawing.Point(20, 60) };
            this.lblHabitaciones = new Label() { Text = "Habitaciones Disponibles:", Location = new System.Drawing.Point(20, 100) };
            this.lblPersonas = new Label() { Text = "Cantidad de Personas:", Location = new System.Drawing.Point(20, 220) };
            this.lblEntrada = new Label() { Text = "Fecha Entrada:", Location = new System.Drawing.Point(20, 260) };
            this.lblSalida = new Label() { Text = "Fecha Salida:", Location = new System.Drawing.Point(20, 300) };

            // Definición de controles
            this.cmbClientes = new ComboBox() { Location = new System.Drawing.Point(150, 20), Size = new System.Drawing.Size(200, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            this.cmbTipo = new ComboBox() { Location = new System.Drawing.Point(150, 60), Size = new System.Drawing.Size(200, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            this.clbHabitaciones = new CheckedListBox() { Location = new System.Drawing.Point(150, 100), Size = new System.Drawing.Size(250, 100) };
            this.numPersonas = new NumericUpDown() { Location = new System.Drawing.Point(150, 220), Size = new System.Drawing.Size(80, 23), Minimum = 1, Maximum = 10 };
            this.dtpEntrada = new DateTimePicker() { Location = new System.Drawing.Point(150, 260), Size = new System.Drawing.Size(200, 23), Format = DateTimePickerFormat.Short };
            this.dtpSalida = new DateTimePicker() { Location = new System.Drawing.Point(150, 300), Size = new System.Drawing.Size(200, 23), Format = DateTimePickerFormat.Short };

            // Definición de botones
            this.btnBuscarHabitaciones = new Button() { Text = "Buscar Habitaciones", Location = new System.Drawing.Point(400, 100), Size = new System.Drawing.Size(150, 30) };
            this.btnSugerirCombinaciones = new Button() { Text = "Sugerir Combinación", Location = new System.Drawing.Point(400, 140), Size = new System.Drawing.Size(150, 30) };
            this.btnGuardarReserva = new Button() { Text = "Guardar Reserva", Location = new System.Drawing.Point(150, 350), Size = new System.Drawing.Size(150, 30) };
            this.btnCancelar = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(320, 350), Size = new System.Drawing.Size(150, 30) };

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[]
            {
                lblCliente, cmbClientes, lblTipoHabitacion, cmbTipo, lblHabitaciones, clbHabitaciones, lblPersonas, numPersonas,
                lblEntrada, dtpEntrada, lblSalida, dtpSalida, btnBuscarHabitaciones, btnSugerirCombinaciones, btnGuardarReserva, btnCancelar
            });

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Text = "Gestor de Reservas";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
