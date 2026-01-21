using Microsoft.EntityFrameworkCore;
using ZS_Backend.API.Data;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Repositories
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly ZsDbContext dbContext;
        public SqlClientRepository(ZsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return client;
        }
        public async Task<Client?> UpdateAsync(Guid id, Client client)
        {
            var existingClient = await dbContext.Clients.FindAsync(id);
            if (existingClient == null)
            {
                return null;
            }

            existingClient.Name = client.Name;
            existingClient.DocumentNumber = client.DocumentNumber;
            existingClient.DocumentType = client.DocumentType;
            existingClient.Email = client.Email;
            existingClient.Address = client.Address;
            existingClient.Number = client.Number;

            await dbContext.SaveChangesAsync();
            return existingClient;
        }

        public async Task<Client?> DeleteAsync(Guid id)
        {
            var existingClient = await dbContext.Clients.FindAsync(id);
            if (existingClient == null)
            {
                return null;
            }

            dbContext.Clients.Remove(existingClient);
            await dbContext.SaveChangesAsync();

            return existingClient;
        }
    }
}
