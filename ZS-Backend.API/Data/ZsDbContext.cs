using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Data
{
    public class ZsDbContext : DbContext
    {
        public ZsDbContext(DbContextOptions<ZsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedLockers(modelBuilder);
        }

        private void SeedLockers(ModelBuilder modelBuilder) {
            var lockers = new List<Locker>()
            {
                new Locker { Id = "1H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "2H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "3H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "4H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "5H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "6H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "7H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "8H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "9H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "10H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "11H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "12H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "13H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "14H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "15H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "16H", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },

                new Locker { Id = "1M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "2M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "3M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "4M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "5M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "6M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "7M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "8M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "9M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "10M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "11M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "12M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "13M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "14M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "15M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
                new Locker { Id = "16M", LastAssignedTo = null, LastAssignedAt = null, Available = true, Notes = null },
            };

            modelBuilder.Entity<Locker>().HasData(lockers);
        }
    }
}