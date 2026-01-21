using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Models.DTO;
using ZS_Backend.API.Services;

namespace ZS_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            this.transactionService = transactionService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> GetAll()
        {
            var transactions = await transactionService.GetAllAsync();
            return Ok(mapper.Map<List<TransactionDto>>(transactions));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TransactionDto>> GetById(Guid id)
        {
            var transaction = await transactionService.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(mapper.Map<TransactionDto>(transaction));
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create([FromBody] TransactionRequestDto transactionRequest)
        {
            var transactionDomainModel = mapper.Map<Transaction>(transactionRequest);
            var created = await transactionService.AddAsync(transactionDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, mapper.Map<TransactionDto>(created));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TransactionDto>> Update(Guid id, [FromBody] TransactionRequestDto transactionRequest)
        {
            var transactionDomainModel = mapper.Map<Transaction>(transactionRequest);
            var updated = await transactionService.UpdateAsync(id, transactionDomainModel);
            if (updated == null) return NotFound();
            return Ok(mapper.Map<TransactionDto>(updated));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TransactionDto>> Delete(Guid id)
        {
            var deleted = await transactionService.DeleteAsync(id);
            if (deleted == null) return NotFound();
            return Ok(mapper.Map<TransactionDto>(deleted));
        }
    }
}
