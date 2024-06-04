using ProductManagement.DataAccess.Objects;

namespace ProductManagement.Models
{
    public class ProductModel(Product product)
    {
        public Product? Product { get; set; } = product;
    }
}
