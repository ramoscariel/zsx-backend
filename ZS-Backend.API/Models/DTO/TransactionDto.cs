using System.ComponentModel.DataAnnotations.Schema;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public Status Status { get; set; }
        public ClientDto? Client { get; set; }
    }
}
