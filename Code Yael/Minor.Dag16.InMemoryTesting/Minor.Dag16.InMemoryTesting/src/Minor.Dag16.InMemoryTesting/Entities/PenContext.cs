using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag16.InMemoryTesting.Entities
{
    public class PenContext : DbContext
    {
        public virtual DbSet<Pen> Pens { get; set; }

        public PenContext()
        {
            this.Database.EnsureCreated();
        }
        public PenContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PenDatabase;Trusted_Connection=True;");
            }
        }
    }
}
