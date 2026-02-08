using Microsoft.EntityFrameworkCore;
using Praktika.Praktika.Domain.Entities;

namespace Praktika.Praktika.Infrastructure.Persistence
{
    public class PraktikaDbContext : DbContext
    {
        public PraktikaDbContext(DbContextOptions<PraktikaDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set;}
        public DbSet<Item> Items { get; set; }
    }
}
