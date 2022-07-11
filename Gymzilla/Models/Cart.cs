using System;

namespace Gymzilla.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        // id reference
        public int ProductId { get; set; }
        public string CustomerId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        // object reference
        public Product Product { get; set; }
    }
}
