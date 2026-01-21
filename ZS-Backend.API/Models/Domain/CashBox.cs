using System.ComponentModel.DataAnnotations;

namespace ZS_Backend.API.Models.Domain
{
    public class CashBox
    {
        [Key]
        public DateOnly Id { get; set; }
        public Status Status { get; set; }
        public TimeOnly OpenedAt { get; set; }
        public TimeOnly? ClosedAt { get; set; }
        public double OpeningBalance { get; set; }
        public double? ClosingBalance { get; set; }

        public string AttendantName { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
