namespace NovemberShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } = 0;
        public string ImageUrl { get; set; } = string.Empty;

    }
}
