using CommonLibs;

namespace ProductManagement.DataAccess.Objects
{
    public class SaveChangesReturnData : ReturnData
    {
        public int SaveChangesCode { get; set; }
    }

    public class GetProductReturnData(Product product, List<ProductVariant>? variants)
    {
        public Product Product { get; set; } = product;
        public List<ProductVariant>? Variants { get; set; } = variants;
    }
}
