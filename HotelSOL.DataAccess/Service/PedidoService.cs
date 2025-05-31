// HotelSOL.DataAccess/Service/PedidoService.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Service
{
    public class PedidoService
    {
        private readonly HotelSolContext _ctx;

        public PedidoService(HotelSolContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        /// <summary>Trae todos los pedidos con su proveedor.</summary>
        public List<Pedido> GetAll()
        {
            return _ctx.Pedidos
                       .Include(p => p.Proveedor)
                       .OrderBy(p => p.Id)
                       .ToList();
        }

        public void Add(Pedido ped)
        {
            _ctx.Pedidos.Add(ped);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = _ctx.Pedidos.Find(id);
            if (e != null)
            {
                _ctx.Pedidos.Remove(e);
                _ctx.SaveChanges();
            }
        }
    }
}
