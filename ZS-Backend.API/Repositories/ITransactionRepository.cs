using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<Transaction> AddAsync(Transaction transaction);
        Task<Transaction?> UpdateAsync(Guid id, Transaction transaction);
        Task<Transaction?> DeleteAsync(Guid id);
    }
}
