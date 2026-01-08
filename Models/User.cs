namespace BackendApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public decimal PriceRange { get; set; }
        public bool isGamer { get; set; }
        public bool isProgrammer { get; set; }

    }
}
