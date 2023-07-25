using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data.Entities;
using System.Reflection;

namespace SpeedRunTracker.Data
{
    public class SpeedRunTrackerDbContext : IdentityDbContext
    {
        public SpeedRunTrackerDbContext(DbContextOptions<SpeedRunTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<SpeedRun> SpeedRuns { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<GameCategories> GameCategories { get; set; } = null!;

        public DbSet<GameGenres> GameGenres { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(SpeedRunTrackerDbContext)) ?? Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}