using System.ComponentModel.DataAnnotations;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class CashBoxRequestDto
    {
        [Required]
        public Status Status { get; set; }
        [Required]
        public double OpeningBalance { get; set; }
        [Required]
        public double? ClosingBalance { get; set; }
        [Required]
        public string AttendantName { get; set; }
    }
}
