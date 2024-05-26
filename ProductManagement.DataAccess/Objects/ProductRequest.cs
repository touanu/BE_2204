namespace ProductManagement.DataAccess.Objects
{
    public class ProductAddRequest
    {
        public required Product Product { get; set; }
        public required List<ProductVariant> Variants { get; set; }
    }

    public class ProductUpdateRequest
    {
        public required Product Product { get; set; }
        public required List<ProductVariant> Variants { get; set; }
    }

    public class ProductDeleteRequest
    {
        public required int ProductId { get; set; }
        public required int? VariantId { get; set; }
    }
}
