using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerDto>> GetAllAsync();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<PlayerDto> CreateAsync(CreatePlayerDto dto);
        Task<bool> UpdateAsync(int id, UpdatePlayerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
