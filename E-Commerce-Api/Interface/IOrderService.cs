using E_Commerce_Api.Domain;

namespace E_Commerce_Api.Interface
{
    public interface IOrderService
    {
        public Task<Order> GetOrderByIdAsync(Guid id);
        public Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
        public Task<Order> CreateOrderAsync(Order order);
        public Task<bool> DeleteOrderAsync(Guid id);
    }
}
