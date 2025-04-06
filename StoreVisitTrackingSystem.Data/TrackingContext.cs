using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data.Entities;
using System.Reflection;

namespace StoreVisitTrackingSystem.Data;

public class TrackingContext : DbContext
{
    public TrackingContext(DbContextOptions<TrackingContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
