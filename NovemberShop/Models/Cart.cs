namespace NovemberShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CastomerId { get; set; }
        public List<Item>? Items { get; set; }
    }
}
