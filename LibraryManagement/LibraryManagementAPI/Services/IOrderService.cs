using LibraryManagementAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetByUserAsync(Guid userId);

        Task<Order> CreateAsync(Book bookToCreate);

        Task<bool> UpdateAsync(Book bookToUpdate);

        Task<bool> DeleteAsync(Guid transId);
    }
}
