using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSOL.DataAccess.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoImpuestos { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public bool Pagada { get; set; } = false;
        public decimal DescuentoAplicado { get; set; } = 0; // Nuevo campo para descuentos

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();

    }

}
