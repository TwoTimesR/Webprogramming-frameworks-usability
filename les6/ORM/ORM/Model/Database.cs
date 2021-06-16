using System;
using Microsoft.EntityFrameworkCore;

namespace ORM.Model
{
	public class Database
	{
		public class OrganisationContext : DbContext
		{
			public DbSet<Company> Companies { get; set; }

			public DbSet<Customer> Customers { get; set; }

			public DbSet<NonProfit> NonProfits { get; set; }

			public DbSet<Organisation> Organisations { get; set; }

			public DbSet<Owner> Owners { get; set; }

			public DbSet<Product> Products { get; set; }

			public DbSet<Review> Reviews { get; set; }

			public DbSet<CompanyCustomer> CompanyCustomers { get; set; }

			protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite("Data Source=organisation.db");

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<Product>()
					.HasKey(p => new { p.OrganisationId, p.SequenceNumber });

				modelBuilder.Entity<Review>()
					.HasOne(p => p.Product)
					.WithMany(p => p.Reviews)
					.HasForeignKey(p => new { p.OrganisationId, p.SequenceNumber });

				modelBuilder.Entity<CompanyCustomer>()
					.HasKey(p => new { p.OrganisationId, p.CustomerId });

				modelBuilder.Entity<CompanyCustomer>()
					.HasOne(p => p.Company)
					.WithMany(p => p.CompanyCustomers)
					.HasForeignKey(p => p.OrganisationId);

				modelBuilder.Entity<CompanyCustomer>()
					.HasOne(p => p.Customer)
					.WithMany(p => p.CompanyCustomers)
					.HasForeignKey(p => p.CustomerId);
			}
		}
	}
}
