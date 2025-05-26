// HotelSOL.DataAccess/Service/ProveedorService.cs
using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess.Service
{
    public class ProveedorService
    {
        private readonly HotelSolContext _ctx;
        public ProveedorService(HotelSolContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public List<Proveedor> GetAll()
            => _ctx.Proveedores
                   .OrderBy(p => p.Nombre)
                   .ToList();

        public void Add(Proveedor prov)
        {
            _ctx.Proveedores.Add(prov);
            _ctx.SaveChanges();
        }

        public void Update(Proveedor prov)
        {
            _ctx.Proveedores.Update(prov);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = _ctx.Proveedores.Find(id);
            if (e != null)
            {
                _ctx.Proveedores.Remove(e);
                _ctx.SaveChanges();
            }
        }
    }
}
