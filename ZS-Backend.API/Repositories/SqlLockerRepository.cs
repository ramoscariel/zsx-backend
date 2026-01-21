using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Data;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public class SqlLockerRepository : ILockerRepository
    {
        private readonly ZsDbContext dbContext;
        public SqlLockerRepository(ZsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Locker>> GetAllAsync()
        {
            return await dbContext.Lockers
               .Include(l=> l.LastAssignedClient)
               .ToListAsync();
        }

        public async Task<Locker?> GetByIdAsync(string id)
        {
            return await dbContext.Lockers
                .Include(l => l.LastAssignedClient)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Locker?> UpdateAsync(string id, Locker locker)
        {
            var existingLocker = await dbContext.Lockers.FirstOrDefaultAsync(l => l.Id == id);
            if (existingLocker == null) return null;

            existingLocker.LastAssignedTo = locker.LastAssignedTo;
            existingLocker.LastAssignedAt = locker.LastAssignedAt;
            existingLocker.Available = locker.Available;
            existingLocker.Notes = locker.Notes;

            await dbContext.SaveChangesAsync();

            await dbContext.Entry(existingLocker).Reference(l => l.LastAssignedClient).LoadAsync();
            return existingLocker;
        }
    }
}
