namespace ProductManagement.DataAccess.Objects
{
    public class AttributeRequest
    {
        public required GroupAttribute GroupAttribute { get; set; }
        public required List<GroupAttributeValue> GroupAttributeValues { get; set; }
    }
    public class ProductAddRequest
    {
        public required Product Product { get; set; }
        public required List<AttributeRequest> AttributeRequests { get; set; }
    }

    public class ProductInsertUpdateRequestData
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public required string ProductName { get; set; }

        public required string AttributeValues { get; set; }
        // 256 lit -den , 10 , 1000 , 9000 _ 236 lit -den , 15 , 1200 , 10000  
    }

    public class ProductDeleteRequestData
    {
        public int ProductID { get; set; }
    }

    public class ProductUpdateRequest
    {
        public required Product Product { get; set; }
        public required List<AttributeRequest> AttributeRequests { get; set; }
    }

    public class ProductDeleteRequest
    {
        public required int ProductId { get; set; }
        public required int GroupAttributeId { get; set; }
    }
}
