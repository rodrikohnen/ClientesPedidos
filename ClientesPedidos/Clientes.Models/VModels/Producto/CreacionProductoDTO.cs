using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class CreacionProductoDTO
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
        [Range(typeof(decimal), "0", "10000000000", ErrorMessage = "Value for {0} must be between {1} and {2}")]        
        public decimal? PrecioUnidad { get; set; }
    }
}
