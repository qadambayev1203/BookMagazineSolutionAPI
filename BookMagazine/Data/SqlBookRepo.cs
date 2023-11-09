using BookMagazine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Data
{
    public class SqlBookRepo : IBookAPIRepo
    {
        public readonly BookDbContext _context;

        public SqlBookRepo(BookDbContext bookDbContext)
        {
            _context = bookDbContext;
        }

        public async Task CreateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            await _context.books.AddAsync(book);
        }

        public void DeleteBook(Book book)
        {
            _context.books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book> GetBookByID(int id)
        {
            return await _context.books.FirstOrDefaultAsync(book => book.id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>=0;
        }

        public async Task UpdateBook(Book book)
        {
            //await _context.UpdateAsync(book);
        }
    }
}
