using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCorewith4DataBasesCommunication.Entities
{

 
    public class Employee
    {

        [Key]
        public int empid { get; set; }

        public string empname { get; set; }

        public int empSalary { get; set; }


    }
}
