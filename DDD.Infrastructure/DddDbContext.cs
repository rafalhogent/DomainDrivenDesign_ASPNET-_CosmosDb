using Microsoft.EntityFrameworkCore;

using DDD.Core.Entities;
using System;

namespace DDD.Infrastructure
{
    public class DddDbContext : DbContext
    {

        public DddDbContext(DbContextOptions<DddDbContext> options) : base(options) { }

        public DddDbContext() {  }
        
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToContainer("Customers").HasPartitionKey(e => e.id);
            modelBuilder.Entity<Customer>().OwnsMany(k => k.Contacts);

            modelBuilder.Entity<Invoice>().ToContainer("Invoices").HasPartitionKey(e => e.id);
            modelBuilder.Entity<Invoice>().OwnsMany(k => k.InvoiceRows);
            modelBuilder.Entity<Invoice>().HasOne(f => f.Customer);

            modelBuilder.Entity<Customer>().HasData(new Customer("Albert", "Einstein", "8420 De Haan"));

        }
    }
}
