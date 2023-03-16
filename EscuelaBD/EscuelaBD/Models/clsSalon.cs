using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EscuelaBD.Models
{
    [Table("Salones")]
    public class clsSalon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        [MaxLength(8)]
        public string Salon { get; set; }
        public virtual ICollection<clsAlumno> Alumnos { get; set; }
    }
}
