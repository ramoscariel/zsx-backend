using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Repositories;

namespace ZS_Backend.API.Services
{
    public class SqlLockerService : ILockerService
    {
        private readonly ILockerRepository lockerRepository;

        public SqlLockerService(ILockerRepository lockerRepository)
        {
            this.lockerRepository = lockerRepository;
        }

        public async Task<List<Locker>> GetAllAsync()
        {
            return await lockerRepository.GetAllAsync();
        }

        public async Task<Locker?> GetByIdAsync(string id)
        {
            return await lockerRepository.GetByIdAsync(id);
        }

        public async Task<Locker?> UpdateAsync(string id, Locker locker)
        {
            // locker.LastAssignedAt is not part of the incoming DTO
            locker.LastAssignedAt = DateTime.UtcNow;
            return await lockerRepository.UpdateAsync(id, locker);
        }
    }
}
