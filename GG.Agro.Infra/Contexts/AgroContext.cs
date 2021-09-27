using GG.Agro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GG.Agro.Infra.Contexts
{
    public class AgroContext : DbContext
    {
        public AgroContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
