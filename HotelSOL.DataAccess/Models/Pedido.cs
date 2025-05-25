using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSOL.DataAccess.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public decimal PrecioTotal { get; set; }
        public string? Albaran { get; set; }
        public string? Factura { get; set; }

        public Proveedor Proveedor { get; set; } = null!;
        public ICollection<Albaran> Albaranes { get; set; } = new List<Albaran>();
        public ICollection<FacturaProveedor> FacturasProveedores { get; set; } = new List<FacturaProveedor>();
    }
}
