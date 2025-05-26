// HotelSOL.DataAccess/Models/Factura.cs
namespace HotelSOL.DataAccess.Models
{
    public class Factura
    {
        public int Id { get; set; }

        // Relación con Reserva/Cliente…
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; } = null!;
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        // Importes
        public decimal MontoTotal { get; set; }
        public decimal MontoImpuestos { get; set; }
        public decimal DescuentoAplicado { get; set; } = 0m;

        // Número de Factura para el asiento
        public string NumeroFactura { get; set; } = string.Empty;

        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public bool Pagada { get; set; } = false;

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
    }
}
