using hack4splitBORBAapi.Model;
using Microsoft.EntityFrameworkCore;

namespace hack4splitBORBAapi.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<EventModel>? Events { get; set; }
        public DbSet<RatingModel>? Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("user");
            modelBuilder.Entity<EventModel>().ToTable("event");
            modelBuilder.Entity<RatingModel>().ToTable("rating");
        }
    }
}
