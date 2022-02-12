using LibraryManagementAPI.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(Guid bookId);

        Task<bool> CreateAsync(Book bookToCreate);

        Task<bool> UpdateAsync(Book bookToUpdate);

        Task<bool> DeleteAsync(Guid bookId);
    }
}
