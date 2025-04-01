namespace E_Commerce_Api.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfileImgUrl { get; set; }
        public List<Order> OrderList { get; set; } = new List<Order>();
    }
}
