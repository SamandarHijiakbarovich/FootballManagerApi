using FootballManagerApi.DTOs;
using FootballManagerApi.Services;
using FootballManagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchsController : ControllerBase
    {

        private readonly IMatchService _matchService;
        public MatchsController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: api/Matchs
        [HttpGet]
        public async Task<ActionResult<List<MatchDto>>> GetAll()
        {
            var matches = await _matchService.GetMatchesAllAsync();
            return Ok(matches);
        }


        // GET: api/Matchs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetById(int id)
        {
            var match = await _matchService.GetMatchByIdAsync(id);
            if (match == null)
                return NotFound();

            return Ok(match);
        }

        //POST:api/Matchs
        [HttpPost]
        public async Task<ActionResult<MatchDto>> Create([FromBody] CreateMatchDto dto)
        {
            var created = await _matchService.CreateMatchAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        }

        // Updated method to fix CS0472 diagnostic error
        [HttpPut("{id}")]
        public async Task<ActionResult<MatchDto>> Update(int id, [FromBody] UpdateMatchDto dto)
        {
            var updated = await _matchService.UpdateMatchAsync(id, dto);
            if (!updated) // Changed from `updated == null` to `!updated` since `updated` is a bool
                return NotFound();
            return Ok(updated);
        }

        // DELETE: api/Matchs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _matchService.DeleteMatchAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

    }
}
