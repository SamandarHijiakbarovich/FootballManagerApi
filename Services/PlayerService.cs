using AutoMapper;
using FootballManagerApi.Data;
using FootballManagerApi.DTOs;
using FootballManagerApi.Models;
using FootballManagerApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerApi.Services;



public class PlayerService:IPlayerService
{
    private readonly FootballDbContext _context;
    private readonly IMapper _mapper;

    public PlayerService(FootballDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PlayerDto>> GetAllPlayerAsync()
    {
        var players = await _context.Players
            .Include(p => p.Team) // agar Team navigation bor bo‘lsa
            .ToListAsync();

        return _mapper.Map<List<PlayerDto>>(players);
    }

    public async Task<PlayerDto?> GetPlayerByIdAsync(int id)
    {
        var player = await _context.Players
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);

        return player == null ? null : _mapper.Map<PlayerDto>(player);
    }

    public async Task<PlayerDto> CreateAsync(CreatePlayerDto dto)
    {
        var player = _mapper.Map<Player>(dto);
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return _mapper.Map<PlayerDto>(player);
    }

    public async Task<bool> UpdateAsync(int id, UpdatePlayerDto dto)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
            return false;

        _mapper.Map(dto, player);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
            return false;

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }

}
