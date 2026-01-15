using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Core;


public class TuvTurkDatabaseContext : DbContext
{
    //entities
    public DbSet<Appointments> Appointments { get; set; }
    public DbSet<Slots> Slots { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Price> Prices { get; set; }
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

    public override int SaveChanges()
    {
        var modified = ChangeTracker.Entries().Where(q => q.State == EntityState.Modified);
        PreSaveChangesTasks(modified);

        int result;
            try
            {
                var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                result = base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                var changedEntries = ChangeTracker.Entries()
                    .Where(x => x.State != EntityState.Unchanged).ToList();

                foreach (var entry in changedEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;

                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                    }
                }
                throw ;
            }



            return result;
    }
    private void PreSaveChangesTasks(IEnumerable<EntityEntry> modified)
    {
        

        foreach (var item in modified)
        {
            if(item.Properties.Any(q => q.IsModified))
            {
                var entity = (item.Entity as EntityBaseModel);
                entity.UpdatedDate = DateTime.Now;              
            }
        }

    }

}