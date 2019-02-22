using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class CuentasClarasContext : IdentityDbContext
    {
        public CuentasClarasContext(DbContextOptions<CuentasClarasContext> options) : base(options)
        {
        }

        public DbSet<Release> Releases { get; set; }
        public DbSet<ReleaseItem> ReleaseItems{ get; set; }
        public DbSet<ReleaseItemClassification> ReleaseItemClassifications { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Model create (crate model tables and identity tables)
            base.OnModelCreating(modelBuilder);

            //Table names
            modelBuilder.Entity<Release>().ToTable("Releases");
            modelBuilder.Entity<ReleaseItem>().ToTable("ReleaseItems");
            modelBuilder.Entity<ReleaseItemClassification>().ToTable("ReleaseItemClassifications");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Buyer>().ToTable("Buyers");
            modelBuilder.Entity<Currency>().ToTable("Currencies");

            //Relations
            modelBuilder.Entity<Release>().HasOne(r => r.Buyer).WithMany(rb => rb.Releases).HasForeignKey(f => f.BuyerId);
            modelBuilder.Entity<Release>().HasOne(r => r.Supplier).WithMany(rb => rb.Releases).HasForeignKey(f => f.SupplierId);
            modelBuilder.Entity<Release>().HasMany(r => r.ReleaseItems).WithOne(rb => rb.Release).HasForeignKey(f => f.ReleaseId);
            modelBuilder.Entity<ReleaseItem>().HasOne(r => r.ReleaseItemClassification).WithMany(rb => rb.ReleaseItems).HasForeignKey(f => f.ReleaseItemClassificationId);

            //INDEXES
            //modelBuilder.Entity<Supplier>().HasIndex("ExternalId").IsUnique();
           
        }
    }
}
