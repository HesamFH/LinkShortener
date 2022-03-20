using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Model.Context
{
    public class LinkShortenerContext : DbContext
    {
        public LinkShortenerContext(DbContextOptions<LinkShortenerContext> options) : base(options)
        {

        }
        public DbSet<Links> Links { get; set; }
        public DbSet<User> User { get; set; }
    }
}
