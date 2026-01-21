using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Services
{
    public interface ILockerService
    {
        Task<List<Locker>> GetAllAsync();
        Task<Locker?> GetByIdAsync(string id);
        Task<Locker?> UpdateAsync(string id, Locker locker);
    }
}
