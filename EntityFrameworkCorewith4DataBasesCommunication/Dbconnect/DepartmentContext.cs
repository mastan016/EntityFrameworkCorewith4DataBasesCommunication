using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dbconnect
{
    public class DepartmentContext:DbContext
    {

        public DepartmentContext(DbContextOptions<DepartmentContext> options):base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }   

        // All crud operations related methods comming from DBset class.
        // DbContext class provides savechanges() method to save the data permenently.


    }
}
