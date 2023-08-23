using System.ComponentModel.DataAnnotations;

namespace PruebasCore.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name= "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Numero Telefónico")]
        public string Phone { get; set; }

        [Display(Name = "Sueldo")]
        public decimal Salary { get; set; }

        [Display(Name = "Compañia")]
        public int CompanyID { get; set; }
    }
}
