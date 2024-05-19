using Library.DataAccess.DBContext;
using Library.DataAccess.IServices;
using Library.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Services
{
    public class BooksServices(LibraryDBContext libraryDBContext) : IBooksServices
    {
        private readonly LibraryDBContext _libraryDBContext = libraryDBContext;

        public async Task<int> Delete(int id)
        {
            Book? book = _libraryDBContext.Books.Find(id);
            if (book == null)
                return -1;

            _libraryDBContext.Books.Remove(book);
            return _libraryDBContext.SaveChanges();
        }

        public async Task<List<Book>> GetAll()
        {
            return [.. _libraryDBContext.Books];
        }

        public async Task<int> Insert(Book book)
        {
            _libraryDBContext.Books.Add(book);
            return _libraryDBContext.SaveChanges();
        }

        public async Task<Book> Search(int id)
        {
            return _libraryDBContext.Books.Find(id);
        }

        public Task<int> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
