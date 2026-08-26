using Microsoft.EntityFrameworkCore;
using BookManagementApi.Models;
namespace BookManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
