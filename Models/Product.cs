namespace Models
{
    public class Product : ModelBase
    {
        public string Description { get; set; }
        public long PackageID { get; set; }
        public int Category { get; set; }
        public float Price { get; set; }

        public ProductType ProductType = new ProductType();
    }
}
