namespace BE2024.DataAccess.Objects
{
    public class Product
    {
        public Product(string id, string name, double price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice => Price * Quantity;
    }
}
