using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL
{
    public class SeedProductos
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto() { Id = 1, Codigo = "X1221ER", Descripcion = "Coca Cola 2L", Unidad = "1", PrecioUnidad = 10000},
                new Producto() { Id = 2, Codigo = "M1671EZ", Descripcion = "Fanta 2L", Unidad = "1", PrecioUnidad = 11000 },
                new Producto() { Id = 3, Codigo = "X1331EM", Descripcion = "Sprite 2L", Unidad = "1", PrecioUnidad = 9500 },
                new Producto() { Id = 4, Codigo = "Z3241ER", Descripcion = "Pulp 2L", Unidad = "1", PrecioUnidad = 7000 },
                new Producto() { Id = 5, Codigo = "B1451EC", Descripcion = "Coca Cola 1.5L", Unidad = "1", PrecioUnidad = 6500 }
                );
        }
    }
}
