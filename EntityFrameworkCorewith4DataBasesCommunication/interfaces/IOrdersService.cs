using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Dtos;
using EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.interfaces
{
    public interface IOrdersService
    {
        Task<List<OrdersDto>> GetOrders();
        Task<OrdersDto> GetOrderById(int orderid);

        Task<int> AddOrder(OrdersDto orderdetail);

        Task<bool> DeleteOrderById(int orderid);

        Task<bool> UpdateOrder(OrdersDto orderdetail);

    }
}
