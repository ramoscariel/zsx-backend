using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class LockerDto
    {
        public string Id { get; set; }
        public DateTime? LastAssignedAt { get; set; }
        public bool Available { get; set; }
        public string? Notes { get; set; }
        public ClientDto? LastAssignedClient { get; set; }
    }
}
