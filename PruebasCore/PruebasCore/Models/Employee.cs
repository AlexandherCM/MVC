using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebasCore.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Número de contacto")]
        public string Phone { get; set; }

        [Display(Name = "Sueldo Mensual")]
        public decimal Salary { get; set; }

        public int CompanyID { get; set; }

        [ForeignKey(nameof(CompanyID))]
        [Display(Name="Compañia")]
        public virtual Company company { get; set; }
    }
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public int CompanyID { get; set; }
    }
}
