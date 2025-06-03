using FootballManagerApi.DTOs;
using FootballManagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;
        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        // POST: api/goals
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGoalDto dto)
        {
            var created = await _goalService.CreateGoalAsync(dto);
            return Ok(created);
        }

        // GET: api/goals
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goals = await _goalService.GetGoalAllAsync();
            return Ok(goals);
        }

        // GET: api/goals/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var goal = await _goalService.GetGoalByIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        // PUT: api/goals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGoalDto dto)
        {
            var updated = await _goalService.UpdateGoalAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/goals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _goalService.DeleteGoalAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
