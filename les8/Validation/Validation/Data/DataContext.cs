using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Models;

namespace Validation.Data
{
	public class DataContext : DbContext
	{
        public DataContext (DbContextOptions<DataContext> options) : base(options) { }

		public DataContext() { }

		public DbSet<Student> Studenten { get; set; }

		public DbSet<StudentVriend> StudentVrienden { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.HasKey(s => new { s.StudentID });

			modelBuilder.Entity<StudentVriend>()
				.HasKey(sv => new { sv.StudentID, sv.VriendID });

			modelBuilder.Entity<StudentVriend>()
				.HasOne(s => s.Student)
				.WithMany(sv => sv.StudentVrienden)
				.HasForeignKey(s => s.StudentID);

			modelBuilder.Entity<StudentVriend>()
				.HasOne(s => s.Student)
				.WithMany(sv => sv.StudentVrienden)
				.HasForeignKey(s => s.VriendID);
		}
	}
}
