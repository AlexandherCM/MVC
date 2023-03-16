using System.ComponentModel.DataAnnotations;

namespace EscuelaBD.Models.ViewModels
{
    public class AlumnoViewModel
    {
        [Required]
        [Display(Name = "Nombre del alumno")]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [Display(Name="Numero Salon")]
        public int SalonID { get; set; }
    }
}
