using Microsoft.EntityFrameworkCore;

namespace RazorPagesSimpleCRUD.Data
{
    public class SimpleDbContext : DbContext
    {
        public SimpleDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
