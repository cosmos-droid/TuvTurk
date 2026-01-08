using Microsoft.EntityFrameworkCore;
using TuvTurk.Entities.Concrete;


public class TuvTurkDatabaseContext : DbContext
{
    //entities
    public DbSet<Appointments> Appointments { get; set; }
    public DbSet<Slots> Slots { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Vehicle> Vehicles {get; set;}
    public DbSet<EnumGroup> EnumGroups { get; set; }
    public DbSet<EnumGroupType> EnumGroupsTypes { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     //optionsBuilder.UseSqlServer("");
    //     base.OnConfiguring(optionsBuilder);
    // }

    public TuvTurkDatabaseContext(DbContextOptions<TuvTurkDatabaseContext> options) : base(options)
    {
    }

}