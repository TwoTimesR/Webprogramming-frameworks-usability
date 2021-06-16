using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentenlijst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentenlijst.Data
{
    public class MijnContext : DbContext
    {
        public MijnContext(DbContextOptions<MijnContext> options) : base(options) { }

        public MijnContext() { }

        public DbSet<Student> Studenten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(p => new { p.Id });
        }
    }
}
