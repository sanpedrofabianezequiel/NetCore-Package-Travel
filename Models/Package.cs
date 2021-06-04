using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Package : ModelBase
    {
        public string Description { get; set; }
        public List<Product> Products = new List<Product>();
    }
}
