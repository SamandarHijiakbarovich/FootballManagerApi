using AutoMapper;
using FootballManagerApi.Data;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FootballManagerApi.Services
{
    public class MatchService : IMatchService
    {
        private readonly FootballDbContext _context;
        private readonly IMapper _mapper;



        public MatchService(FootballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MatchDto> CreateMatchAsync(CreateMatchDto newMatch)
        {
            var match = _mapper.Map<Match>(newMatch);
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return _mapper.Map<MatchDto>(match);
        }

        public async Task<bool> DeleteMatchAsync(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return false;

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MatchDto>> GetMatchesAllAsync()
        {
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .ToListAsync();

            return _mapper.Map<List<MatchDto>>(matches);
        }

        public async Task<MatchDto?> GetMatchByIdAsync(int id)
        {
            var match = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .FirstOrDefaultAsync(m => m.Id == id);

            return match == null ? null : _mapper.Map<MatchDto>(match);
        }

        public async Task<bool> UpdateMatchAsync(int id, UpdateMatchDto dto)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return false;

            _mapper.Map(dto, match);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
