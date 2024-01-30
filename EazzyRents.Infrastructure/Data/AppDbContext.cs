using EazzyRents.Core.Models;
using EazzyRents.Core.Models.BlobStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EazzyRents.Infrastructure.Data
{
      public class AppDbContext : IdentityDbContext<User>
      {
            public AppDbContext (DbContextOptions<AppDbContext> options)
                : base(options)
            {

            }

            protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
            {
                  base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating (ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Landlord",
                    NormalizedName = "LANDLORD"
                },
                new IdentityRole
                {
                    Name = "Tenant",
                    NormalizedName = "TENANT"
                },
                new IdentityRole
                {
                    Name = "Guest",
                    NormalizedName = "GUEST"
                }
            };
                  modelBuilder.Entity<IdentityRole>().HasData(roles);
            }
            public DbSet<RealEstate> RealEstates { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<BlobContent> Images { get; set; }
      }
}
