using Final_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Entity.ModelConfiguration;

namespace Final_4.DataLayer
{
    public class StopWatchDbContext : DbContext
    {
        public DbSet<StopWatchTracker> stopWatchTrackers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StopWatchTracker>().ToTable("StopwatchHistory").HasKey(k => k.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Data Source=StopWatchTracker.db");
        }
        //}
    }
}
