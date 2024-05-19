using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Models
{
    public class Book
    {
        public Book(int bookID, string bookName, int price, int stock)
        {
            BookID = bookID;
            BookName = bookName;
            Price = price;
            Stock = stock;
        }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}