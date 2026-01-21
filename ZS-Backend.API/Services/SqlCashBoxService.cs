using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Repositories;

namespace ZS_Backend.API.Services
{
    public class SqlCashBoxService : ICashBoxService
    {
        private readonly ICashBoxRepository repository;

        public SqlCashBoxService(ICashBoxRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CashBox>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<CashBox?> GetByIdAsync(DateOnly id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<CashBox> AddAsync(CashBox cashBox)
        {
            // set Id and OpenedAt to current date/time
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var existing = await repository.GetByIdAsync(today);
            if (existing != null)
            {
                return existing;
            }

            cashBox.Id = today;
            cashBox.OpenedAt = TimeOnly.FromDateTime(DateTime.UtcNow);

            if (cashBox.Status == Status.Closed)
            {
                if (cashBox.ClosingBalance == null)
                {
                    throw new ArgumentException("ClosingBalance must be provided when closing a CashBox.");
                }
                cashBox.ClosedAt = TimeOnly.FromDateTime(DateTime.UtcNow);
            }

            return await repository.AddAsync(cashBox);
        }

        public async Task<CashBox?> UpdateAsync(DateOnly id, CashBox cashBox)
        {
            if (cashBox.Status == Status.Closed)
            {
                if (cashBox.ClosingBalance == null)
                {
                    throw new ArgumentException("ClosingBalance must be provided when closing a CashBox.");
                }
                cashBox.ClosedAt = TimeOnly.FromDateTime(DateTime.UtcNow);
            }

            return await repository.UpdateAsync(id, cashBox);
        }
    }
}
