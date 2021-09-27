using HotDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace HotDesk.Data
{
    public class HotDeskDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Device> Devices { get; set; }

        public HotDeskDbContext(DbContextOptions<HotDeskDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            builder.Entity<User>().HasIndex(u => u.Login).IsUnique();
        }
    }
}
