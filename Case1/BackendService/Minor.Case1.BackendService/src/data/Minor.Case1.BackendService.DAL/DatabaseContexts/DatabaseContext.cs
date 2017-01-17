using Microsoft.EntityFrameworkCore;
using Minor.Case1.BackendService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Cursus> Cursussen { get; set; }

        public virtual DbSet<CursusInstantie> CursusInstanties { get; set; }

        public virtual DbSet<Inschrijving> Inschrijvingen { get; set; }

        public virtual DbSet<Cursist> Cursisten { get; set; }

        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursusInstantie>()
                .HasAlternateKey(ci => new { ci.StartDatum, ci.CursusId })
                .HasName("UQ_CursusInsantieDatum_CursusId");

            modelBuilder.Entity<Inschrijving>().HasKey(inschrijving => new
            {
                inschrijving.CursistId,
                inschrijving.CursusInstantieId,
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CASDB_YK;Trusted_Connection=True;");
            }
        }
    }
}