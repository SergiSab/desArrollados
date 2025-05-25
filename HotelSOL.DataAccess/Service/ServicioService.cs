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
        public void RegistrarServicio(int reservaId, TipoServicio tipo, string descripcion, decimal precio, bool aplicarDescuento)
        {
            var servicio = new Servicio
            {
                ReservaId = reservaId,
                Tipo = tipo,
                Descripcion = descripcion,
                Precio = aplicarDescuento ? precio * 0.9m : precio, // Aplicando descuento si es VIP
                DescuentoAplicado = aplicarDescuento
            };

            _context.Servicios.Add(servicio);
            _context.SaveChanges();
        }
        public List<Servicio> ObtenerServiciosPorReserva(int reservaId)
        {
            return _context.Servicios.Where(s => s.ReservaId == reservaId).ToList();
        }

    }
}