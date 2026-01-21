using System.ComponentModel.DataAnnotations.Schema;

namespace ZS_Backend.API.Models.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public Status Status { get; set; }
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }
    }
}
