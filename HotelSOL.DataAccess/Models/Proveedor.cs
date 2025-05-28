namespace HotelSOL.DataAccess.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string CIF { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Albaran> Albaranes { get; set; } = new List<Albaran>();
        public ICollection<FacturaProveedor> FacturasProveedores { get; set; } = new List<FacturaProveedor>();
    }

}