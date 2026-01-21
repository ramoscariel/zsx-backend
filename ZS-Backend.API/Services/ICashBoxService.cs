using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Services
{
    public interface ICashBoxService
    {
        Task<List<CashBox>> GetAllAsync();
        Task<CashBox?> GetByIdAsync(DateOnly id);
        Task<CashBox> AddAsync(CashBox cashBox);
        Task<CashBox?> UpdateAsync(DateOnly id, CashBox cashBox);
    }
}
