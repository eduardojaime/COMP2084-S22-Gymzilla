using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymzilla.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
