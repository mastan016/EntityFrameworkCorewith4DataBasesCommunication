using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dbconnect;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Migrations.Orders;
using EntityFrameworkCorewith4DataBasesCommunication.Dbconnect;
using EntityFrameworkCorewith4DataBasesCommunication.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersContext _ordersContext;

        public OrdersRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public async Task<int> AddOrder(Orders orderdetail)
        {
            await _ordersContext.orders123.AddAsync(orderdetail);
            _ordersContext.SaveChanges();
            return 1;
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {            
            Orders ord = await _ordersContext.orders123.Where(a => a.orderid == orderid).FirstOrDefaultAsync();
            if (ord != null)
            {
                _ordersContext.orders123.Remove(ord);
                _ordersContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<Orders> GetOrderById(int orderid)
        {
            var result = await _ordersContext.orders123.Where(o => o.orderid == orderid).FirstOrDefaultAsync();
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<List<Orders>> GetOrders()
        {
            var result = _ordersContext.orders123.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }            
        }

        public async Task<bool> UpdateOrder(Orders orderdetail)
        {
           _ordersContext.orders123.Update(orderdetail);
            await _ordersContext.SaveChangesAsync();
            return true;

        }
    }
}
