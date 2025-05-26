// HotelSOL.DataAccess/HotelSolContext.cs
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess
{
    public class HotelSolContext : DbContext
    {
        // ——— DbSets existentes ———
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

        // ——— Módulo de compras/proveedores ———
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Albaran> Albaranes { get; set; }
        public DbSet<FacturaProveedor> FacturasProveedores { get; set; }

        // ——— Tipos de servicio ———
        public DbSet<TipoServicioEntity> TipoServicio { get; set; }

        // ——— Contabilidad ———
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<AsientoContable> AsientosContables { get; set; }
        public DbSet<LineaAsiento> LineasAsiento { get; set; }

        public HotelSolContext(DbContextOptions<HotelSolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // ——————————————
            //  M A P E O   D E   T A B L A S
            // ——————————————
            mb.Entity<Proveedor>()
                .ToTable("Proveedor")
                .HasKey(p => p.IdProveedor);

            mb.Entity<Stock>()
                .ToTable("Stock")
                .HasKey(s => s.id);

            mb.Entity<Pedido>()
                .ToTable("Pedidos")
                .HasKey(p => p.Id);

            mb.Entity<Albaran>()
                .ToTable("Albaranes")
                .HasKey(a => a.Id);

            mb.Entity<FacturaProveedor>()
                .ToTable("FacturasProveedores")
                .HasKey(fp => fp.Id);

            mb.Entity<TipoServicioEntity>()
                .ToTable("TipoServicio")
                .HasKey(ts => ts.Id);

            // ——————————————
            //  Relaciones varias
            // ——————————————

            // Servicio → TipoServicioEntity
            mb.Entity<Servicio>()
                .HasOne(s => s.TipoServicio)
                .WithMany()
                .HasForeignKey(s => s.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cliente ↔ Usuario
            mb.Entity<Cliente>()
                .HasKey(c => c.ClienteId);
            mb.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId);

            // ReservaHabitaciones ↔ Reserva, ↔ Habitacion
            mb.Entity<ReservaHabitaciones>()
                .HasKey(rh => rh.Id);
            mb.Entity<ReservaHabitaciones>()
                .HasOne(rh => rh.Reserva)
                .WithMany(r => r.ReservaHabitaciones)
                .HasForeignKey(rh => rh.ReservaId);
            mb.Entity<ReservaHabitaciones>()
                .HasOne(rh => rh.Habitacion)
                .WithMany(h => h.ReservaHabitaciones)
                .HasForeignKey(rh => rh.HabitacionId);
            mb.Entity<Reserva>()
                .HasMany(r => r.ReservaHabitaciones)
                .WithOne(rh => rh.Reserva)
                .HasForeignKey(rh => rh.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Habitacion → TipoHabitacion
            mb.Entity<Habitacion>()
                .HasOne(h => h.TipoHabitacion)
                .WithMany(t => t.Habitaciones)
                .HasForeignKey(h => h.TipoId);

            // Reserva.Estado como int
            mb.Entity<Reserva>()
                .Property(r => r.Estado)
                .HasConversion<int>();

            // Proveedor → Pedidos
            mb.Entity<Pedido>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Pedidos)
                .HasForeignKey(p => p.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Albaranes ↔ Proveedor & Pedido
            mb.Entity<Albaran>()
                .HasOne(a => a.Proveedor)
                .WithMany(pr => pr.Albaranes)
                .HasForeignKey(a => a.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Albaran>()
                .HasOne(a => a.Pedido)
                .WithMany(p => p.Albaranes)
                .HasForeignKey(a => a.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            // FacturasProveedores ↔ Proveedor, ↔ Pedido, ↔ Albaran
            mb.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Proveedor)
                .WithMany(pr => pr.FacturasProveedores)
                .HasForeignKey(fp => fp.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);
            mb.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Pedido)
                .WithMany(p => p.FacturasProveedores)
                .HasForeignKey(fp => fp.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);
            mb.Entity<FacturaProveedor>()
                .HasOne(fp => fp.Albaran)
                .WithMany(a => a.FacturasProveedores)
                .HasForeignKey(fp => fp.IdAlbaran)
                .OnDelete(DeleteBehavior.Restrict);

            // ——————————————
            //  Contabilidad (doble partida)
            // ——————————————

            mb.Entity<Cuenta>()
                .ToTable("Cuenta")
                .HasKey(c => c.Id);
            mb.Entity<Cuenta>()
                .HasIndex(c => c.Codigo)
                .IsUnique();

            mb.Entity<AsientoContable>()
                .ToTable("AsientoContable")
                .HasKey(a => a.Id);

            mb.Entity<LineaAsiento>()
                .ToTable("LineaAsiento")
                .HasKey(l => l.Id);
            mb.Entity<LineaAsiento>()
                .HasOne(l => l.Asiento)
                .WithMany(a => a.Lineas)
                .HasForeignKey(l => l.AsientoContableId)
                .OnDelete(DeleteBehavior.Cascade);
            mb.Entity<LineaAsiento>()
                .HasOne(l => l.Cuenta)
                .WithMany(c => c.Lineas)
                .HasForeignKey(l => l.CuentaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(mb);
        }
    }
}
