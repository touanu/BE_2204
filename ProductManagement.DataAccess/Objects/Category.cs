using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DataAccess.Objects
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
