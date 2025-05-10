using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Models;

namespace TiendaBackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompraProducto>()
                .HasKey(cp => new { cp.CompraId, cp.ProductoId });

            modelBuilder.Entity<CompraProducto>()
                .HasOne(cp => cp.Compra)
                .WithMany(c => c.CompraProductos)
                .HasForeignKey(cp => cp.CompraId);

            modelBuilder.Entity<CompraProducto>()
                .HasOne(cp => cp.Producto)
                .WithMany()
                .HasForeignKey(cp => cp.ProductoId);
        }




    }
}

