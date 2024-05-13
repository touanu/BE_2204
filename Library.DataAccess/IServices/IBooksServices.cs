using Library.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.IServices
{
    public interface IBooksServices
    {
        Task<List<Book>> GetAll();
        Task<int> Insert(Book book);
        Task<int> Update(Book book);
        Task<int> Delete(int id);
        Task<Book> Search(int id);
    }
}
