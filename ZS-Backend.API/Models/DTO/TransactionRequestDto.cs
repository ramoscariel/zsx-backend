using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class TransactionRequestDto
    {
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
