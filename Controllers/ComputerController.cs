using AutoMapper;
using BackendApi.Data;
using BackendApi.Dtos;
using BackendApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly DataContextEF _efcore;
        private readonly IMapper _mapper;

        public ComputerController(DataContextEF efcore, IMapper mapper)
        {
            _efcore = efcore;
            _mapper = mapper;
        }

        [HttpGet("GetComputer/{id:int}")]
        public async Task<IActionResult> GetComputerAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var computer = await GetComputerEntityAsync(id);

            if (computer == null)
                return NotFound();

            return Ok(computer);
        }

        [HttpGet("GetComputers")]
        public async Task<IActionResult> GetComputersAsync()
        {
            var computers = await _efcore.Computers.ToListAsync();
            return Ok(computers);
        }

        [HttpPost("AddComputer")]
        public async Task<IActionResult> AddComputerAsync(ComputerDto computer)
        {
            if (computer == null)
                return BadRequest();

            var computerDB = _mapper.Map<Computer>(computer);

            _efcore.Computers.Add(computerDB);
            await _efcore.SaveChangesAsync();

            return Ok(computerDB);
        }

        [HttpPut("EditComputer")]
        public async Task<IActionResult> EditComputerAsync(ComputerDto computer)
        {
            if (computer == null)
                return BadRequest();

            var computerDB = await GetComputerEntityAsync(computer.Id);

            if (computerDB == null)
                return NotFound();

            _mapper.Map(computer, computerDB);
            await _efcore.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteComputer/{id:int}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            if (id <= 0)
                return BadRequest();

            var computerDB = await GetComputerEntityAsync(id);

            if (computerDB == null)
                return NotFound();

            _efcore.Computers.Remove(computerDB);
            await _efcore.SaveChangesAsync();

            return NoContent();
        }

        private async Task<Computer?> GetComputerEntityAsync(int id)
        {
            return await _efcore.Computers
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
