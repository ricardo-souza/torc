using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torc.API.Data;

namespace Torc.API.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _db;

        public BookService(BookContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                return await _db.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            try
            {
                return await _db.Books.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
                return await _db.Books.FindAsync(book.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteBookAsync(Book book)
        {
            try
            {
                var dbBook = await _db.Books.FindAsync(book.Id);

                if (dbBook == null)
                {
                    return (false, "Book could not be found.");
                }

                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
    }
}
