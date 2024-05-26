using ProductManagement.DataAccess.Objects;

namespace ProductManagement.Models
{
    public class ProductModel(Product product, List<ProductVariant>? variants)
    {
        public Product? Product { get; set; } = product;
        public List<ProductVariant>? Variants { get; set; } = variants;
    }
}
