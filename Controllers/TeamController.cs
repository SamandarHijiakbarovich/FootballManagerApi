using FootballManagerApi.DTOs;
using FootballManagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
       

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<List<TeamDto>>> GetAll()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        // GET: api/team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
                return NotFound();
            return Ok(team);
        }

        // POST: api/player
        [HttpPost]
        public async Task<ActionResult<TeamDto>> Create([FromBody] CreateTeamDto dto)
        {
            var created = await _teamService.CreateTeamAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/player/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeamDto dto)
        {
            var success = await _teamService.UpdateTeamAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // DELETE: api/player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _teamService.DeleteTeamAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
