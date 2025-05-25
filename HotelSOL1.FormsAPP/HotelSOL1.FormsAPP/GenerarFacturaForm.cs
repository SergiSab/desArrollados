using HotelSOL.DataAccess;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                lblFecha.Text = factura.FechaEmision != default ? $"Fecha: {factura.FechaEmision:dd/MM/yyyy}" : "⚠ Fecha no disponible";

                // 🔹 Obtener y mostrar detalles de los servicios contratados
                var serviciosConsumidos = factura.Servicios
                    .Select(s => new
                    {
                        Nombre = s.TipoServicio.Descripcion,
                        Precio = s.TipoServicio.Precio,
                        Descuento = s.DescuentoAplicado ? "✅ Descuento VIP" : "❌ Sin descuento"
                    })
                    .ToList();

                dgvDetalleFactura.DataSource = serviciosConsumidos; // ✅ Mostrar servicios en `DataGridView`

                // 🔹 Obtener y mostrar el tipo de alojamiento
                var alojamiento = _context.ReservaHabitaciones
                    .Where(rh => rh.ReservaId == factura.ReservaId)
                    .Include(rh => rh.Habitacion)
                    .ThenInclude(h => h.TipoHabitacion)
                    .Select(rh => rh.Habitacion.TipoHabitacion.Descripcion)
                    .FirstOrDefault();

                lblAlojamiento.Text = $"🏨 Tipo de alojamiento: {alojamiento}";

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

            int facturaId = int.Parse(lblFacturaId.Text.Replace("Factura ID: ", "").Trim()); // ✅ Extrae el ID de la etiqueta

            var pagoService = new PagoService(Program.DbContext);
            var pagoForm = new PagoForm(facturaId, pagoService);
            pagoForm.ShowDialog();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}
