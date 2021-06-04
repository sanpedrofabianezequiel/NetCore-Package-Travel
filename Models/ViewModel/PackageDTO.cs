using System.Collections.Generic;

namespace Models
{
    public class PackageDTO
    {
        public long TravelPackageId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
