using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZS_Backend.API.Models.Domain
{
    public class Locker
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        public Guid? LastAssignedTo { get; set; }
        public DateTime? LastAssignedAt { get; set; }
        public bool Available { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }


        [ForeignKey(nameof(LastAssignedTo))]
        public Client? LastAssignedClient { get; set; }
    }
}
