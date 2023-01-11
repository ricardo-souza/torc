using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Torc.API.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task<(bool, string)> DeleteBookAsync(Book book);
    }
}
