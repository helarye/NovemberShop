namespace NovemberShop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }= 0;
        public int Quantity { get; set; }= 0;
        public int CartId { get; set; }
}
}
