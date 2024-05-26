using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DataAccess.Objects
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
    }
}
