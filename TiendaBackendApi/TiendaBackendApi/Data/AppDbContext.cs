using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TiendaBackendApi.Models;

namespace TiendaBackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {}

        public DbSet<Product>Productos { get; set; }
        public DbSet<Categoria>Categorias { get; set; }
    }
}
