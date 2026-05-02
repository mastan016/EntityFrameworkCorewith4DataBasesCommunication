using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCorewith4DataBasesCommunication.Entities
{

 
    public class Employee
    {

        [Key]    // key attroubute is used to apply the primary key + identity to this empid column with out [key] if you migration name it will not work.
        public int empid { get; set; }

        public string empname { get; set; }

        public int empSalary { get; set; }

       

    }
}
