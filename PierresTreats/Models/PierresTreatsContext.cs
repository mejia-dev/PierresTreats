using Microsoft.EntityFrameworkCore;

namespace PierresTreats.Models
{
  public class PierresTreatsContext : DbContext
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<TreatFlavor> TreatFlavors { get; set; }
    public PierresTreatsContext(DbContextOptions options) : base(options) { }
  }
}