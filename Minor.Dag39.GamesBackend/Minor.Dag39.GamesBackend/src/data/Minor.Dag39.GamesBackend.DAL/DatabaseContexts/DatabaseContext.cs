using Microsoft.EntityFrameworkCore;
using Minor.Dag39.GamesBackend.Entities;

namespace Minor.Dag39.GamesBackend.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Room> Games { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
    }
}