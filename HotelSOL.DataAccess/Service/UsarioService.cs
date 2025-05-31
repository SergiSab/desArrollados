using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess.Service
{
    public class UsuarioService  // 🔹 Agregamos la clase para contener los métodos
    {
        private readonly HotelSolContext _context;  // 🔹 Agregamos la variable de contexto

        // Constructor que recibe el contexto
        public UsuarioService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Registrar usuario en la BD
        public Usuario RegistrarUsuarioConCliente(string nombre, string apellido, string email, string contraseña, string dni, string telefono, string direccion, bool vip)
        {
            var usuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Contraseña = contraseña,
                Rol = "Cliente"
            };

            if (_context.Usuarios.Any(u => u.Email == email))
            {
                throw new InvalidOperationException("Ya existe un usuario con este email.");
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges(); // 🔹 Guardamos el usuario

            var cliente = new Cliente
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Email = email,
                Telefono = telefono,
                VIP = vip,
                UsuarioId = usuario.Id  // 🔹 Relación con el usuario recién creado
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges(); // 🔹 Guardamos el cliente

            return usuario; // 🔹 DEVOLVER el usuario creado
        }
        public void RegistrarUsuario(Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            {
                throw new InvalidOperationException("❌ Ya existe un usuario con este email.");
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }




        // Autenticar usuario en el sistema
        public Usuario AutenticarUsuario(string email, string contraseña)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Contraseña == contraseña);
        }
    }
}
