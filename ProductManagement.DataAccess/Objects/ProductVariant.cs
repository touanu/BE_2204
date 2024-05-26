using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DataAccess.Objects
{
    public class ProductVariant
    {
        [Key]
        public int VariantID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int VariantType { get; set; }
        public string? VariantDescription { get; set; }
        public string? ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
