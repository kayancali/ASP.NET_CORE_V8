using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public bool  IsActive { get; set; }
        
    }
}