using LibraryManagementAPI.Data;
using LibraryManagementAPI.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;

        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dataContext.Books.Include(b => b.CreatedBy).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid bookId)
        {
            return await _dataContext.Books.Include(b => b.CreatedBy).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<bool> CreateAsync(Book bookToCreate)
        {
            using (IDbContextTransaction transaction = await _dataContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dataContext.Books.Add(bookToCreate);
                    var created = await _dataContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return created > 0;
                }
                catch
                {
                    await transaction.RollbackAsync();
                }

                return false;
            }
        }
        public async Task<bool> UpdateAsync(Book bookToUpdate)
        {
            _dataContext.Books.Update(bookToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsync(Guid bookId)
        {
            var book = await GetByIdAsync(bookId);
            if (book == null)
                return false;

            _dataContext.Books.Remove(book);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
