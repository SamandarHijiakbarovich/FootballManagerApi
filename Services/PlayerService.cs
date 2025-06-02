using AutoMapper;
using FootballManagerApi.Data;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerApi.Services
{
    public class PlayerService:IPlayerService
    {
        private readonly FootballDbContext _context;
        private readonly IMapper _mapper;

        public PlayerService(FootballDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _context.Players.Include(p => p.Team).ToListAsync();
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<PlayerDto> GetPlayerByIdAsync(int id)
        {
            var player = await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);
            return player == null ? null : _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto newPlayer)
        {
            var player = _mapper.Map<Player>(newPlayer);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerDto updatedPlayer)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;

            _mapper.Map(updatedPlayer, player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<PlayerDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDto> CreateAsync(CreatePlayerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdatePlayerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
