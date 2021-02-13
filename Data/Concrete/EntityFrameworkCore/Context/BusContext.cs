using Data.Concrete.EntityFrameworkCore.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFrameworkCore.Context
{
    public class BusContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public BusContext(DbContextOptions<BusContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new BusConfiguration());

            modelBuilder.ApplyConfiguration(new VoyageConfiguration());
        }
    }
}
