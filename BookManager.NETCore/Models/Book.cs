namespace BookManager.NETCore.Models
{
    public class Book(int bookID, string bookName, int price, int stock)
    {
        public int BookID { get; set; } = bookID;
        public string BookName { get; set; } = bookName;
        public int Price { get; set; } = price;
        public int Stock { get; set; } = stock;
    }
}