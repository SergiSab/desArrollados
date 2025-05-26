using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Service
{
    public class AlbaranService
    {
        private readonly HotelSolContext _ctx;
        public AlbaranService(HotelSolContext ctx)
            => _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));

        public List<Albaran> GetAll()
            => _ctx.Albaranes
                   .Include(a => a.Proveedor)
                   .Include(a => a.Pedido)
                   .ToList();

        public List<Albaran> GetByPedidoId(int pedidoId)
            => _ctx.Albaranes
                   .Where(a => a.IdPedido == pedidoId)
                   .ToList();
    }
}
