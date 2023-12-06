using Microsoft.EntityFrameworkCore;
using EFCoreIntroduction.Entities;

namespace EFCoreIntroduction.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        // entity/table
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);
            modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);
        }
    }

}