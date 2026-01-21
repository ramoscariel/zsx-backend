using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Models.DTO;
using ZS_Backend.API.Services;

namespace ZS_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly IMapper mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await clientService.GetAllAsync();
            return Ok(mapper.Map<List<ClientDto>>(clients));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await clientService.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(mapper.Map<ClientDto>(client));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientRequestDto dto)
        {
            try
            {
                var client = mapper.Map<Client>(dto);
                client = await clientService.AddAsync(client);

                return CreatedAtAction(nameof(GetById),
                    new { id = client.Id },
                    mapper.Map<ClientDto>(client));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientRequestDto dto)
        {
            try
            {
                var client = mapper.Map<Client>(dto);
                client = await clientService.UpdateAsync(id, client);

                if (client == null) return NotFound();

                return Ok(mapper.Map<ClientDto>(client));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await clientService.DeleteAsync(id);
            if (client == null) return NotFound();
            return Ok(mapper.Map<ClientDto>(client));
        }
    }
}
