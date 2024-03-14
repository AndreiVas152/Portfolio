using As.Park.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace As.Park.Model;

public class ParkDbContext : DbContext
{
    public ParkDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Plate> Plates { get; set; }
    public DbSet<Vignette> Vignettes { get; set; }
    public DbSet<Fine> Fines { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Owner>()
            .HasMany(c => c.Cars)
            .WithOne(p => p.Owner)
            .HasForeignKey(c => c.OwnerId);

        modelBuilder.Entity<Plate>()
            .HasOne(c => c.Car)
            .WithOne(p => p.Plate)
            .HasForeignKey<Car>(f => f.PlateId);

        modelBuilder.Entity<Car>()
            .HasOne(p => p.Plate)
            .WithOne(c => c.Car)
            .HasForeignKey<Plate>(f => f.CarId);



    }
}