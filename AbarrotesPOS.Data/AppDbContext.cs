using AbarrotesPOS.Shared;
using Microsoft.EntityFrameworkCore;

namespace AbarrotesPOS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // --- AGREGADO: Tabla de Roles ---
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> ComprasDetalles { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; } // <--- ESTA ES LA LÍNEA NUEVA QUE NECESITAS


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de precisión para decimales (Moneda)
            modelBuilder.Entity<Producto>().Property(p => p.PrecioVenta).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Compra>().Property(c => c.Total).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<CompraDetalle>().Property(cd => cd.PrecioCompra).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Venta>().Property(v => v.Total).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<VentaDetalle>().Property(vd => vd.PrecioVenta).HasColumnType("decimal(18, 2)");

            // --- NUEVO: Configuración para Roles y Usuarios ---
            // Evita borrar un Rol si hay usuarios asignados a él (Integridad referencial)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Configuración existente para evitar ciclos ---
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany()
                .HasForeignKey(p => p.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}