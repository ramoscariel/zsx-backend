using System.ComponentModel.DataAnnotations;
using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class ClientRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Number { get; set; }
    }
}
