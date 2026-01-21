using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(Guid id);
        Task<Client> AddAsync(Client client);
        Task<Client?> UpdateAsync(Guid id, Client client);
        Task<Client?> DeleteAsync(Guid id);
    }
}
