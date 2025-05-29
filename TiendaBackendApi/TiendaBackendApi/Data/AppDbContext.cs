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
       



    }
}

