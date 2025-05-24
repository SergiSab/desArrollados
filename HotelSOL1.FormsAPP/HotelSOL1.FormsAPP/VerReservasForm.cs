using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
