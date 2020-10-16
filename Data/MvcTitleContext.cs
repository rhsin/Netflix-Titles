using Microsoft.EntityFrameworkCore;
using MvcTitle.Models;

namespace MvcTitle.Data
{
    public class MvcTitleContext : DbContext
    {
        public MvcTitleContext (DbContextOptions<MvcTitleContext> options)
            : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TitleUser>()
                .HasKey(tu => new { tu.TitleId, tu.UserId });
        }

        public DbSet<Title> Title { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TitleUser> TitleUser { get; set; }
    }
}
