using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Studenten.Models;

namespace Studenten.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Studenten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(Seeding());

            modelBuilder.Entity<Student>()
                .HasKey(p => p.StudentId);
        }

        private List<Student> Seeding()
        {
            List<Student> studenten = new List<Student>();
            for(int i = 1; i < 5; i++)
            {
                studenten.Add(new Student() { StudentId = i, Naam = "Johan" + i, Leeftijd = 20 + i });
            }
            return studenten;
        }
    }
}
