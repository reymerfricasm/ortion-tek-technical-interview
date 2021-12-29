using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using orion_tek_technical_interview.Models;

namespace orion_tek_technical_interview.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<Country> Countries {get; set;}
        public DbSet<City> Cities {get; set;}
        public DbSet<State> States {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
            .Entity<Country>()
            .HasMany(c => c.Cities)
            .WithOne(c => c.Country)
            .HasForeignKey(f => f.CountryId);

            modelBuilder
            .Entity<Customer>().
            HasMany(c => c.Adresses)
            .WithOne(c => c.Customer)
            .HasForeignKey(f => f.CustomerId);

            modelBuilder
            .Entity<City>()
            .HasMany(c => c.States)
            .WithOne(c => c.City)
            .HasForeignKey(f => f.CityId);

            modelBuilder
            .Entity<State>()
            .HasOne(s => s.City)
            .WithMany(s => s.States)
            .HasForeignKey(f => f.StateId);

            modelBuilder
            .Entity<Address>()
            .HasOne(a => a.Customer)
            .WithMany(a => a.Adresses)
            .HasForeignKey(f => f.CustomerId);

            modelBuilder
            .Entity<Address>()
            .HasOne(a => a.Country)
            .WithMany(a => a.Adresses)
            .HasForeignKey(f => f.CountryId);

            modelBuilder
            .Entity<Address>()
            .HasOne(a => a.City)
            .WithMany(a => a.Adresses)
            .HasForeignKey(f => f.CityId);

            modelBuilder
            .Entity<Address>()
            .HasOne(a => a.State)
            .WithMany(a => a.Adresses)
            .HasForeignKey(f => f.StateId);
        }
    }
}