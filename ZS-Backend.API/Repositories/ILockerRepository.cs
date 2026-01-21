using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public interface ILockerRepository
    {
        Task<List<Locker>> GetAllAsync();
        Task<Locker?> GetByIdAsync(string id);
        Task<Locker?> UpdateAsync(string id, Locker key);
    }
}
