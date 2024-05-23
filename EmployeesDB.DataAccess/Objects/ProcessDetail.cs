using System.ComponentModel.DataAnnotations;

namespace EmployeesDB.DataAccess.Objects
{
    public class ProcessDetail
    {
        [Key]
        public int PDID { get; set; }
        public int ProcessID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
