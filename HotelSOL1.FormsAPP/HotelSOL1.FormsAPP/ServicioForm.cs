using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class ServicioForm : Form
    {
        private readonly ServicioService servicioService;
        private readonly ReservaService reservaService;
        private readonly FacturaService facturaService;
        private readonly int reservaId;

        public ServicioForm(int reservaId, ServicioService servicioService, ReservaService reservaService, FacturaService facturaService)
        {
            InitializeComponent();
            this.reservaId = reservaId;
            this.servicioService = servicioService;
            this.reservaService = reservaService;
            this.facturaService = facturaService;

            CargarServiciosDisponibles(); // ✅ Mostrar servicios extra
        }

        private void CargarServiciosDisponibles()
        {
            cmbServicios.Items.Clear();
            cmbServicios.Items.AddRange(Enum.GetNames(typeof(TipoServicio))); // 🔹 Mostrar tipos de servicio
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServicios.SelectedItem == null || string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("❌ Debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TipoServicio tipoServicio = (TipoServicio)Enum.Parse(typeof(TipoServicio), cmbServicios.SelectedItem.ToString());
                string descripcion = txtDescripcion.Text;
                decimal precio;

                if (!decimal.TryParse(txtPrecio.Text, out precio))
                {
                    MessageBox.Show("❌ Ingresa un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool aplicarDescuento = chkDescuento.Checked; // 🔹 Aplicar descuento si el cliente es VIP

                servicioService.RegistrarServicio(reservaId, tipoServicio, descripcion, precio, aplicarDescuento);

                MessageBox.Show("✅ Servicio agregado correctamente!");
                CargarServiciosSeleccionados(); // 🔹 Refrescar la lista de servicios
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al agregar el servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarServiciosSeleccionados()
        {
            var servicios = servicioService.ObtenerServiciosPorReserva(reservaId);

            dgvServicios.DataSource = servicios.Select(s => new
            {
                s.Id,
                Tipo = s.Tipo.ToString(),
                s.Descripcion,
                Precio = $"${s.Precio:F2}",
                Pagado = s.FacturaId.HasValue ? "Sí" : "No"
            }).ToList();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
