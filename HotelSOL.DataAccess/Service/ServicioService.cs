using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSOL.DataAccess.Service
{
    public class ServicioService
    {
        private readonly HotelSolContext _context;

        public ServicioService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void RegistrarServicio(int reservaId, int tipoServicioId, bool aplicarDescuento)
        {
            var tipoServicio = _context.TipoServicio.Find(tipoServicioId);

            if (tipoServicio == null)
            {
                throw new Exception($"❌ Error: No existe el TipoServicio con ID {tipoServicioId}.");
            }

            decimal precioFinal = tipoServicio.Precio;

            if (aplicarDescuento)
            {
                precioFinal *= 0.9m; // ✅ Aplicando 10% de descuento si corresponde
            }

            var servicio = new Servicio
            {
                ReservaId = reservaId,
                TipoServicioId = tipoServicioId,
                DescuentoAplicado = aplicarDescuento,
                FacturaId = null, // ✅ Si la factura aún no se ha generado
                Precio = precioFinal // ✅ Guardar el precio directamente en `Servicio`
            };

            _context.Servicios.Add(servicio);
            _context.SaveChanges();
        }



        public List<Servicio> ObtenerServiciosPorReserva(int reservaId)
        {
            return _context.Servicios
                .Include(s => s.TipoServicio) // 🔹 Cargar los detalles del tipo de servicio
                .Where(s => s.ReservaId == reservaId)
                .ToList();
        }

        public List<TipoServicioEntity> ObtenerTiposServicios()
        {
            return _context.TipoServicio.ToList(); // 🔹 Devuelve todos los tipos de servicio
        }

    }



}