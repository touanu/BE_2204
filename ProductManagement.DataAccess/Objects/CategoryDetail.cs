using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductManagement.DataAccess.Objects;

namespace ProductManagement.DataAccess.Objects
{
    public class CategoryDetail
    {
        [Key]
        public int CDID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
    }
}
