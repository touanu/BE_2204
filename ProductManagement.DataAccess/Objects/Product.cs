using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DataAccess.Objects
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int CategoryID { get; set; }
        public List<GroupAttribute>? ProductAttributes { get; set; }
        public string? ImagePath { get; set; }
    }
    public class Product_Attribute
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string? ProductName { get; set; }
    }
}
