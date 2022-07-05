using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymzilla.Models
{
    // record in the table
    public class Brand
    {
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }

        // reference to child object: 1 Brand / Many Products
        public List<Product> Products { get; set; }
    }
}
