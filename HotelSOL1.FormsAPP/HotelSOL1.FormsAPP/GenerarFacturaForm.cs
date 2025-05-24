using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class GenerarFacturaForm : Form
    {
        private readonly FacturaService facturaService;
        private readonly Reserva reserva;
        private readonly Usuario usuarioAutenticado;

        public GenerarFacturaForm(Reserva reserva , FacturaService facturaService)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.facturaService = facturaService;
        }

        private void CargarFacturas()
        {
            List<Factura> facturas;

            if (usuarioAutenticado.Rol == "Cliente")
            {
                // 🔹 Los clientes solo ven sus propias facturas
                facturas = facturaService.ObtenerFacturasPorCliente(usuarioAutenticado.Id);
            }
            else
            {
                // 🔹 Todos los demás roles ven todas las facturas
                facturas = facturaService.ObtenerFacturasPorCliente(0); // `0` traerá todas
            }

            dgvFacturas.DataSource = facturas.Select(f => new
            {
                f.Id,
                Cliente = f.ClienteId,
                Total = f.MontoTotal,
                Estado = f.Pagada ? "Pagada" : "Pendiente",
                Fecha = f.FechaEmision
            }).ToList();
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = facturaService.GenerarFactura(reserva.Id, 0);
                lblMonto.Text = "Monto Total: $" + factura.MontoTotal.ToString("0.00");
                MessageBox.Show("Factura generada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void lblFechaEntrada_Click(object sender, EventArgs e)
        {
            // Método vacío para evitar errores de referencia
        }

        private void lblFechaSalida_Click(object sender, EventArgs e)
        {
            // Método vacío para evitar errores de referencia
        }

        private void lblCliente_Click(object sender, EventArgs e)
        {
            // Método vacío para evitar errores de referencia
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }

    }
}

