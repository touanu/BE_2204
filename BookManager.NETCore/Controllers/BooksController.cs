using Microsoft.AspNetCore.Mvc;
using BookManager.NETCore.Models;

namespace BookManager.NETCore.Controllers
{
    public class BooksController : Controller
    {
        private readonly List<Book> books =
        [
            new Book(0, "Sách 1", 100000, 10),
            new Book(1, "Sách 2", 600000, 15),
            new Book(2, "Sách 3", 500000, 20),
            new Book(3, "Sách 4", 400000, 35),
            new Book(4, "Sách 5", 300000, 12),
            new Book(5, "Sách 6", 200000, 3)
        ];

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("BookID,BookName,Price,Stock")] Book book)
        {
            return View(book);
        }

        private bool BookExists(int id)
        {
            return books.Any(item => item.BookID == id);
        }
    }
}
