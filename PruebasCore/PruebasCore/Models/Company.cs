using System.ComponentModel.DataAnnotations.Schema;

namespace PruebasCore.Models
{
    [Table("Company")]
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> employee { get;set; }
    }
    
    public class CompanyDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeDTO> employee { get;set; }
    }
}
