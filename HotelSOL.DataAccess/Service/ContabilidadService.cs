// HotelSOL.DataAccess/Services/ContabilidadService.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class ContabilidadService
    {
        private readonly HotelSolContext _ctx;
        public ContabilidadService(HotelSolContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        /// <summary>
        /// Inserta un nuevo asiento y devuelve la entidad con Id.
        /// </summary>
        public AsientoContable AddAsiento(AsientoContable asiento)
        {
            _ctx.AsientosContables.Add(asiento);
            _ctx.SaveChanges();
            return asiento;
        }

        /// <summary>
        /// Inserta una línea de asiento.
        /// </summary>
        public void AddLinea(LineaAsiento linea)
        {
            _ctx.LineasAsiento.Add(linea);
            _ctx.SaveChanges();
        }

        /// <summary>Recupera todos los asientos ordenados por fecha.</summary>
        public List<AsientoContable> GetAllAsientos()
        {
            return _ctx.AsientosContables
                       .OrderBy(a => a.Fecha)
                       .ToList();
        }

        /// <summary>Recupera las líneas de un asiento concreto.</summary>
        public List<LineaAsiento> GetLineasByAsiento(int asientoId)
        {
            return _ctx.LineasAsiento
                       .Where(l => l.AsientoContableId == asientoId)
                       .Include(l => l.Cuenta)
                       .ToList();
        }

        /// <summary>Elimina un asiento (y sus líneas via cascada si está configurado).</summary>
        public void DeleteAsiento(int id)
        {
            var asiento = _ctx.AsientosContables.Find(id);
            if (asiento == null) return;
            _ctx.AsientosContables.Remove(asiento);
            _ctx.SaveChanges();
        }
    }
}
