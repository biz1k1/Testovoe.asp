using Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Configuration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { 
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
        }
    }
}
