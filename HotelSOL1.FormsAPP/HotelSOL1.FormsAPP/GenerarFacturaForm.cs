using HotelSOL.DataAccess;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL1.FormsAPP
{
    public partial class GenerarFacturaForm : Form
    {
        private readonly FacturaService facturaService;
        private readonly Reserva reserva;
        private readonly Usuario usuarioAutenticado;
        private readonly HotelSolContext _context;
        private readonly ClienteService clienteService; // ✅ Agregar ClienteService

        public GenerarFacturaForm(Reserva reserva, FacturaService facturaService, ClienteService clienteService, Usuario usuarioAutenticado, HotelSolContext context)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.facturaService = facturaService;
            this.clienteService = clienteService; // ✅ Asignarlo correctamente
            this.usuarioAutenticado = usuarioAutenticado;
            this._context = context;
            CargarFacturas();
            AgregarBotonPago();
        }
        private void AgregarBotonPago()
        {
            if (usuarioAutenticado.Rol != "Cliente") // 📌 Si es empleado, mostrar botón
            {
                Button btnRegistrarPago = new Button();
                btnRegistrarPago.Text = "Registrar Pago";
                btnRegistrarPago.Size = new System.Drawing.Size(180, 50);
                btnRegistrarPago.Location = new System.Drawing.Point((pnlFactura.Width - 180) / 2, 420);
                btnRegistrarPago.BackColor = System.Drawing.Color.LightBlue;
                btnRegistrarPago.Click += BtnRegistrarPago_Click;

                pnlFactura.Controls.Add(btnRegistrarPago);
            }
        }

        private void CargarFacturas()
        {
            List<Factura> facturas = usuarioAutenticado.Rol == "Cliente"
                ? facturaService.ObtenerFacturasPorCliente(usuarioAutenticado.Id)
                : facturaService.ObtenerFacturasPorCliente(0); // 🔹 Todas las facturas si es administrador

            if (facturas.Any()) // ✅ Si hay facturas, mostrarlas
            {
                dgvFacturas.Visible = true;
                dgvFacturas.DataSource = facturas.Select(f => new
                {
                    f.Id,
                    Cliente = f.ClienteId,
                    Total = f.MontoTotal.ToString("C"),
                    Estado = f.Pagada ? "✅ Pagada" : "⚠ Pendiente",
                    Fecha = f.FechaEmision.ToString("dd/MM/yyyy")
                }).ToList();
            }
            else
            {
                dgvFacturas.Visible = false; // ❌ Si no hay datos, ocultar la tabla
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = facturaService.GenerarFactura(reserva.Id, 10);

                if (factura == null || factura.Id == 0)
                {
                    throw new Exception("❌ La factura no se generó correctamente.");
                }

                Console.WriteLine($"Factura generada: ID={factura.Id}, Cliente={factura.ClienteId}, Total={factura.MontoTotal}");

                // 📌 ID de la reserva y fechas
                lblFacturaId.Text = $"Factura ID: {factura.Id}";
                lblFechaInicio.Text = $"Fecha Inicio: {reserva.FechaInicio:dd/MM/yyyy}";
                lblFechaFin.Text = $"Fecha Fin: {reserva.FechaFin:dd/MM/yyyy}";
                lblDuracionEstadia.Text = $"Duración: {(reserva.FechaFin - reserva.FechaInicio).Days} días";

                // 📌 Cliente
                var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == factura.ClienteId);
                lblClienteId.Text = cliente != null ? $"Cliente: {cliente.Nombre}" : "⚠ Cliente no definido";
                bool esVIP = cliente?.VIP ?? false;
                lblServiciosTitulo.Text = esVIP ? "🌟 Cliente VIP - Descuento Aplicado" : "Cliente Regular";

                var reservaHabitacion = _context.ReservaHabitaciones
                 .Where(rh => rh.ReservaId == factura.ReservaId)
                 .Include(rh => rh.Habitacion)
                 .ThenInclude(h => h.TipoHabitacion)
                 .FirstOrDefault(); // ✅ Primero obtenemos el objeto validado

                if (reservaHabitacion != null && reservaHabitacion.Habitacion != null && reservaHabitacion.Habitacion.TipoHabitacion != null)
                {
                    lblAlojamiento.Text = $"🏨 Tipo: {reservaHabitacion.Habitacion.TipoHabitacion.Descripcion}";
                    lblPrecioBase.Text = $"Precio Base: {reservaHabitacion.Habitacion.TipoHabitacion.PrecioBase:C}";
                }
                else
                {
                    lblAlojamiento.Text = "🏨 Tipo: ❌ No disponible";
                    lblPrecioBase.Text = "Precio Base: ❌ No disponible";
                }

                // 📌 Servicios consumidos
                var serviciosConsumidos = _context.Servicios
                    .Include(s => s.TipoServicio)
                    .Where(s => s.ReservaId == reserva.Id)
                    .ToList();

                dgvDetalleFactura.DataSource = serviciosConsumidos.Select(s => new
                {
                    Nombre = s.TipoServicio.Descripcion,
                    Precio = s.TipoServicio.Precio,
                    Descuento = s.DescuentoAplicado ? "✅ Descuento VIP" : "❌ Sin descuento"
                }).ToList();

                // 📌 Cálculo de costos
                decimal montoBase = facturaService.CalcularMontoBase(reserva);
                decimal montoServicios = serviciosConsumidos.Sum(s => s.TipoServicio.Precio);
                decimal impuestos = (montoBase + montoServicios) * 0.18m;
                decimal descuentoAplicado = esVIP ? (montoBase + montoServicios) * 0.1m : 0;
                decimal totalPagar = montoBase + montoServicios + impuestos - descuentoAplicado;

                lblPrecioFinal.Text = $"TOTAL: {totalPagar:C}";

                // 📌 Estado de pago
                lblEstado.Text = factura.Pagada ? "✅ Factura Pagada" : "⚠ Pendiente de Pago";
                lblFecha.Text = $"Fecha Emisión: {factura.FechaEmision:dd/MM/yyyy}";

                bool esTemporadaAlta = facturaService.EsTemporadaAlta(reserva.FechaInicio, reserva.FechaFin);
                lblTemporada.Text = esTemporadaAlta ? "🌞 Temporada Alta (+20%)" : "🍃 Temporada Baja";


                MessageBox.Show("Factura generada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFacturas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                MessageBox.Show($"Error generando la factura:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (lblFacturaId.Text == "Factura ID: --")
            {
                MessageBox.Show("❌ No se ha generado ninguna factura aún.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int facturaId = int.Parse(lblFacturaId.Text.Replace("Factura ID: ", "").Trim());
            var ctx = Program.DbContext;
            var contService = new ContabilidadService(ctx);
            var pagoService = new PagoService(ctx, contService);
            var pagoForm = new PagoForm(facturaId, pagoService);
            pagoForm.ShowDialog();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}
