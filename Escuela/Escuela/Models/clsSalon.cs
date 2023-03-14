using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("Salon")]
    public class clsSalon
    {
        [Key]
        public int ID { get; set; }
        public string Salon { get; set; }

        public virtual List<clsAlumno> Alumno{ get; set; }
    }
}
