using FootballManagerApi.DTOs;
using FootballManagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/player
        [HttpGet]
        public async Task<ActionResult<List<PlayerDto>>> GetAll()
        {
            var players = await _playerService.GetAllPlayerAsync();
            return Ok(players);
        }

        // GET: api/player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }

        // POST: api/player
        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Create([FromBody] CreatePlayerDto dto)
        {
            var created = await _playerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/player/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePlayerDto dto)
        {
            var success = await _playerService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _playerService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

    }
}
