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
            this.servicioService = servicioService ?? throw new ArgumentNullException(nameof(servicioService));
            this.reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
            this.facturaService = facturaService ?? throw new ArgumentNullException(nameof(facturaService));

            CargarServiciosDisponibles();
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (listViewServicios.SelectedItems.Count == 0)
            {
                MessageBox.Show("❌ Debes seleccionar un servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var servicioSeleccionado = (TipoServicioEntity)listViewServicios.SelectedItems[0].Tag;
            servicioService.RegistrarServicio(reservaId, servicioSeleccionado.Id, chkDescuento.Checked);

            MessageBox.Show($"✅ Servicio '{servicioSeleccionado.Descripcion}' agregado correctamente!");
            ActualizarFactura();
        }

        private void CargarServiciosDisponibles()
        {
            listViewServicios.Items.Clear();
            var servicios = servicioService.ObtenerTiposServicios();

            foreach (var servicio in servicios)
            {
                var item = new ListViewItem(servicio.Descripcion);
                item.SubItems.Add($"${servicio.Precio:F2}");
                item.Tag = servicio;
                listViewServicios.Items.Add(item);
            }
        }

        private void ActualizarFactura()
        {
            dgvServicios.DataSource = servicioService.ObtenerServiciosPorReserva(reservaId)
                .Select(s => new
                {
                    s.Id,
                    Tipo = s.TipoServicio.Descripcion,
                    Precio = $"${s.TipoServicio.Precio:F2}",
                    Pagado = s.FacturaId.HasValue ? "Sí" : "No"
                })
                .ToList();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
