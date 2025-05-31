using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess.Service
{
    public class StockService
    {
        private readonly HotelSolContext _context;

        public StockService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>Devuelve todo el stock ordenado por producto.</summary>
        public List<Stock> ObtenerStock()
        {
            return _context.Stock
                           .ToList();
        }

        /// <summary>Busca un registro por Id.</summary>
        public Stock? GetById(int id)
        {
            return _context.Stock.Find(id);
        }

        /// <summary>Añade un nuevo registro de stock.</summary>
        public void Add(Stock item)
        {
            _context.Stock.Add(item);
            _context.SaveChanges();
        }

        /// <summary>Actualiza un registro existente.</summary>
        public void Update(Stock item)
        {
            _context.Stock.Update(item);
            _context.SaveChanges();
        }

        /// <summary>Elimina un registro por Id.</summary>
        public void Delete(int id)
        {
            var existente = _context.Stock.Find(id);
            if (existente != null)
            {
                _context.Stock.Remove(existente);
                _context.SaveChanges();
            }
        }
    }
}
