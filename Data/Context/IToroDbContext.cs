using Microsoft.EntityFrameworkCore;
using TORO.Data.Models;

namespace TORO.Data.Context
{
    public interface IToroDbContext
    {
        public DbSet<User> Users { get; set;  }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<HealthCheck> HealthChecks { get; set; }
        public DbSet<Milking> Milkings { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}