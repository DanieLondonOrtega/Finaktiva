using Finaktiva.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Finaktiva.Infrastructur.DataAccess.Context
{
    public class EntityDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EntityDbContext(
            DbContextOptions<EntityDbContext> dbContextOptions,
            IConfiguration configuration)
            : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var listType = new List<TypeEventLogs>
            {
                new TypeEventLogs { Id = 1, Type = "Api"  },
                new TypeEventLogs { Id = 2, Type = "Formulario"  }
            };

            modelBuilder.Entity<TypeEventLogs>().HasData(listType);            
        }
    }
}
