namespace E_Commerce_Api.Domain
{
    public class Product
    {
        public  Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string ImageUrl {  get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
