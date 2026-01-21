using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Models.DTO;
using ZS_Backend.API.Services;

namespace ZS_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxesController : ControllerBase
    {
        private readonly ICashBoxService cashBoxService;
        private readonly IMapper mapper;

        public CashBoxesController(ICashBoxService cashBoxService, IMapper mapper)
        {
            this.cashBoxService = cashBoxService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cashBoxes = await cashBoxService.GetAllAsync();
            return Ok(mapper.Map<List<CashBoxDto>>(cashBoxes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!TryParseDateOnly(id, out var date))
            {
                return BadRequest("Invalid date format. Use yyyy-MM-dd.");
            }

            var cashBox = await cashBoxService.GetByIdAsync(date);
            if (cashBox == null) return NotFound();

            return Ok(mapper.Map<CashBoxDto>(cashBox));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CashBoxRequestDto dto)
        {
            try
            {
                var cashBox = mapper.Map<CashBox>(dto);
                cashBox = await cashBoxService.AddAsync(cashBox);

                return CreatedAtAction(nameof(GetById),
                    new { id = cashBox.Id.ToString("yyyy-MM-dd") },
                    mapper.Map<CashBoxDto>(cashBox));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] CashBoxRequestDto dto)
        {
            if (!TryParseDateOnly(id, out var date))
            {
                return BadRequest("Invalid date format. Use yyyy-MM-dd.");
            }

            try
            {
                var cashBox = mapper.Map<CashBox>(dto);
                var updated = await cashBoxService.UpdateAsync(date, cashBox);
                if (updated == null) return NotFound();

                return Ok(mapper.Map<CashBoxDto>(updated));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static bool TryParseDateOnly(string input, out DateOnly date)
        {
            // Try default parse
            if (DateOnly.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return true;

            // Try exact yyyy-MM-dd
            if (DateOnly.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return true;

            // Try ISO format
            return DateOnly.TryParse(input, out date);
        }
    }
}
