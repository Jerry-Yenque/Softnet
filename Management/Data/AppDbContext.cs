using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
