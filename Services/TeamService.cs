using AutoMapper;
using FootballManagerApi.Data;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerApi.Services
{
    public class TeamService:ITeamService
    {
        private readonly FootballDbContext _context;
        private readonly IMapper _mapper;

        public TeamService(FootballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams.Include(t => t.Players).ToListAsync();
            return _mapper.Map<List<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams.Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == id);
            return team == null ? null : _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto> CreateTeamAsync(CreateTeamDto newTeam)
        {
            var team = _mapper.Map<Team>(newTeam);
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return _mapper.Map<TeamDto>(team);
        }

        public async Task<bool> UpdateTeamAsync(int id, UpdateTeamDto updatedTeam)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _mapper.Map(updatedTeam, team);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
