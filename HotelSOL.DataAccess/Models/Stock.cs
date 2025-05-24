using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSOL.DataAccess.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string Familia { get; set; } = null!;
        public int CantidadRestante { get; set; }
        public decimal Pvp { get; set; }
    }
}
