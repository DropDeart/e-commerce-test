using E_Commerce_Api.Data;
using E_Commerce_Api.Domain;
using E_Commerce_Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Api.Service
{
    public class OrderService : IOrderService
    {
        private readonly ECommerceDbContext _context;
        public OrderService(ECommerceDbContext eCommerceDbContext)
        {
            _context = eCommerceDbContext;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                foreach (var item in order.OrderItems)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product != null || product.Stock < item.Quantity)
                    {
                        throw new Exception("Stok yeterli değildir.");
                    }

                    //Stoktan düşüyoruz.
                    product.Stock -= item.Quantity;
                }

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return false;

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            try
            {
                return await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            try
            {
                return await _context.Orders.Where(p => p.UserId == userId).Include(p => p.OrderItems).ThenInclude(p => p.Product).ToListAsync();
                                
            }
            catch (Exception ex) { 
                throw ex;
            }
        }
    }
}
