using blog_asp_net.Model;
using Microsoft.EntityFrameworkCore;

namespace blog_asp_net.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
