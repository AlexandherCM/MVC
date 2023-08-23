using System.ComponentModel.DataAnnotations;

namespace PruebasCore.Models.ViewModels
{
    public class CompanyViewModel
    {
        [Required]  
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Dirección")]
        public string Address { get; set; }

        [Required]
        [Display(Name="Descripción")]
        public string Description { get; set; }
    }
}
