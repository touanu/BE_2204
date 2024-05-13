using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Objects
{
    public class Book
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public int AuthorID { get; set; }
        public string? Tag { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
