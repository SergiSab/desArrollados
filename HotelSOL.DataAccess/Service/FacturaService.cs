using System;
using System.Collections.Generic;
using System.Linq;
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class FacturaService
    {
        private readonly HotelSolContext _context;

        public FacturaService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // 🔹 Generar una factura basada en la reserva y servicios consumidos
        public Factura GenerarFactura(int reservaId, decimal impuestoPorcentaje)
        {
            using var transaction = _context.Database.BeginTransaction(); // ✅ Iniciar transacción

            var reserva = _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefault(r => r.Id == reservaId);

            if (reserva == null)
            {
                throw new Exception($"❌ Error: La reserva con ID {reservaId} no existe en la base de datos.");
            }

            Console.WriteLine($"✅ Reserva encontrada: ID={reserva.Id}, ClienteID={reserva.ClienteId}");

            var factura = _context.Facturas.FirstOrDefault(f => f.ReservaId == reservaId); // ✅ Buscar factura existente

            var serviciosConsumidos = _context.Servicios
                .Include(s => s.TipoServicio) // 🔹 Cargar detalles del TipoServicio
                .Where(s => s.ReservaId == reservaId)
                .ToList();

            decimal montoServicios = serviciosConsumidos.Sum(s => s.Precio); // ✅ Usar el precio almacenado en `Servicio`
            decimal montoBase = CalcularMontoBase(reserva);
            decimal montoImpuestos = CalcularImpuesto(montoBase + montoServicios, impuestoPorcentaje);
            decimal montoTotal = montoBase + montoServicios + montoImpuestos;

            if (factura != null)
            {
                // 📌 Si ya existe una factura, actualizar el monto incluyendo nuevos servicios
                factura.MontoTotal = montoTotal;
                factura.MontoImpuestos = montoImpuestos;
                _context.Update(factura);
                Console.WriteLine($"🔄 Factura actualizada: ID={factura.Id}");
            }
            else
            {
                // 📌 Crear una nueva factura ANTES de asignarla a los servicios
                factura = new Factura
                {
                    ReservaId = reservaId,
                    ClienteId = reserva.ClienteId,
                    MontoTotal = montoTotal,
                    MontoImpuestos = montoImpuestos,
                    FechaEmision = DateTime.Now,
                    Pagada = false,
                    DescuentoAplicado = 0
                };

                _context.Facturas.Add(factura);
                _context.SaveChanges(); // ✅ Guardar la factura primero
                Console.WriteLine($"✅ Nueva factura generada: ID={factura.Id}");

                // 📌 Ahora que la factura está guardada, asignarla a los servicios
                foreach (var servicio in serviciosConsumidos)
                {
                    servicio.FacturaId = factura.Id;
                    _context.Update(servicio);
                }

                _context.SaveChanges(); // ✅ Guardar todos los cambios de los servicios en una sola operación
            }

            _context.SaveChanges();
            transaction.Commit(); // ✅ Confirmar los cambios

            return factura; // ✅ Ahora `factura` está definida en todo el método
        }




        // 🔹 Calcular el costo base de la reserva
        private decimal CalcularMontoBase(Reserva reserva)
        {
            int diasReservados = (reserva.FechaFin - reserva.FechaInicio).Days;
            decimal tarifaDiaria = _context.ReservaHabitaciones
                .Where(rh => rh.ReservaId == reserva.Id)
                .Include(rh => rh.Habitacion)  // 🔹 Carga la relación `Habitacion`
                .ThenInclude(h => h.TipoHabitacion) // 🔹 Carga `TipoHabitacion` dentro de `Habitacion`
                .ToList()
                .Select(rh => rh.Habitacion?.TipoHabitacion?.PrecioBase ?? 0) // 🔹 Evita `null`
                .FirstOrDefault();




            if (reserva.Cliente.VIP)
            {
                tarifaDiaria *= 0.9m; // Aplicando 10% de descuento para clientes VIP
            }

            if (EsTemporadaAlta(reserva.FechaInicio, reserva.FechaFin))
            {
                tarifaDiaria *= 1.2m; // Aumento del 20% en temporada alta
            }

            return diasReservados * tarifaDiaria;
        }

        // 🔹 Verificar si es temporada alta
        private bool EsTemporadaAlta(DateTime inicio, DateTime fin)
        {
            var temporadaAlta = new List<(int mesInicio, int mesFin)>
            {
                (6, 8),  // Verano: Junio - Agosto
                (12, 1)  // Navidad: Diciembre - Enero
            };

            return temporadaAlta.Any(t => inicio.Month >= t.mesInicio && fin.Month <= t.mesFin);
        }

        // 🔹 Calcular impuestos
        private const decimal IMPUESTO_POR_DEFECTO = 10m;

        public decimal CalcularImpuesto(decimal monto, decimal? porcentaje = null)
        {
            decimal impuestoAplicado = porcentaje ?? IMPUESTO_POR_DEFECTO;
            return monto * (impuestoAplicado / 100);
        }

        // 🔹 Verificar si una factura está pagada
        public bool FacturaPagada(int facturaId)
        {
            var factura = _context.Facturas.FirstOrDefault(f => f.Id == facturaId);
            return factura?.Pagada ?? false;
        }

        // 🔹 Obtener todas las facturas de un cliente
        public List<Factura> ObtenerFacturasPorCliente(int clienteId)
        {
            return _context.Facturas.Include(f => f.Reserva)
                                    .Where(f => f.ClienteId == clienteId)
                                    .ToList();
        }

    }
}


