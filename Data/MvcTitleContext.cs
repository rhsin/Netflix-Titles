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

        public DbSet<Title> Title { get; set; }
    }
}
