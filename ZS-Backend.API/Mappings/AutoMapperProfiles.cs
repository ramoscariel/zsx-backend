using AutoMapper;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Models.DTO;

namespace ZS_Backend.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Client
            CreateMap<Client, ClientDto>();
            CreateMap<ClientRequestDto, Client>();

            // Locker
            CreateMap<Locker, LockerDto>();
            CreateMap<LockerRequestDto, Locker>();

            // Transaction
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionRequestDto, Transaction>();
        }
    }
}
