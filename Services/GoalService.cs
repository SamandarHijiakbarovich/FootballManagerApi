using AutoMapper;
using FootballManagerApi.Data;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerApi.Services
{

    public class GoalService : IGoalService
    {
        private readonly FootballDbContext _context;
        private readonly IMapper _mapper;

        public GoalService(FootballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GoalDto> CreateGoalAsync(CreateGoalDto dto)
        {
            var goal = _mapper.Map<Goal>(dto);
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return _mapper.Map<GoalDto>(goal);
        }

        public async Task<bool> DeleteGoalAsync(int id)
        {
            var goal = _context.Goals.FindAsync(id);
            if (goal == null) return false;

            _context.Goals.Remove(goal.Result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GoalDto>> GetGoalAllAsync()
        {
            var goals = await _context.Goals
                .Include(g => g.Player)
                .Include(g => g.Match)
                .ToListAsync();

            return _mapper.Map<List<GoalDto>>(goals);
        }

        public async Task<GoalDto?> GetGoalByIdAsync(int id)
        {
            var goal = await _context.Goals
                .Include(g => g.Player)
                .Include(g => g.Match)
                .FirstOrDefaultAsync(g => g.Id == id);

            return goal == null ? null : _mapper.Map<GoalDto>(goal);
        }

        public async Task<bool> UpdateGoalAsync(int id, UpdateGoalDto dto)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal == null) return false;
            _mapper.Map(dto, goal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
