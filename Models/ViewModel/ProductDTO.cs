using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public float Price { get; set; }
    }
}
