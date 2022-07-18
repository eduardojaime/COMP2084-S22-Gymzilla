using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gymzilla.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string CustomerId { get; set; }  
        public DateTime OrderTime { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display (Name ="Last Name")]
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Display(Name ="Postal Code")]
        public string PostalCode { get; set; }

        // connect 1 to M to OrderDetails
        public List<OrderItem> OrderItems { get; set; }
    }
}
