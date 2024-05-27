using Clientes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL.Dbcontext
{
    public class AplicationDbContext : IdentityDbContext
    { 
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedClientes.Seed(modelBuilder);
            SeedProductos.Seed(modelBuilder);           
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<RenglonesPedidos> RenglonesPedidos { get; set; }
    }
}
