using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class CrearProductoServiciosModel
    {
        public int? Id { get; set; }
        [Required]
        public string? Codigo { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,130}$", ErrorMessage = "Characters are not allowed.")]
        public string? Descripcion { get; set; }
        [Required]
        public string? Unidad { get; set; }
        [Required]
        [Precision(18, 3)]      
        public string? PrecioUnidad { get; set; }
    }
}