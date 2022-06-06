using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymzilla.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]  // MS Currency format
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        // parent model references
        public Category Category { get; set; }
        public Brand Brand { get; set; }

    }
}
