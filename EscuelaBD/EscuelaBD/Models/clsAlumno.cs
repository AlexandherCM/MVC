using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscuelaBD.Models
{
    [Table("Alumnos")]
    public class clsAlumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int SalonID { get; set;}
        [ForeignKey("SalonID")]
        public virtual clsSalon Salon { get; set; } 
    }
}
