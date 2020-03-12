using CCMS.Domain.Entities;
using CCMS.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Persistence
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext(DbContextOptions<DashboardDbContext> options) : base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentOutCome> IncidentOutComes { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Violater> Violaters { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PhysicalObject> PhysicalObjects { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<LicensePlate> LicensePlates { get; set; }
        public DbSet<Organization> Organizations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
