using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Data;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public class SqlTransactionRepository : ITransactionRepository
    {
        private readonly ZsDbContext dbContext;

        public SqlTransactionRepository(ZsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await dbContext.Transactions
                .Include(t => t.Client)
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await dbContext.Transactions
                .Include(t => t.Client)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            var entity = (await dbContext.Transactions.AddAsync(transaction)).Entity;
            await dbContext.SaveChangesAsync();
            await dbContext.Entry(entity).Reference(e => e.Client).LoadAsync();
            return entity;
        }

        public async Task<Transaction?> UpdateAsync(Guid id, Transaction transaction)
        {
            var existing = await dbContext.Transactions.FindAsync(id);
            if (existing == null) return null;

            // update fields
            existing.Status = transaction.Status;
            existing.ClosedAt = transaction.ClosedAt;
            existing.ClientId = transaction.ClientId;

            dbContext.Transactions.Update(existing);
            await dbContext.SaveChangesAsync();

            await dbContext.Entry(existing).Reference(e => e.Client).LoadAsync();
            return existing;
        }

        public async Task<Transaction?> DeleteAsync(Guid id)
        {
            var existing = await dbContext.Transactions.FindAsync(id);
            if (existing == null) return null;

            dbContext.Transactions.Remove(existing);
            await dbContext.SaveChangesAsync();

            await dbContext.Entry(existing).Reference(e => e.Client).LoadAsync();
            return existing;
        }
    }
}
