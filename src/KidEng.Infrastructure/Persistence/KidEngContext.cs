using KidEng.Domain.Common;
using KidEng.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KidEng.Infrastructure.Persistence
{
    public class KidEngContext : DbContext
    {
        public KidEngContext(DbContextOptions<KidEngContext> options) : base(options)
        {
        }

        public DbSet<Vocabulary> Vocabularies { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = "admin";
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "admin";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
