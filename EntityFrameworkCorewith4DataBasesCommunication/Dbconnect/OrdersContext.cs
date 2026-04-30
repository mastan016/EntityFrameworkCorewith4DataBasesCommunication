using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dbconnect
{
    public class OrdersContext:DbContext
    {

        public OrdersContext(DbContextOptions<OrdersContext> options) :base(options){ 
                    
        }

        public DbSet<Orders> orders123 { get; set; }

    }
}
