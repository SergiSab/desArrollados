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


        public GenerarFacturaForm(Reserva reserva, FacturaService facturaService, Usuario usuarioAutenticado, HotelSolContext context)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.facturaService = facturaService;
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

                // 📌 Validar ClienteId y FechaEmision antes de asignar
                lblFacturaId.Text = $"Factura ID: {factura.Id}";
                lblClienteId.Text = factura.ClienteId != 0 ? $"Cliente ID: {factura.ClienteId}" : "⚠ Cliente no definido";
                lblMontoTotal.Text = $"Total: {factura.MontoTotal:C}";
                lblEstado.Text = factura.Pagada ? "✅ Pagada" : "⚠ Pendiente";
                lblFecha.Text = factura.FechaEmision != default ? $"Fecha Emisión: {factura.FechaEmision:dd/MM/yyyy}" : "⚠ Fecha no disponible";

                // 🔹 Agregar detalles de la reserva
                lblFechaInicio.Text = $"Fecha Inicio: {reserva.FechaInicio:dd/MM/yyyy}";
                lblFechaFin.Text = $"Fecha Fin: {reserva.FechaFin:dd/MM/yyyy}";
                lblDuracionEstadia.Text = $"Duración: {(reserva.FechaFin - reserva.FechaInicio).Days} días";

                bool esTemporadaAlta = facturaService.EsTemporadaAlta(reserva.FechaInicio, reserva.FechaFin);
                lblTemporada.Text = esTemporadaAlta ? "Temporada: 🌞 Alta" : "Temporada: ❄ Baja";

                // 🔹 Obtener detalles del alojamiento
                var alojamiento = _context.ReservaHabitaciones
                    .Where(rh => rh.ReservaId == factura.ReservaId)
                    .Include(rh => rh.Habitacion)
                    .ThenInclude(h => h.TipoHabitacion)
                    .Select(rh => new
                    {
                        Tipo = (rh.Habitacion != null && rh.Habitacion.TipoHabitacion != null) ? rh.Habitacion.TipoHabitacion.Descripcion : "No definido",
                        PrecioBase = (rh.Habitacion != null && rh.Habitacion.TipoHabitacion != null) ? rh.Habitacion.TipoHabitacion.PrecioBase : 0
                    })

                    .FirstOrDefault();

                // 📌 Validar si el alojamiento existe
                if (alojamiento == null || alojamiento.Tipo == "No definido")
                {
                    lblAlojamiento.Text = "🏨 Tipo de alojamiento: ❌ No disponible";
                    MessageBox.Show("Error: No se pudo obtener el tipo de alojamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Aplicar ajuste de temporada
                decimal tarifaDiaria = alojamiento.PrecioBase;
                if (esTemporadaAlta)
                {
                    tarifaDiaria *= 1.2m;
                }

                decimal costoAlojamiento = facturaService.CalcularMontoBase(reserva);

                // 📌 Mostrar detalles del alojamiento y precios
                lblAlojamiento.Text = $"🏨 Tipo: {alojamiento.Tipo}";
                lblPrecioBase.Text = $"Precio Base: {alojamiento.PrecioBase:C}";
                lblPrecioFinal.Text = $"Precio Final: {costoAlojamiento:C} ({tarifaDiaria:C} por día)";

                // 📌 Mostrar servicios contratados
                if (factura == null || factura.Id == 0)
                {
                    throw new Exception("❌ La factura no se generó correctamente.");
                }

                // 📌 Filtrar solo los servicios que pertenecen a la reserva actual
                var serviciosConsumidos = _context.Servicios
                    .Include(s => s.TipoServicio)
                    .Where(s => s.ReservaId == reserva.Id) // ✅ Filtrar por `ReservaId`
                    .ToList();

                // 📌 Validar si hay servicios asociados a la reserva
                if (!serviciosConsumidos.Any())
                {
                    MessageBox.Show("⚠ No hay servicios asociados a esta reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // ✅ Asignar `FacturaId` a los servicios si es necesario
                foreach (var servicio in serviciosConsumidos)
                {
                    servicio.FacturaId = factura.Id; // ✅ Asigna el `FacturaId` correcto
                    _context.Servicios.Update(servicio);
                }

                _context.SaveChanges(); // ✅ Guardar cambios en la base de datos

                // 📌 Mostrar servicios en `DataGridView`
                dgvDetalleFactura.DataSource = serviciosConsumidos.Select(s => new
                {
                    Nombre = s.TipoServicio.Descripcion,
                    Precio = s.TipoServicio.Precio,
                    Descuento = s.DescuentoAplicado ? "✅ Descuento VIP" : "❌ Sin descuento"
                }).ToList();


                MessageBox.Show("Factura generada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFacturas();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al actualizar la base de datos: {ex.InnerException?.Message}");
                MessageBox.Show($"Error generando la factura:\n{ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
