using System.ComponentModel.DataAnnotations;

namespace ZS_Backend.API.Models.DTO
{
    public class LockerRequestDto
    {
        [Required]
        public Guid? LastAssignedTo { get; set; }
        [Required]
        public bool Available { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
