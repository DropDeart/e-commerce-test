using E_Commerce_Api.Enums;

namespace E_Commerce_Api.Domain
{
    public class Order
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public DateTime OrderDate{ get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; } = (int)OrderStatusEnum.Prepending; // Bu tarz yapılanmalar Enum olarak tutulmalı. Statik olarak verilmemeli. Sipariş Takibi için status eklenmeli.


        public User User { get; set; } = null;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
