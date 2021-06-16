using Microsoft.EntityFrameworkCore;
using ZoekFilterPagineer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoekFilterPagineer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() { }

        public DbSet<Student> Studenten { get; set; }

        public DbSet<Cursus> Cursussen { get; set; }
        
        public DbSet<StudentCursus> StudentCursussen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Cursus>()
                .HasKey(c => c.CursusId);

            modelBuilder.Entity<StudentCursus>().HasKey(sc => new { sc.StudentId, sc.CursusId });

            modelBuilder.Entity<StudentCursus>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCursus)
                .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCursus>()
                .HasOne<Cursus>(sc => sc.Cursus)
                .WithMany(s => s.StudentCursus)
                .HasForeignKey(sc => sc.CursusId);

        }
    }
}
