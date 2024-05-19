using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            var models = new List<Book>()
            {
                new Book(0, "Sách 1", 100000, 10),
                new Book(0, "Sách 1", 100000, 10),
                new Book(0, "Sách 1", 100000, 10),
                new Book(0, "Sách 1", 100000, 10),
                new Book(0, "Sách 1", 100000, 10),
                new Book(0, "Sách 1", 100000, 10)
            };

            return View(models);
        }

        public ActionResult AddNew()
        {
            return View();
        }
    }
}