using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using RP.DataAccess.Model;

namespace RP.DataAccess.Persistence
{
    public class RPContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<UserCar> UserCar { get; set; }

        protected RPContext()
        {
            connectionString = @".\SQLEXPRESS;Database=RP;Trusted_Connection=True;";
        }

        public RPContext(string cntString)
        {
            connectionString = cntString;
        }

        public RPContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserCarTypeConfiguration());
        }
    }
}
