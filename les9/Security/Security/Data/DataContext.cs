using Microsoft.EntityFrameworkCore;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Data
{
    public class DataContext : DbContext
    {
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DataContext() { }

		public DbSet<Student> Studenten { get; set; }

		public DbSet<Docent> Docenten { get; set; }

		public DbSet<ToetsResultaat> ToetsResultaten { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.HasKey(s => s.StudentId);

			modelBuilder.Entity<Docent>()
				.HasKey(d => d.DocentId);

			modelBuilder.Entity<ToetsResultaat>()
				.HasKey(t => new { t.StudentId, t.Datum });

			modelBuilder.Entity<ToetsResultaat>()
				.HasOne(s => s.Student)
				.WithMany(t => t.ToetsResultaten)
				.HasForeignKey(s => s.StudentId);

			modelBuilder.Entity<ToetsResultaat>()
				.HasOne(d => d.Docent)
				.WithMany(t => t.ToetsResultaten)
				.HasForeignKey(d => d.DocentId);
		}
	}
}
