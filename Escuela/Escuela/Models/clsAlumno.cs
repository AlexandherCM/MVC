using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("Alumno")]
    public class clsAlumno
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int SalonID { get; set;}
        [ForeignKey("SalonID")]
        public virtual clsSalon Salon { get; set; }
    }
}
