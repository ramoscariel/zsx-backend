using ZS_Backend.API.Models.Domain;

namespace ZS_Backend.API.Models.DTO
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
    }
}
