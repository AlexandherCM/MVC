using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    [Table("PELICULA")]
    public class Pelicula
    {
        [Key] 
        public int ID { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Lanzamiento { get; set; }
        public string? Genero { get; set; }
        public decimal Precio { get; set; }
    }
}
