using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess.Service
{
    public class FacturaProveedorService
    {
        private readonly HotelSolContext _ctx;

        public FacturaProveedorService(HotelSolContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        /// <summary>Trae todas las facturas de proveedores, con su pedido y albarán incluidos.</summary>
        public List<FacturaProveedor> GetAll()
        {
            return _ctx.FacturasProveedores
                       .Include(fp => fp.Proveedor)
                       .Include(fp => fp.Pedido)
                       .Include(fp => fp.Albaran)
                       .OrderBy(fp => fp.Id)
                       .ToList();
        }

        public void Add(FacturaProveedor item)
        {
            _ctx.FacturasProveedores.Add(item);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var ex = _ctx.FacturasProveedores.Find(id);
            if (ex != null)
            {
                _ctx.FacturasProveedores.Remove(ex);
                _ctx.SaveChanges();
            }
        }
    }
}
