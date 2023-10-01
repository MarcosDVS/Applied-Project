using Microsoft.EntityFrameworkCore;
using TORO.Data.Models;

namespace TORO.Data.Context
{
    public class ToroDbContext : DbContext, IToroDbContext
    {
        private readonly IConfiguration config;

        public ToroDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<HealthCheck> HealthChecks { get; set; }
        public DbSet<Milking> Milkings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
