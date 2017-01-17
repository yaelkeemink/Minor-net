using Microsoft.EntityFrameworkCore;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.Monumenten.Data.DatabseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Monument> Monuments { get; set; }
        public DbSet<Entity> Entities { get; internal set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DATABASENAME;Trusted_Connection=True;");
            }
        }
    }
}