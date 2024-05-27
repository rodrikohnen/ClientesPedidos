using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.DAL
{
    public class SeedClientes
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente() { Id = 1, NameLastname = "Juan Pérez", NroDocumento = 2735521, TipoDeDocumento = "cedula" , FechadeNacimiento = new DateTime(1989, 05, 12), FechaHoraActualizacion = DateTime.Now },
                new Cliente() { Id = 2, NameLastname = "María González", NroDocumento = 19356732, TipoDeDocumento = "cedula", FechadeNacimiento = new DateTime(1998, 10, 20), FechaHoraActualizacion = DateTime.Now },
                new Cliente() { Id = 3, NameLastname = "Carlos Ramírez", NroDocumento = 36367263, TipoDeDocumento = "pasaporte", FechadeNacimiento = new DateTime(1997, 08, 12), FechaHoraActualizacion = DateTime.Now },
                new Cliente() { Id = 4, NameLastname = "Ana López", NroDocumento = 2563672, TipoDeDocumento = "cedula", FechadeNacimiento = new DateTime(1990, 07, 15), FechaHoraActualizacion = DateTime.Now },
                new Cliente() { Id = 5, NameLastname = "Luis Fernández", NroDocumento = 1993646, TipoDeDocumento = "pasaporte", FechadeNacimiento = new DateTime(2000, 02, 02), FechaHoraActualizacion = DateTime.Now }
                );
        }
    }
}
