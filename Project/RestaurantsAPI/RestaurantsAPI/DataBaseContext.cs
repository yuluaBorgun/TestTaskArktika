using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Migrations;
using RestaurantsAPI.Models;

namespace RestaurantsAPI
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt) { }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Kitchen> Kitchen { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasCheckConstraint("Rating", "Rating >= 0.0 AND Rating <= 5.0");
        }
    }
}
