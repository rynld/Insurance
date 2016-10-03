using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Insurance.Models;
using Insurance.Models.InsuranceViewModels;

namespace Insurance.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Customers.Include(c => c.PlanType);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Customer>().Property(b => b.Id).ValueGeneratedNever();

           
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

       

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

        public DbSet<PlanType> PlanTypes { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<SalePayment> Payments { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }

  
}
