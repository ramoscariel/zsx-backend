using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Data;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public class SqlCashBoxRepository : ICashBoxRepository
    {
        private readonly ZsDbContext dbContext;

        public SqlCashBoxRepository(ZsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CashBox>> GetAllAsync()
        {
            return await dbContext.CashBoxes
                .Include(cb => cb.Transactions)
                .ToListAsync();
        }

        public async Task<CashBox?> GetByIdAsync(DateOnly id)
        {
            return await dbContext.CashBoxes
                .Include(cb => cb.Transactions)
                .FirstOrDefaultAsync(cb => cb.Id == id);
        }

        public async Task<CashBox> AddAsync(CashBox cashBox)
        {
            var entity = (await dbContext.CashBoxes.AddAsync(cashBox)).Entity;
            await dbContext.SaveChangesAsync();
            await dbContext.Entry(entity).Collection(e => e.Transactions).LoadAsync();
            return entity;
        }

        public async Task<CashBox?> UpdateAsync(DateOnly id, CashBox cashBox)
        {
            var existing = await dbContext.CashBoxes.FindAsync(id);
            if (existing == null) return null;

            // update fields
            existing.Status = cashBox.Status;
            existing.OpenedAt = cashBox.OpenedAt;
            existing.ClosedAt = cashBox.ClosedAt;
            existing.OpeningBalance = cashBox.OpeningBalance;
            existing.ClosingBalance = cashBox.ClosingBalance;
            existing.AttendantName = cashBox.AttendantName;

            dbContext.CashBoxes.Update(existing);
            await dbContext.SaveChangesAsync();

            await dbContext.Entry(existing).Collection(e => e.Transactions).LoadAsync();
            return existing;
        }
    }
}
