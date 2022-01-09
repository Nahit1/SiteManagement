using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Persistence
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<ApartmentPerson> ApartmentPerson { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Member", NormalizedName="MEMBER"},
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "SysAdmin", NormalizedName = "SYSADMIN" }
                );



            builder.Entity<ApartmentPerson>(x => x.HasKey(aa => new { aa.ApartmentId, aa.PersonId }));

            builder.Entity<ApartmentPerson>()
                .HasOne(u => u.Person)
                .WithMany(a => a.Apartments)
                .HasForeignKey(aa => aa.PersonId);

            builder.Entity<ApartmentPerson>()
                .HasOne(u => u.Apartment)
                .WithMany(a => a.Persons)
                .HasForeignKey(aa => aa.ApartmentId);
        }
    }
}
