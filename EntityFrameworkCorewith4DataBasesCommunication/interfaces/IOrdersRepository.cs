
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(int orderid);

        Task<int> AddOrder(Orders orderdetail);

        Task<bool> DeleteOrderById(int orderid);

        Task<bool> UpdateOrder(Orders orderdetail);
    }
}
