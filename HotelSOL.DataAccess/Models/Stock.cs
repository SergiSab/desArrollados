using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSOL.DataAccess.Models
{
    public class Stock
    {
        public int id { get; set; }
        [Column("nombre_producto")]
        public string NombreProducto { get; set; }
        public string Familia { get; set; } = null!;
        [Column("cantidad_restante")]
        public int CantidadRestante { get; set; }
        public decimal Pvp { get; set; }
    }
}
