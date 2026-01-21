using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Repositories;

namespace ZS_Backend.API.Services
{
    public class SqlTransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public SqlTransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await transactionRepository.GetAllAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await transactionRepository.GetByIdAsync(id);
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            transaction.OpenedAt = DateTime.UtcNow;

            if (transaction.Status == Status.Closed)
            {
                transaction.ClosedAt = DateTime.UtcNow;
            }

            return await transactionRepository.AddAsync(transaction);
        }

        public async Task<Transaction?> UpdateAsync(Guid id, Transaction transaction)
        {
            if (transaction.Status == Status.Closed)
            {
                transaction.ClosedAt = DateTime.UtcNow;
            }
            else
            {
                transaction.ClosedAt = null;
            }
            return await transactionRepository.UpdateAsync(id, transaction);
        }

        public async Task<Transaction?> DeleteAsync(Guid id)
        {
            return await transactionRepository.DeleteAsync(id);
        }
    }
}
