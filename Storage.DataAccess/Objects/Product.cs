namespace Storage.DataAccess.Objects
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public DateTime ExpiresDate { get; set; }
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
    }
}
