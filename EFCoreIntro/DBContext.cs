using Microsoft.EntityFrameworkCore;
using EFCoreIntroduction.Entities;
using System.Net;
using System.Reflection;

namespace EFCoreIntroduction.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        // entity/table
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
    }

}