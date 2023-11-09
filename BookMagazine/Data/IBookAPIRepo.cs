using BookMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Data
{
    public interface IBookAPIRepo
    {
        public Task<IEnumerable<Book>> GetAllBook();

        public Task<Book> GetBookByID(int id);

        public Task CreateBook(Book book);

        public Task UpdateBook(Book book);

        public void DeleteBook(Book book);

        public Task<bool> SaveChangesAsync();
    }
}
