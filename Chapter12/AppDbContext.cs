using Microsoft.EntityFrameworkCore;

namespace Chapter12
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
