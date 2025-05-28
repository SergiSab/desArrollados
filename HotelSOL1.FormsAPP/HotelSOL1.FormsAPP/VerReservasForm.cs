using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class VerReservasForm : Form
    {
        private readonly ReservaService _reservaService;
        public Reserva ReservaSeleccionada { get; private set; }

        public VerReservasForm(ReservaService reservaService)
        {
            InitializeComponent();
            _reservaService = reservaService;
            this.Load += new EventHandler(this.VerReservasForm_Load);

        }

        private void VerReservasForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtén las reservas de la base de datos
                List<Reserva> reservas = _reservaService.ObtenerReservas();

                // Asegúrate de que tienes un DataGridView con el nombre dgvReservas
                dgvReservas.DataSource = reservas;

                // Configura las columnas, si es necesario
                if (dgvReservas.Columns["Id"] != null)
                {
                    dgvReservas.Columns["Id"].HeaderText = "ID Reserva";
                }
                if (dgvReservas.Columns["FechaInicio"] != null)
                {
                    dgvReservas.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                }
                if (dgvReservas.Columns["FechaFin"] != null)
                {
                    dgvReservas.Columns["FechaFin"].HeaderText = "Fecha Fin";
                }

                if (dgvReservas.Columns["Estado"] != null)
                {
                    dgvReservas.Columns["Estado"].HeaderText = "Estado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el evento para el botón Ver Detalles
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int reservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["Id"].Value);
                ReservaSeleccionada = _reservaService.ObtenerReservaPorId(reservaId);

                if (ReservaSeleccionada != null)
                {
                    this.DialogResult = DialogResult.OK; // ✅ Indicar que la selección fue exitosa
                    this.Close(); // ✅ Cerrar el formulario de reservas

                    // 📌 Abrir automáticamente la factura después de seleccionar la reserva
                    var facturaService = new FacturaService(Program.DbContext);
                    var usuarioAutenticado = Program.UsuarioAutenticado; // ✅ Obtener usuario autenticado

                    var formFactura = new GenerarFacturaForm(ReservaSeleccionada, facturaService, usuarioAutenticado, Program.DbContext);
                    formFactura.ShowDialog(); // ✅ Abrir factura después de seleccionar la reserva
                }
            }
            else
            {
                MessageBox.Show("Seleccione una reserva de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int reservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["Id"].Value);
                Reserva reservaSeleccionada = _reservaService.ObtenerReservaPorId(reservaId);

                if (reservaSeleccionada != null)
                {
                    var facturaService = new FacturaService(Program.DbContext);
                    var usuarioAutenticado = Program.UsuarioAutenticado; // ✅ Obtener usuario autenticado

                    var formFactura = new GenerarFacturaForm(reservaSeleccionada, facturaService, usuarioAutenticado, Program.DbContext);
                    formFactura.ShowDialog(); // ✅ Abrir factura
                }
            }
            else
            {
                MessageBox.Show("Seleccione una reserva antes de generar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
