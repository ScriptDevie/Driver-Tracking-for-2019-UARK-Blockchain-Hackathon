using DriverTracking.Entities;
using Microsoft.EntityFrameworkCore;

namespace DriverTracking.DbContexts
{
    public class DriverTrackingContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<TripRecords> TripRecords { get; set; }
        public virtual DbSet<AccidentReportRecords> AccidentReportRecords { get; set; }
        public virtual DbSet<HardBreakRecords> HardBreakRecords { get; set; }
        public virtual DbSet<CitationRecords> CitationRecords { get; set; }

        public DriverTrackingContext(DbContextOptions<DriverTrackingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.TripRecords)
                .WithOne(t => t.Driver);

            modelBuilder.Entity<TripRecords>()
                .HasMany(a => a.Accidents)
                .WithOne(t => t.TripRecords);
            modelBuilder.Entity<TripRecords>()
                .HasMany(h => h.HardBreaks)
                .WithOne(t => t.TripRecords);
            modelBuilder.Entity<TripRecords>()
                .HasMany(c => c.Citations)
                .WithOne(t => t.TripRecords);
        }
    }
}