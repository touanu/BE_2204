using ProductManagement.DataAccess.Objects;

namespace ProductManagement.Models
{
    public class ProductModel
    {
        public Product? Product { get; set; }
        public ProductVariant? Variant { get; set; }
    }
}
