using Microsoft.EntityFrameworkCore;
using TuvTurk.Entities.Concrete;


public class TuvTurkDatabaseContext : DbContext
{
    //entities
    public DbSet<Appointments> Appointments { get; set; }
    public DbSet<Slots> Slots { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     //optionsBuilder.UseSqlServer("");
    //     base.OnConfiguring(optionsBuilder);
    // }

    public TuvTurkDatabaseContext(DbContextOptions<TuvTurkDatabaseContext> options) : base(options)
    {
    }

}