using System;
using System.Collections.Generic;
using System.Linq;
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class PagoService
    {
        private readonly HotelSolContext _context;

        public PagoService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // 🔹 Registrar un pago parcial o completo de una factura
        public void RegistrarPago(int facturaId, string metodoPago)
        {
            using var transaction = _context.Database.BeginTransaction(); // ✅ Iniciar transacción

            var factura = ObtenerFacturaPorId(facturaId);
            if (factura == null) throw new ArgumentException("Factura no encontrada.");

            decimal montoTotal = factura.MontoTotal;

            var pago = new Pago
            {
                FacturaId = facturaId,
                Monto = montoTotal, // ✅ Tomar directamente el monto de la factura
                MetodoPago = metodoPago,
                FechaPago = DateTime.Now
            };

            _context.Pagos.Add(pago); // ✅ Agregar pago explícitamente a la base de datos
            _context.SaveChanges();

            // 🔹 Verificar si el pago cubre el total y marcar la factura como pagada
            decimal totalPagado = _context.Pagos.Where(p => p.FacturaId == facturaId).Sum(p => p.Monto);
            if (totalPagado >= factura.MontoTotal)
            {
                factura.Pagada = true;
                _context.Update(factura); // ✅ Asegurar que la factura se actualiza
                _context.SaveChanges();
            }

            transaction.Commit(); // ✅ Confirmar la transacción si todo salió bien
        }



        // 🔹 Obtener pagos de una factura específica
        public List<Pago> ObtenerPagosPorFactura(int facturaId)
        {
            return _context.Pagos.Where(p => p.FacturaId == facturaId).ToList();
        }

        public Factura ObtenerFacturaPorId(int facturaId)
        {
            return _context.Facturas
                .Include(f => f.Pagos)
                .Include(f => f.Reserva)
                .Include(f => f.Servicios) // ✅ Cargar servicios asociados
                .FirstOrDefault(f => f.Id == facturaId);
        }

    }
}     