namespace ProductManagement.DataAccess.Objects
{
    public class CategoryAddRequest
    {
        public required Category Category { get; set; }
    }

    public class CategoryUpdateRequest
    {
        public required Category Category { get; set; }
        public required List<CategoryDetail>? Details { get; set; }
    }

    public class CategoryDeleteRequest
    {
        public required int CategoryId { get; set; }
        public required int? CDId { get; set; }
    }
}
