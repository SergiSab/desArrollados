using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSOL.DataAccess.Models
{
    public class Albaran
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdPedido { get; set; }

        public Proveedor Proveedor { get; set; } = null!;
        public Pedido Pedido { get; set; } = null!;
        public ICollection<FacturaProveedor> FacturasProveedores { get; set; } = new List<FacturaProveedor>();
    }

}
