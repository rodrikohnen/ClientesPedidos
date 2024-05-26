using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class PeticionPorIdDTO
    {
        [Required]
        [Range(0, 2147483640, ErrorMessage = "El valor para {0} tiene que ser entre {1} y {2}")]        
        public int? Id { get; set; }
 
    }
}
