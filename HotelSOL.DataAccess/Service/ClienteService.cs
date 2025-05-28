using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess.Services
{
    public class ClienteService
    {
        private readonly HotelSolContext _context;

        // Constructor que recibe el contexto
        public ClienteService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Agregar cliente
        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        // Listar clientes (devuelve una lista en lugar de imprimir en consola)
        public List<Cliente> ListarClientes()
        {
            return _context.Clientes.ToList();
        }
        public bool ExisteCliente(string email)
        {
            return _context.Clientes.Any(c => c.Email == email);
        }


        // Actualizar cliente con validación de datos
        public bool ActualizarCliente(int id, string nuevoEmail, string nuevoTelefono)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null) return false;

            if (!string.IsNullOrWhiteSpace(nuevoEmail))
                cliente.Email = nuevoEmail;

            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                cliente.Telefono = nuevoTelefono;

            _context.SaveChanges();
            return true;
        }


        // Eliminar cliente con verificación de existencia
        public bool EliminarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null) return false;

            bool tieneReservasActivas = _context.Reservas.Any(r => r.ClienteId == id && r.FechaFin >= DateTime.Today);
            if (tieneReservasActivas)
            {
                return false; // No permitir eliminación si el cliente tiene reservas activas
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return true;
        }


        // Obtener lista de clientes VIP
        public List<Cliente> ObtenerClientesVIP()
        {
            return _context.Clientes.Where(c => c.VIP).ToList();
        }

        // Obtener clientes con reservas activas (manejo de `NULL`)
        public List<Cliente> ObtenerClientesConReservas()
        {
            return _context.Reservas
                .Where(r => r.FechaFin >= DateTime.Today)
                .Select(r => r.Cliente)
                .Where(c => c != null) // Evita errores si `Cliente` es `NULL`
                .Distinct()
                .ToList();
        }
    }
}
