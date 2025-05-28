using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class PagoForm : Form
    {
        private readonly PagoService pagoService;
        private readonly int facturaId;

        public PagoForm(int facturaId, PagoService pagoService)
        {
            InitializeComponent();
            this.pagoService = pagoService;
            this.facturaId = facturaId;

            CargarMontoFactura(); // ✅ Cargar el monto automáticamente
            CargarPagos();
        }

        private void CargarMontoFactura()
        {
            var factura = pagoService.ObtenerFacturaPorId(facturaId);

            if (factura == null)
            {
                MessageBox.Show("❌ Error: No se encontró la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMonto.Text = factura.MontoTotal.ToString("F2"); // ✅ Mostrar automáticamente el monto total
            txtMonto.ReadOnly = true; // 🔹 Evita que el usuario edite el monto
        }


        private void CargarPagos()
        {
            var pagos = pagoService.ObtenerPagosPorFactura(facturaId);

            if (pagos.Count == 0)
            {
                MessageBox.Show("📌 No hay pagos registrados para esta factura.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPagos.Visible = false;
                return;
            }

            dgvPagos.Visible = true;
            dgvPagos.DataSource = pagos.Select(p => new
            {
                p.Id,
                Monto = $"${p.Monto:F2}",
                Método = p.MetodoPago,
                Fecha = p.FechaPago.ToString("dd/MM/yyyy")
            }).ToList();
        }


        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMetodoPago.SelectedItem == null)
                {
                    MessageBox.Show("❌ Selecciona un método de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string metodoPago = cmbMetodoPago.SelectedItem.ToString();
                pagoService.RegistrarPago(facturaId, metodoPago);

                MessageBox.Show("✅ Pago registrado correctamente!");
                CargarPagos(); // ✅ Refrescar la lista de pagos
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al registrar pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
