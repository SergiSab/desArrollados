using Microsoft.EntityFrameworkCore;
using HotelSOL.DataAccess.Models;

namespace HotelSOL.DataAccess
{
    public class HotelSolContext : DbContext
    {
        // DbSet para cada tabla en la base de datos
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaHabitaciones> ReservaHabitaciones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<TipoHabitacion> TiposHabitaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        // Nótese que la tabla real se llama singular “Proveedor”
        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Albaran> Albaranes { get; set; }
        public DbSet<FacturaProveedor> FacturasProveedores { get; set; }

        // Mapeo del nuevo TipoServicioEntity
        public DbSet<TipoServicioEntity> TipoServicio { get; set; }

        public HotelSolContext(DbContextOptions<HotelSolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ================================
            //  Configuración global de tablas
            // ================================
            modelBuilder.Entity<Proveedor>()
                            .HasKey(p => p.IdProveedor);
            modelBuilder.Entity<Proveedor>()
                .ToTable("Proveedor");

            modelBuilder.Entity<Stock>()
                        .ToTable("Stock");         

            modelBuilder.Entity<Pedido>()
                        .ToTable("Pedidos");        

            modelBuilder.Entity<Albaran>()
                        .ToTable("Albaranes");

            modelBuilder.Entity<FacturaProveedor>()
                        .ToTable("FacturasProveedores");

            modelBuilder.Entity<TipoServicioEntity>()
                        .ToTable("TipoServicio");    

            // ================================
            //  Relaciones existentes…
            // ================================
            modelBuilder.Entity<Servicio>()
                .HasOne(s => s.TipoServicio)
                .WithMany()
                .HasForeignKey(s => s.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId);

            modelBuilder.Entity<ReservaHabitaciones>()
                .HasOne(rh => rh.Reserva)
                .WithMany(r => r.ReservaHabitaciones)
                .HasForeignKey(rh => rh.ReservaId);

            modelBuilder.Entity<ReservaHabitaciones>()
                .HasOne(rh => rh.Habitacion)
                .WithMany(h => h.ReservaHabitaciones)
                .HasForeignKey(rh => rh.HabitacionId);

            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.ReservaHabitaciones)
                .WithOne(rh => rh.Reserva)
                .HasForeignKey(rh => rh.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Habitacion>()
                .HasOne(h => h.TipoHabitacion)
                .WithMany(t => t.Habitaciones)
                .HasForeignKey(h => h.TipoId);

            modelBuilder.Entity<Reserva>()
                .Property(r => r.Estado)
                .HasConversion<int>();

            // ================================
            //  Proveedor → Pedidos
            // ================================
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Pedidos)
                .HasForeignKey(p => p.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // ================================
            //  Albaranes
            // ================================
            modelBuilder.Entity<Albaran>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Albaran>()
                .HasOne(a => a.Proveedor)
                .WithMany(pr => pr.Albaranes)
                .HasForeignKey(a => a.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Albaran>()
                .HasOne(a => a.Pedido)
                .WithMany(p => p.Albaranes)
                .HasForeignKey(a => a.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            //  FacturasProveedores
            // ================================
            modelBuilder.Entity<FacturaProveedor>()
                .HasKey(fp => fp.Id);

            modelBuilder.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Proveedor)
                .WithMany(pr => pr.FacturasProveedores)
                .HasForeignKey(fp => fp.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Pedido)
                .WithMany(p => p.FacturasProveedores)
                .HasForeignKey(fp => fp.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Albaran)
                .WithMany(a => a.FacturasProveedores)
                .HasForeignKey(fp => fp.IdAlbaran)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
