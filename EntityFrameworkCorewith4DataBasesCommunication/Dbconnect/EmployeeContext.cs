using EntityFrameworkCorewith4DataBasesCommunication.Entities;
using Microsoft.EntityFrameworkCore;       // Need to import this package.

namespace EntityFrameworkCorewith4DataBasesCommunication.Dbconnect
{
    public class EmployeeContext :DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options) { 
        
        
        }
        public DbSet<Employee>  Employees { get; set; }


    }
}
