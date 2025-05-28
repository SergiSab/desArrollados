// HotelSOL.DataAccess/Services/PagoService.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class PagoService
    {
        private readonly HotelSolContext _context;
        private readonly ContabilidadService _contService;

        public PagoService(
            HotelSolContext context,
            ContabilidadService contabilidadService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _contService = contabilidadService ?? throw new ArgumentNullException(nameof(contabilidadService));
        }

        /// <summary>
        /// Registra un pago de la factura, marca la factura como pagada si corresponde
        /// y genera el asiento contable (Debe Proveedores, Haber Banco).
        /// </summary>
        public void RegistrarPago(int facturaId, string metodoPago)
        {
            using var tx = _context.Database.BeginTransaction();

            // 1) Cargar la factura con sus pagos
            var factura = _context.Facturas
                                  .Include(f => f.Pagos)
                                  .FirstOrDefault(f => f.Id == facturaId)
                          ?? throw new ArgumentException($"Factura {facturaId} no encontrada.");

            // 2) Crear el pago
            var pago = new Pago
            {
                FacturaId = facturaId,
                Monto = factura.MontoTotal,
                MetodoPago = metodoPago,
                FechaPago = DateTime.Now
            };
            _context.Pagos.Add(pago);
            _context.SaveChanges();

            // 3) Marcar factura como pagada si corresponde
            var totalPagado = factura.Pagos.Sum(p => p.Monto) + pago.Monto;
            if (totalPagado >= factura.MontoTotal)
            {
                factura.Pagada = true;
                _context.SaveChanges();
            }

            // 4) Crear asiento contable
            var asiento = new AsientoContable
            {
                Fecha = DateTime.Now,
                Descripcion = $"Pago factura {factura.NumeroFactura}",
                NumDocumento = factura.NumeroFactura
            };
            asiento = _contService.AddAsiento(asiento);

            // 5) Obtener cuentas contables
            var cuentaProv = _context.Cuentas.Single(c => c.Codigo == "4000"); // Proveedores
            var cuentaBanco = _context.Cuentas.Single(c => c.Codigo == "5720"); // Banco

            // 6a) Línea Debe: Proveedores
            _contService.AddLinea(new LineaAsiento
            {
                AsientoContableId = asiento.Id,
                CuentaId = cuentaProv.Id,
                Debe = pago.Monto,
                Haber = 0m,
                Descripcion = $"Pago factura {factura.NumeroFactura}"
            });

            // 6b) Línea Haber: Banco
            _contService.AddLinea(new LineaAsiento
            {
                AsientoContableId = asiento.Id,
                CuentaId = cuentaBanco.Id,
                Debe = 0m,
                Haber = pago.Monto,
                Descripcion = $"Pago factura {factura.NumeroFactura}"
            });

            tx.Commit();
        }

        /// <summary>
        /// Obtiene una factura junto con sus pagos.
        /// </summary>
        public Factura ObtenerFacturaPorId(int facturaId)
        {
            return _context.Facturas
                           .Include(f => f.Pagos)
                           .FirstOrDefault(f => f.Id == facturaId)
                   ?? throw new ArgumentException($"Factura {facturaId} no encontrada.");
        }

        /// <summary>
        /// Obtiene todos los pagos asociados a una factura.
        /// </summary>
        public List<Pago> ObtenerPagosPorFactura(int facturaId)
        {
            return _context.Pagos
                           .Where(p => p.FacturaId == facturaId)
                           .ToList();
        }

        // … aquí podrías añadir otros métodos relacionados con pagos …
    }
}
