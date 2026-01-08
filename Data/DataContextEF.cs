using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Data
{
    public class DataContextEF : DbContext
    {
        private readonly IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<Computer> Computers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}
