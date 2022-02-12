using LibraryManagementAPI.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class DataContext : IdentityDbContext<CustomUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
