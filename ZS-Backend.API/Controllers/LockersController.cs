using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Models.DTO;
using ZS_Backend.API.Services;

namespace ZS_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : ControllerBase
    {
        private readonly ILockerService lockerService;
        private readonly IMapper mapper;

        public LockersController(ILockerService lockerService, IMapper mapper)
        {
            this.lockerService = lockerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lockers = await lockerService.GetAllAsync();
            var lockersDto = mapper.Map<List<LockerDto>>(lockers);
            return Ok(lockersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var locker = await lockerService.GetByIdAsync(id);
            if (locker == null) return NotFound();

            var lockerDto = mapper.Map<LockerDto>(locker);
            return Ok(lockerDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] LockerRequestDto lockerRequestDto)
        {
            var locker = mapper.Map<Locker>(lockerRequestDto);

            var updated = await lockerService.UpdateAsync(id, locker);
            if (updated == null) return NotFound();

            var lockerDto = mapper.Map<LockerDto>(updated);
            return Ok(lockerDto);
        }
    }
}
