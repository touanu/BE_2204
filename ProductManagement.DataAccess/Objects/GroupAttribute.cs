using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DataAccess.Objects
{
    public class GroupAttribute
    {
        [Key]
        public int GroupAttributeID { get; set; }
        public int ProductID { get; set; }
        public string? AttributeName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantity { get; set; }
    }
}
