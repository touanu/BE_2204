using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DataAccess.Objects
{
    public class GroupAttributeValue
    {
        [Key]
        public int GroupAttributeValueID { get; set; }
        public int GroupAttributeID { get; set; }
        public string? AttributeValue { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set;}
        public int Quantity { get; set; }
    }
}
