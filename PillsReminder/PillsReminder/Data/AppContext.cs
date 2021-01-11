using PillsReminder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillsReminder.Models;

namespace PillsReminder.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<DozaMedicament> DozaMedicament { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PillsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Adresa)
                .WithOne(b => b.User)
                .HasForeignKey<Adresa>(b => b.IdUtilizator).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasMany(a => a.DozaMedicaments)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}