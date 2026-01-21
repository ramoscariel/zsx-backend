using System.ComponentModel.DataAnnotations;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class CashBoxDto
    {
        public DateOnly Id { get; set; }
        public Status Status { get; set; }
        public TimeOnly OpenedAt { get; set; }
        public TimeOnly? ClosedAt { get; set; }
        public double OpeningBalance { get; set; }
        public double? ClosingBalance { get; set; }

        public string AttendantName { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
