using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Data
{
    public class ZsDbContext : DbContext
    {
        public ZsDbContext(DbContextOptions<ZsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}