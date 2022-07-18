namespace Gymzilla.Models
{
    public class OrderItem
    {
        public int Id { get; set; }         
        public int Quantity { get; set; }
        public decimal Price { get; set; }  
        
        // FK to point to Product and Order
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Virtual properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
