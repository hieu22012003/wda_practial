using Microsoft.EntityFrameworkCore;
using THcode.Entities;

namespace  THcode.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}