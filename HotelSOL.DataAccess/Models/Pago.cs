using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSOL.DataAccess.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Factura")]
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public decimal Monto { get; set; }

        public string MetodoPago { get; set; } // Tarjeta, efectivo, transferencia, etc.

        public DateTime FechaPago { get; set; }
    }
}
